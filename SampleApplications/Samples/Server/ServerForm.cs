using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using Opc.Ua;
using Opc.Ua.Server;
using Opc.Ua.Configuration;
using System.IO;
using Opc.Ua.Sample;
namespace Opc.Ua.Sample
{
    public partial class ServerForms : Form
    {

        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        public ServerForms()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a form which displays the status for a UA server.
        /// </summary>
        public ServerForms(ApplicationInstance application)
        {
            InitializeComponent();

            m_application = application;

            if (application.Server is StandardServer)
            {
              // this.serverDiagnosticsCtrl1.Initialize((StandardServer)application.Server, application.ApplicationConfiguration);
            }

            if (!application.ApplicationConfiguration.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                application.ApplicationConfiguration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
            }

            //TrayIcon.Text = this.Text = application.ApplicationName;
            //TrayIcon.Icon = GetAppIcon();
        }
        #endregion

        #region Private Fields
        private ApplicationInstance m_application;
        #endregion

        #region Private Methods
        private static class NativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            static extern internal IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            static extern internal IntPtr LoadLibrary(string lpFileName);
        }

        /// <summary>
        /// Gets the application icon.
        /// </summary>
        static Icon GetAppIcon()
        {
            string fileName = Assembly.GetEntryAssembly().Location;
            IntPtr hLibrary = NativeMethods.LoadLibrary(fileName);

            if (hLibrary != IntPtr.Zero)
            {
                IntPtr hIcon = NativeMethods.LoadIcon(hLibrary, "#32512");

                if (hIcon != IntPtr.Zero)
                {
                    return Icon.FromHandle(hIcon);
                }
            }

            return null;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles a certificate validation error.
        /// </summary>
        void CertificateValidator_CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            try
            {
                HandleCertificateValidationError(this, validator, e);
            }
            catch (Exception exception)
            {
                HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        public static void HandleException(string caption, MethodBase method, Exception e)
        {
            if (String.IsNullOrEmpty(caption))
            {
                caption = method.Name;
            }

            new ExceptionDlg().ShowDialog(caption, e);
        }
        private void ServerForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Server_ExitMI_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static void HandleCertificateValidationError(Form caller, CertificateValidator validator, CertificateValidationEventArgs e)
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendFormat("Certificate could not validated: {0}\r\n\r\n", e.Error.StatusCode);
            buffer.AppendFormat("Subject: {0}\r\n", e.Certificate.Subject);
            buffer.AppendFormat("Issuer: {0}\r\n", (e.Certificate.Subject == e.Certificate.Issuer) ? "Self-signed" : e.Certificate.Issuer);
            buffer.AppendFormat("Valid From: {0}\r\n", e.Certificate.NotBefore);
            buffer.AppendFormat("Valid To: {0}\r\n", e.Certificate.NotAfter);
            buffer.AppendFormat("Thumbprint: {0}\r\n\r\n", e.Certificate.Thumbprint);

            buffer.AppendFormat("Accept anyways?");

            if (MessageBox.Show(buffer.ToString(), caller.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Accept = true;
            }
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                m_application.Stop();
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "Error stopping server.");
            }
        }

        private void TrayIcon_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                StandardServer server = m_application.Server as StandardServer;

                if (server != null)
                {
                    //TrayIcon.Text = String.Format(
                    //     "{0} [{1} {2:HH:mm:ss}]", 
                    //   m_application.ApplicationName,
                    // server.CurrentInstance.CurrentState,
                    // DateTime.Now);
                }
            }
            catch (Exception exception)
            {
                Utils.Trace(exception, "Error getting server status.");
            }
        }
        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quit this application", "Generic Server", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "\\WebHelp\\ua_sample_server.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to launch help documentation. Error: " + ex.Message);
            }
        }

        private void InitializeComponent()
        {
#pragma warning disable CS0436 // The type 'ServerDiagnosticsCTRL' in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\ServerDiagnosticsCTRL.cs' conflicts with the imported type 'ServerDiagnosticsCTRL' in 'Opc.Ua.SampleServer, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\ServerDiagnosticsCTRL.cs'.
            this.serverDiagnosticsCTRL1 = new Opc.Ua.Sample.ServerDiagnosticsCTRL();
#pragma warning restore CS0436 // The type 'ServerDiagnosticsCTRL' in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\ServerDiagnosticsCTRL.cs' conflicts with the imported type 'ServerDiagnosticsCTRL' in 'Opc.Ua.SampleServer, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\adam\Desktop\projects\Working OPCServer\SampleApplications\Samples\Server\ServerDiagnosticsCTRL.cs'.
            this.SuspendLayout();
            // 
            // serverDiagnosticsCTRL1
            // 
            this.serverDiagnosticsCTRL1.Location = new System.Drawing.Point(-2, -2);
            this.serverDiagnosticsCTRL1.Name = "serverDiagnosticsCTRL1";
            this.serverDiagnosticsCTRL1.Size = new System.Drawing.Size(534, 345);
            this.serverDiagnosticsCTRL1.TabIndex = 0;
            // 
            // ServerForms
            // 
            this.ClientSize = new System.Drawing.Size(532, 344);
            this.Controls.Add(this.serverDiagnosticsCTRL1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServerForms";
            this.ResumeLayout(false);

        }
    }
}
