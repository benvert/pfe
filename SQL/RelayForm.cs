using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using IEC61850.Client;
using IEC61850.Common;
using System.IO;
using System.Threading;
using System.Diagnostics;
using static SQL.Vars;
namespace SQL
{
    public partial class RelayForm : Form
    {
        //Variable serveur/client OPC
        public bool[] ValeurOPC { get; set; }
        bool firspass = true;
        //Déclarations de variables
        IedConnection ConnectToIED;
        List<ControlObject> control = new List<ControlObject>();
        IsoConnectionParameters param;
        string hostname, password, Device_name, rcb_ref;
        int port = 102;
        List<string> refer = new List<string>();

        Dictionary<string, int> Virtualinputs = new Dictionary<string, int>();
        List<ReportControlBlock> RCBS = new List<ReportControlBlock>();
        bool[] Valeur;
        private class ligne
        {
            public bool _val { get; set; }
            public string _name { get; set; }

        }
        SQLiteConnection database_connection = null;
        SQLiteCommand cmd = null;
        CancellationTokenSource DbCancelation, ReadCancelation, IEDCancelation;
        Task FillTask, ReadTask;
        bool firstThick, firstUse, IEDConnected, Dbisopen;
        public RelayForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // DbReport = MesVariables.DbReport;  //
            Dbisopen = false;
            IEDConnected = false;
            firstUse = true;
            Valeur = Class.SPCS;
            database_connection = new SQLiteConnection("Data Source=:memory:;Version=3;;cache=shared");
            ConnectToIED = new IedConnection();
            param = ConnectToIED.GetConnectionParameters();
            initialiser();
            password = "password";
            hostname = "192.168.1.10";
            IpBox.Text = hostname;
            PassBox.Text = password;
            PortBox.Text = "102";

        }

        #region button
        //Exit
        private void Exit_Click(object sender, EventArgs e)
        {
            DbCancelation.Cancel();
            ReadCancelation.Cancel();
            IEDConnected = false;
            Closedb();
            Form.ActiveForm.Close();


        }
        //Connecter
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(IpBox.Text))
                hostname = IpBox.Text.ToString();
            if (!String.IsNullOrEmpty(PortBox.Text))
                port = Convert.ToInt32(PortBox.Text);
            if (!String.IsNullOrEmpty(PassBox.Text))
                password = Convert.ToString(PassBox.ToString());
            if (checkBox1.Checked && firspass)
            { param.UsePasswordAuthentication(password); firspass = false; }


            bool retry = true;
            while (retry)
            {
                try
                {

                    ConnectToIED.Connect(hostname, port);
                    Disconnect_button.Enabled = true;
                    Connect_button.Enabled = false;
                    Exit_button.Enabled = false;
                    CreateButton.Enabled = true;
                    Get_reports.Enabled = true;
                    IpBox.Clear();
                    PortBox.Clear();
                    PassBox.Clear();
                    retry = false;
                    toolStatus.Text = "Connected";
                    IEDConnected = true;
                    int i = 1;
                    for (i = 1; i < 65; i++)
                    {
                        refer.Add("GEDeviceF650/vinGGIO1.SPCSO" + i.ToString() + "");
                        control.Add(ConnectToIED.CreateControlObject(refer[i - 1]));
                    }
                }
                catch (IedConnectionException ex)
                {
                    IEDConnected = false;
                    toolStatus.Text = "Failed to connect";
                    if (MessageBox.Show(ex.Message + "for the following reason" + ex.GetIedClientError(), "Erreur", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                    {
                        retry = false;
                    }
                    else
                    {
                        retry = true;
                    }
                }
            }
        }
        //utilisation de mot de passe
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                label5.Hide();
                PassBox.Hide();

            }
            else
            {
                label5.Show();
                PassBox.Show();

            }

        }
        //Déconnecter
        private void Disconnect_button_Click(object sender, EventArgs e)
        {
            bool retry = true;
            while (retry)
            {
                try
                {

                    ConnectToIED.Close();
                    Disconnect_button.Enabled = false;
                    Connect_button.Enabled = true;
                    Exit_button.Enabled = true;
                    retry = false;
                    toolStatus.Text = "Disconnected";
                    IEDConnected = false;
                }
                catch (IedConnectionException ex)
                {
                    IEDConnected = true;
                    toolStatus.Text = "Failed to Disconnect";
                    if (MessageBox.Show(ex.Message + "for the following reason" + ex.GetIedClientError(), "Erreur", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                    {
                        retry = false;
                    }
                    else
                    {
                        retry = true;
                    }
                }

            }
        }
        //Initialisation
        private void Initialise_button_Click(object sender, EventArgs e)
        {

            firstThick = true;
            timer1.Enabled = true;
            var C = new CancellationTokenSource();
            data_create();
            fillGrid(C.Token);
            Write_button.Enabled = true;


        }
        //Ecrire sur L'IED
        private void Write_button_Click(object sender, EventArgs e)
        {
            var C = new CancellationTokenSource();

            WriteIED(C.Token);

        }
        //Clear Database
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            var C = new CancellationTokenSource();

            clear_db();
            fillGrid(C.Token);
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            CancellationTokenSource xs = new CancellationTokenSource();
            fillGrid(xs.Token);
        }
        #endregion

        #region fontions

        //Loading Grid and local variables
        private void initialiser()
        {
            //button management
            disconnectToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            Disconnect_button.Enabled = false;
            checkBox1.Checked = true;
            Write_button.Enabled = false;
            CreateButton.Enabled = false;
            StopReporting.Enabled = false;
            Get_reports.Enabled = false;

            loadGrid();
            int i = 1;
            do
            {
                Virtualinputs.Add("SPCSO" + i.ToString() + "", 0);
                i++;
            } while (i < 65);
        }
        //TIMER
        private void timer1_Tick(object sender, EventArgs e)
        {
            Main();
        }
        //Ecrire sur les virtual inputs
        private void WriteIED(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            { toolStatus.Text = "Cancellation thrown"; return; }
            if (IEDConnected)
            {
                try
                {
                    if (!Dbisopen)
                        Opendb();
                    string sql = "select * from vinTable";
                    cmd = new SQLiteCommand(sql, database_connection);
                    int i = 0;
                    using (SQLiteDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {

                            if (i < 64)
                            {
                                control[i].Operate(ToBool(read.GetInt32(1)));
                                i++;
                            }
                            else
                                i = 0;
                            //ConnectToIED.WriteValue("GEDeviceF650/vinGGIO1." + line._name + "", FunctionalConstraint.CF, new MmsValue(line._val));
                        }
                        toolStatus.Text = "done writing";
                    }
                    //Closedb();
                }
                catch (Exception er)
                {

                    toolStatus.Text = er.Message;

                }
            }

            else
                toolStatus.Text = "IED Disconnected";
        }

        //Fonction de conversion
        private bool ToBool(int x)
        {
            if (x == 0)
                return false;
            else
                return true;
        }
        //Lecture des bools de la DB
        private void DbReading(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            { toolStatus.Text = "Cancellation thrown"; return; }
            if (!Dbisopen)
                Opendb();
            this.Invoke((MethodInvoker)(() => dataGridView.Rows.Clear()));
            if (TableExists("vinTable", database_connection))
            {

                string sql = "SELECT valeur FROM vinTable ";
                cmd = new SQLiteCommand(sql, database_connection);
                try
                {

                    using (SQLiteDataReader read = cmd.ExecuteReader())
                    {
                        int index = 0;
                        while (read.Read())
                        {
                            Valeur[index] = read.GetBoolean(0);

                            index++;


                        }
                        read.Close();
                    }
                    ValeurOPC = Valeur;
                }
                catch (Exception er)
                {
                    this.Invoke((MethodInvoker)(() => db_status.Text = er.Message));
                    ReadCancelation.Cancel();

                }
            }
        }
        #endregion

        #region SQLite
        //Create data base if not existing
        private void data_create()
        {

            if (!Dbisopen)
                Opendb();

            try
            {

                string createTableQuery = "CREATE TABLE IF NOT EXISTS vinTable ( name TEXT UNIQUE, valeur INT)";
                string sql;

                cmd = new SQLiteCommand(createTableQuery, database_connection);
                cmd.ExecuteNonQuery();

                foreach (var item in Virtualinputs)
                {
                    using (cmd = new SQLiteCommand())
                    {
                        sql = "insert or ignore into vinTable( name , valeur ) values ( '" + item.Key.ToString() + "' , '" + item.Value.ToString() + "')";
                        cmd.CommandText = sql;
                        cmd.Connection = database_connection;
                        cmd.ExecuteNonQuery();

                    }


                }
                //Closedb();
                db_status.Text = "created";


            }
            catch (Exception ex)
            {
                db_status.Text = ex.Message;
            }

        }
        //Open and close connection to Db
        private bool Opendb()
        {
            try
            {
                database_connection.Open();
                Dbisopen = true;
                return true;

            }
            catch (Exception er)
            {
                this.Invoke((MethodInvoker)(() => db_status.Text = er.Message));
                Dbisopen = false;
                return false;
            }
        }
        private bool Closedb()
        {

            try
            {
                database_connection.Close();
                Dbisopen = false;
                return false;
            }
            catch (Exception er)
            {
                this.Invoke((MethodInvoker)(() => db_status.Text = er.Message));
                Dbisopen = true;
                return true;
            }
        }
        //suppression
        private void clear_db()
        {
            try
            {
                if (!Dbisopen)
                    Opendb();
                if (!TableExists("vinTable", database_connection))
                { db_status.Text = "Data Base don't exist"; return; }
                string sql = "DELETE FROM vinTable;";
                cmd = new SQLiteCommand(sql, database_connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception er)
            {

                db_status.Text = er.Message;
            }

        }
        //suppression spécifique
        private void Delete_record(string pathname)
        {

            if (!Dbisopen)
                Opendb();
            try
            {
                if (!TableExists("vinTable", database_connection))
                { db_status.Text = "Data Base don't exist"; return; }
                string sql = @"DELETE FROM vinTable WHERE name='" + pathname + "'";
                cmd = new SQLiteCommand(sql, database_connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                db_status.Text = er.Message;
            }

            // //Closedb();
        }
        //mise à jour spécifique
        private void Update_record(string pathname, bool value)
        {

            if (!Dbisopen)
                Opendb();
            try
            {
                if (!TableExists("vinTable", database_connection))
                { db_status.Text = "Data Base don't exist"; return; }
                string sql = @"UPDATE vinTable SET valeur='" + (value ? 1 : 0).ToString() + "'WHERE name='" + pathname + "'";
                cmd = new SQLiteCommand(sql, database_connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception er)
            {
                db_status.Text = er.Message;
            }

            // //Closedb();
        }
        //Vérifier l'existence de la table
        private bool TableExists(String tableName, SQLiteConnection connection)
        {
            try
            {
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' AND name = @name";
                cmd.Parameters.Add("@name", DbType.String).Value = tableName;
                return (cmd.ExecuteScalar() != null);
            }
            catch (Exception er)
            {
                db_status.Text = er.Message;
                return false;

            }

        }
        #endregion

        #region Datagrid

        //chargement et remplissage datagridview
        private void loadGrid()
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ColumnCount = 1;
            dataGridView.Columns[0].Name = "Virtual Input";
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView.Columns.Add(chk);
            chk.Name = "Valeur";
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.Columns[0].ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "ReportVariable";

            dataGridView1.Columns[1].Name = "Value";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Columns[0].ReadOnly = true;
        }
        private void fillGrid(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            { db_status.Text = "Cancellation Thrown"; return; }
            if (!Dbisopen)
                Opendb();
            this.Invoke((MethodInvoker)(() => dataGridView.Rows.Clear()));
            if (TableExists("vinTable", database_connection))
            {

                string sql = "SELECT * FROM vinTable ";

                try
                {
                    cmd = new SQLiteCommand(sql, database_connection);
                    SQLiteDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        this.Invoke((MethodInvoker)(() => dataGridView.Rows.Add(read.GetValue(read.GetOrdinal("name")), read.GetValue(read.GetOrdinal("valeur")))));
                    }

                }
                catch (Exception er)
                {
                    this.Invoke((MethodInvoker)(() => db_status.Text = er.Message));
                    DbCancelation.Cancel();
                }
            }
        }

        private void NamesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(DbReport.Keys.ElementAtOrDefault(NamesCombo.SelectedIndex));
        }

        //changement de valeur
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string path = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            bool valeur = (bool)dataGridView.Rows[e.RowIndex].Cells[1].Value;
            Update_record(path, valeur);
            db_status.Text = "updated succefully";
            control[e.RowIndex].Operate((bool)dataGridView.Rows[e.RowIndex].Cells[1].Value);

        }
        //suppression du record
        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Delete_record(dataGridView.Rows[e.Row.Index].Cells[0].Value.ToString());
            db_status.Text = "record deleted";

        }
        //Detection des pauses
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                timer1.Stop();
            else
                timer1.Start();
        }




        #endregion

        #region repports managment
        //Get info from IED
        //Create tables to store IED reports
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (!IEDConnected)
            { toolStatus.Text = "IED NOT CONNECTED"; return; }
            if (firstUse)
            {
                string Args = hostname + " " + port;
                string pathToFile = Directory.GetCurrentDirectory() + @"\Report_get.exe";
                MessageBox.Show(pathToFile);
                Process Prog = new Process();
                try
                {
                    Prog.StartInfo.FileName = pathToFile;
                    Prog.StartInfo.Arguments = Args;
                    Prog.StartInfo.CreateNoWindow = false;
                    Prog.Start();
                    Prog.WaitForExit();
                    firstUse = false;
                }
                catch (Exception ex)
                {
                    toolStatus.Text = ex.Message;
                    firstUse = true;
                }

            }
            DbReport.Clear();
            string[] x = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\device.txt");
            string[] dbnames = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\db_names.txt");
            string[] reportname = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\reports.txt");
            foreach (string item in x)
            {
                Device_name = item;
            }
            for (int i = 0; i < reportname.Count(); i++)
            {
                DbReport.Add(reportname[i], dbnames[i]);//(report,dbnames)
                NamesCombo.Items.Add(dbnames[i]);
            }
            CreateDbForReports();
        }
        //Configuration du rapport à lire
        private void Get_reports_Click(object sender, EventArgs e)
        {
            if (!IEDConnected)
            {
                toolStatus.Text = "IED NOT CONNECTED";
                return;
            }

            try
            {
                foreach (var item in DbReport)
                {
                    ReportControlBlock x;
                    rcb_ref = Device_name + "/LLN0" + item.Key;
                    x = ConnectToIED.GetReportControlBlock(rcb_ref);
                    RCBS.Add(x);
                }
                foreach (var item in RCBS)
                {
                    item.GetRCBValues();
                    item.InstallReportHandler(ReportHandler, item);
                    item.SetTrgOps(TriggerOptions.DATA_CHANGED | TriggerOptions.INTEGRITY);
                    item.SetIntgPd(5000);
                    item.SetRptEna(true);
                    item.SetRCBValues();
                }

            }
            catch (IedConnectionException ev)
            {
                toolStatus.Text = ev.Message;
            }
            StopReporting.Enabled = true;
        }
        //Thread responsable de la lecture
        private void ReportHandler(Report report, object parameter)
        {
            MmsValue value = report.GetDataSetValues();
            ReadingValues(value, report);
        }
        //créer les tables pour les rapports
        private void CreateDbForReports()
        {
            if (!Dbisopen)
                Opendb();
            foreach (var item in DbReport)
            {


                try
                {

                    string createTableQuery = "CREATE TABLE IF NOT EXISTS " + item.Value + " ( name TEXT UNIQUE, valeur REAL)";
                    cmd = new SQLiteCommand(createTableQuery, database_connection);
                    cmd.ExecuteNonQuery();
                    toolStatus.Text = "created db for report:" + item;

                }
                catch (Exception ex)
                {
                    toolStatus.Text = ex.Message;
                    break;
                }
            }
        }
        //reading values of every 
        private void ReadingValues(MmsValue v, Report report)
        {
            string x = report.GetRcbReference();
            x = x.Replace("GEDeviceF650/LLN0", "");
            for (int i = 1; i < v.Size(); i++)
            {
                string name = report.GetDataReference(i);
                name = name.Replace("GEDeviceF650/", "");
                if (!(v.GetElement(i).GetType() == MmsType.MMS_STRUCTURE))
                    AddIfNotExist(v.GetElement(i).ToFloat(), name, x);
                else
                {
                    ReadingValues(v.GetElement(i), report);
                }
            }
        }
        //Ajout ou mise a jour de la valeur d'un item du rapport
        private void AddIfNotExist(float v, string name, string key)
        {
            if (!Dbisopen)
                Opendb();
            key = DbReport[key];
            if (!TableExists(key, database_connection))
            {
                toolStatus.Text = "Internal ERROR please restart the app";
                return;
            }

            try
            {

                string sql = "INSERT OR IGNORE INTO " + key + " (name,valeur) VALUES('" + name + "'," + v.ToString() + ")";
                sql += "UPDATE " + key + " SET valeur = " + v.ToString() + " WHERE name = '" + name + "'";
                cmd = new SQLiteCommand(sql, database_connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {

                toolStatus.Text = er.Message;
            }


        }
        //Arret de la lecture
        private void StopReporting_Click(object sender, EventArgs e)
        {
            foreach (var item in RCBS)
            {
                item.Dispose();
            }
        }


        #endregion

        #region Tasks Management
        private void Main()
        {

            if (firstThick || FillTask.IsCompleted)
            {
                DbCancelation = new CancellationTokenSource();
                FillTask = Task.Factory.StartNew(() => fillGrid(DbCancelation.Token), DbCancelation.Token);
            }
            if (firstThick || ReadTask.IsCompleted)
            {

                IEDCancelation = new CancellationTokenSource();
               
                ReadCancelation = new CancellationTokenSource();
                if (IEDConnected)
                    ReadTask = Task.Factory.StartNew(() => DbReading(ReadCancelation.Token), ReadCancelation.Token)
                        .ContinueWith((ascendent) => WriteIED(IEDCancelation.Token), IEDCancelation.Token);



            }
            firstThick = false;


        }

        #endregion

        //#region ClientOPC

        ////Initialiser le client
        //private void OPCinit()
        //{
        //    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        //    SecurityConfiguration securityConfiguration = client.Configuration.SecurityConfiguration;

        //    securityConfiguration.ApplicationCertificate.StorePath
        //            = "App Certificates";
        //    securityConfiguration.RejectedCertificateStore.StorePath
        //            = "Rejected Certificates";
        //    securityConfiguration.TrustedIssuerCertificates.StorePath
        //            = "Trusted Issuer Certificates";
        //    securityConfiguration.TrustedPeerCertificates.StorePath
        //            = "Trusted Peer Certificates";
        //    // securityConfiguration.TrustedIssuerCertificates.TrustedCertificates.
        //    client.UseDomainChecks = true;
        //    client.UseSecureEndpoint = true;
        //    securityConfiguration.AutoAcceptUntrustedCertificates = true;
        //}
        ////Déconnecting
        //private void Client_Disconnecting(object sender, EventArgs e)
        //{
        //    OPCconnected = false;
        //    OPCCancelation.Cancel();
        //}
        ////Stop Client
        //private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    client.Disconnect();
        //}

        ////OPCReading
        //private void OPCRead(CancellationToken token)
        //{
        //    if (token.IsCancellationRequested)
        //    { toolStatus.Text = "Cancellation thrown"; return; }
        //    if (!OPCconnected)
        //        return;

        //    for (int i = 1; i < 65; i++)
        //    {
        //        OpcValue values = client.ReadNode("opc.node://identifier:2/#Relais/SPCSO" + i.ToString());
        //        Update_record("SPCSO" + i.ToString(), (bool)values.Value);
        //    }
        //}
        ////startclient
        //private void startToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        client = new OpcClient("opc.tcp://localhost:48030");
        //        OPCinit();
        //        client.Disconnected += Client_Disconnected;
        //        client.Disconnecting += Client_Disconnecting;
        //        client.Connected += Client_Connected;
        //        client.Connect();

        //        OpcNodeInfo node = client.BrowseNode(OpcObjectTypes.ObjectsFolder);
        //        OpcValue value = client.ReadNode("opc.node://identifier:2/#Relais/SPCSO10");
        //        MessageBox.Show(value.Value.ToString());


        //    }
        //    catch (Exception er)
        //    {
        //        OPCconnected = false;
        //        db_status.Text = er.Message;
        //    }
        //}
        ////évenement de connection et déconnection
        //private void Client_Disconnected(object sender, EventArgs e)
        //{
        //    OPCconnected = false;
        //    startToolStripMenuItem.Enabled = true;
        //    stopToolStripMenuItem.Enabled = false;
        //}

        //private void Client_Connected(object sender, EventArgs e)
        //{
        //    OPCconnected = true;
        //    startToolStripMenuItem.Enabled = false;
        //    stopToolStripMenuItem.Enabled = true;
        //}


        //#endregion

        //#region Serveur OPC

        //#region Events

        //private void Server_SessionClosing(object sender, OpcSessionEventArgs e)
        //{
        //    OPCINFO.Text = "Session Closing";


        //}

        //private void Server_Started(object sender, EventArgs e)
        //{
        //    OPCINFO.Text = "Server started";
        //    connectToolStripMenuItem.Enabled = false;
        //    disconnectToolStripMenuItem.Enabled = true;
        //}

        //private void Server_Stopping(object sender, EventArgs e)
        //{
        //    OPCCancelation.Cancel();
        //    OPCconnected = false;
        //}

        //private void Server_Stopped(object sender, EventArgs e)
        //{
        //    connectToolStripMenuItem.Enabled = true;
        //    disconnectToolStripMenuItem.Enabled = false;
        //    OPCconnected = false;

        //}

        //private void Server_SessionActivating(object sender, EventArgs e)
        //{
        //    OPCINFO.Text = "Session Activated";
        //}
        //#endregion
        ////connecter le serveur
        //private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    using (Serveur)
        //    {
        //        Manager.AfterWrite += Manager_AfterWrite;
        //        Serveur = new OpcServerApplication("opc.tcp://localhost:48030/", Manager);
        //        Serveur.Server.SessionActivating += Server_SessionActivating;
        //        Serveur.Server.Started += Server_Started;
        //        Serveur.Server.SessionClosing += Server_SessionClosing;
        //        Serveur.Server.Stopped += Server_Stopped;
        //        Serveur.Server.Stopping += Server_Stopping;
        //        Serveur.Server.Start();
        //        Serveur.Server.Name = "Adams OPC server";


        //    }


        //}

        //private void Manager_AfterWrite(object sender, OpcNodeAccessEventArgs e)
        //{
        //    MessageBox.Show( e.Context.Identity.DisplayName);
        //}

        ////déconnecter le serveur
        //private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Serveur.Server.Dispose();
        //    Serveur.Exit();
        //}

        //#endregion

    }
}
