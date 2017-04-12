using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceModel;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Security.Cryptography.X509Certificates;
using System.IO;

using Opc.Ua.Server;
using Opc.Ua.Configuration;

namespace Opc.Ua.Sample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationName = "UA Sample Server";
            application.ApplicationType   = ApplicationType.Server;
            application.ConfigSectionName = "Opc.Ua.SampleServer";

            try
            {
                // process and command line arguments.
                if (application.ProcessCommandLine())
                {
                    return;
                }

                // check if running as a service.
                if (!Environment.UserInteractive)
                {
#pragma warning disable CS0436 // The type 'SampleServer' in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\SampleServer.cs' conflicts with the imported type 'SampleServer' in 'Opc.Ua.SampleServer, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\SampleServer.cs'.
                    application.StartAsService(new Opc.Ua.Sample.SampleServer());
#pragma warning restore CS0436 // The type 'SampleServer' in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\SampleServer.cs' conflicts with the imported type 'SampleServer' in 'Opc.Ua.SampleServer, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\SampleServer.cs'.
                    return;
                }

                // load the application configuration.
                application.LoadApplicationConfiguration(false);

                // This call registers the certificate with HTTP.SYS 
                // It must be called once after installation if the HTTPS endpoint is enabled.
                // HttpAccessRule.SetHttpsCertificate(c.SecurityConfiguration.ApplicationCertificate.Find(true), 51212, false);

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 0);

                // start the server.
#pragma warning disable CS0436 // The type 'SampleServer' in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\SampleServer.cs' conflicts with the imported type 'SampleServer' in 'Opc.Ua.SampleServer, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\SampleServer.cs'.
                application.Start(new Opc.Ua.Sample.SampleServer());
#pragma warning restore CS0436 // The type 'SampleServer' in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\SampleServer.cs' conflicts with the imported type 'SampleServer' in 'Opc.Ua.SampleServer, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\SampleServer.cs'.

                // run the application interactively.
#pragma warning disable CS0436 // The type 'ServerForms' in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\ServerForm.cs' conflicts with the imported type 'ServerForms' in 'Opc.Ua.SampleServer, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\ServerForm.cs'.
                Application.Run(new ServerForms(application));
#pragma warning restore CS0436 // The type 'ServerForms' in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\ServerForm.cs' conflicts with the imported type 'ServerForms' in 'Opc.Ua.SampleServer, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\ServerForm.cs'.
            }
            catch (Exception e)
            {
                ExceptionDlg.Show(application.ApplicationName, e);
                return;
            }
        }
    }
}
