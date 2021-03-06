#define CUSTOM_NODE_MANAGER
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ServiceModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using System.IdentityModel.Selectors;
using System.Xml;
using Opc.Ua;
using Opc.Ua.Server;

namespace Opc.Ua.Sample
{

    public partial class SampleServer : StandardServer
    {
        #region Overridden Methods
        protected override void OnServerStarting(ApplicationConfiguration configuration)
        {
            Opc.Ua.Com.ComUtils.InitializeSecurity();

            Utils.Trace("The server is starting.");

            base.OnServerStarting(configuration);     
            
            // it is up to the application to decide how to validate user identity tokens.
            // this function creates validators for SAML and X509 identity tokens.
            CreateUserIdentityValidators(configuration);
        }

        protected override void OnServerStarted(IServerInternal server)
        {
            base.OnServerStarted(server);
            
            server.SessionManager.ImpersonateUser += new ImpersonateEventHandler(SessionManager_ImpersonateUser);
        }

        protected override void OnServerStopping()
        {
            Console.WriteLine("The Server is stopping.");

            base.OnServerStopping();
            
            #if INCLUDE_Sample
            CleanSampleModel();
            #endif
        }
        
        #if CUSTOM_NODE_MANAGER

        protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            Console.WriteLine("Creating the Node Managers.");

            List<INodeManager> nodeManagers = new List<INodeManager>();

            // create the custom node managers.
            //nodeManagers.Add(new TestData.TestDataNodeManager(server, configuration));
            nodeManagers.Add(new RelayNodeManager(server, configuration));       
            //nodeManagers.Add(new global::MemoryBuffer.MemoryBufferNodeManager(server, configuration));
           // nodeManagers.Add(new global::Boiler.BoilerNodeManager(server, configuration));
            //nodeManagers.Add(new global::FileSystem.FileSystemNodeManager(server, "%LocalApplicationData%\\OPC Foundation\\Samples\\FileSystem"));
            return new MasterNodeManager(server, configuration, null, nodeManagers.ToArray());
        }
        #endif
        protected override ServerProperties LoadServerProperties()
        {
            ServerProperties properties = new ServerProperties();

            properties.ManufacturerName = "RelayOPCServer";
            properties.ProductName      = "OPC UA ";
            properties.ProductUri       = "http://opcfoundation.org/RelayOPCServer";
            properties.SoftwareVersion  = Utils.GetAssemblySoftwareVersion();
            properties.BuildNumber      = Utils.GetAssemblyBuildNumber();
            properties.BuildDate        = Utils.GetAssemblyTimestamp();


            return properties; 
        }


        protected override void OnNodeManagerStarted(IServerInternal server)
        {
            Console.WriteLine("The NodeManagers have started.");

            // allow base class processing to happen first.
            base.OnNodeManagerStarted(server); 
            
            // adds the sample information models to the core node manager. 
            #if INCLUDE_Sample
            InitializeSampleModel();
            #endif
        }
                
        #if USER_AUTHENTICATION
        protected override ResourceManager CreateResourceManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            ResourceManager resourceManager = new ResourceManager(server, configuration);
            
            // add some localized strings to the resource manager to demonstrate that localization occurs.
            resourceManager.Add("InvalidPassword", "de-DE", "Das Passwort ist nicht gültig für Konto '{0}'.");
            resourceManager.Add("InvalidPassword", "es-ES", "La contraseña no es válida para la cuenta de '{0}'.");

            resourceManager.Add("UnexpectedUserTokenError", "fr-FR", "Une erreur inattendue s'est produite lors de la validation utilisateur.");
            resourceManager.Add("UnexpectedUserTokenError", "de-DE", "Ein unerwarteter Fehler ist aufgetreten während des Anwenders.");
           
            return resourceManager;
        }
        #endif
        #endregion
    }
}
