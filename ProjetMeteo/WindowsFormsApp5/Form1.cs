using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Data.OleDb;
using WindowsFormsApp5.Save_Upload;
using WindowsFormsApp5.Request;
using WindowsFormsApp5.treatmentData;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        RequestDB requestDB = new RequestDB();
        DataSet UserAccount = new DataSet();
        internal static DataTable Local_UserTable = new DataTable();
        internal static DataTable Local_AccessTable = new DataTable();
        DataTable dt = new DataTable();
        public static String username = "pas connecté";
        public static int accessLvl = 5;
        public static List<Base> trame = new List<Base>();

        public Form1()
        {
            InitializeComponent();
            configDataset();
            createTable();
        }

        private void createTable()
        {
            // Creating OLEDB connection string for Ms-Access 2007 database file

            OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;"
                +
                @"Data Source=..\..\DB\DB_UserAccess1.accdb;Cache Authentication=True");
            myConnection.Open();
            // Create Oledb command to execute particular query
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = myConnection;
            // Query to create table with specified data columne
            myCommand.CommandText = "CREATE TABLE tblIdentityTesting([MyIdentityColumn] long, [Name] text)";
            myCommand.ExecuteNonQuery();
            MessageBox.Show("Table Created Successfully");
        }

        private void btLeave_Click(object sender, EventArgs e)
        {
            //cette fonction ferme l'application
            this.Close();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            //cette fontion démarre l'application
            timer.Enabled = true;
            btStart.Enabled = false;
            btConversing.Enabled = true;
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.Open();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            //cette fontion met en pause l'application
            timer.Enabled = false;
            btStart.Enabled = true;
            port.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DisplayData displayData = new DisplayData();
            grid.DataSource = displayData.dataInGrid(dt);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //cette fonction récolte les données mesurées sur le port
            byte[] data = new byte[port.BytesToRead];
            port.Read(data, 0, data.Length);
            DataTreatment dataTreatment = new DataTreatment();
            dataTreatment.createData(data);
        }

        private void btConversing_Click(object sender, EventArgs e)
        {
            ConvertingData convertingData = new ConvertingData();
            convertingData.conversingData((int)nUDId.Value, (int)nUDMin.Value, (int)nUDMax.Value, (int)nUDAlarmMin.Value, (int)nUDAlarmMax.Value);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveUpload save = new SaveUpload();
            save.saveConfig();
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            SaveUpload upload = new SaveUpload();
            upload.uploadConfig();
        }

        private void btSaveUser_Click(object sender, EventArgs e)
        {
            requestDB.createUser(txtBUsername.Text, txtBPassword.Text, (int)nUpDoAccess.Value);
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            requestDB.readData(gridUser);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            requestDB.deleteUser(gridUser);
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            requestDB.loginUser(txtBUsernameLogin.Text, txtBPasswordLogin.Text);
            labUsername.Text = username;
            labAccess.Text = "Niveau d'acces: " + accessLvl;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labUsername.Text = username;
            labAccess.Text = "Niveau d'acces: "+accessLvl;
        }

        private void configDataset()
        {
            DataColumn UserKey_ID = new DataColumn("ID", System.Type.GetType("System.Int16"));
            DataColumn UserName = new DataColumn("UserName", System.Type.GetType("System.String"));
            DataColumn UserPassword = new DataColumn("Password", System.Type.GetType("System.String"));
            DataColumn Access_Id = new DataColumn("Access_ID", System.Type.GetType("System.Int16"));

            DataColumn AccessKey_Id = new DataColumn("E", System.Type.GetType("System.Int16"));
            DataColumn AccessName = new DataColumn("F", System.Type.GetType("System.String"));
            DataColumn AllowCreateID = new DataColumn("G", System.Type.GetType("System.Boolean"));
            DataColumn AllowDestroyID = new DataColumn("H", System.Type.GetType("System.Boolean"));
            DataColumn AllowConfigAlarm = new DataColumn("I", System.Type.GetType("System.Boolean"));
            DataColumn UserCreation = new DataColumn("J", System.Type.GetType("System.Boolean"));

            Local_UserTable.TableName = "Local_UserTable";
            Local_AccessTable.TableName = "Local_AccessTable";

            UserAccount.Tables.Add(Local_UserTable);
            UserAccount.Tables.Add(Local_AccessTable);

            UserKey_ID.AutoIncrement = true;
            UserKey_ID.Unique = true;
            UserKey_ID.ColumnName = "UserKey_ID";
            UserKey_ID.DataType = System.Type.GetType("System.Int32");
            Local_UserTable.Columns.Add(UserKey_ID);

            UserName.AutoIncrement = false;
            UserName.Unique = false;
            UserName.ColumnName = "UserName";
            UserName.DataType = System.Type.GetType("System.String");
            Local_UserTable.Columns.Add(UserName);

            UserPassword.AutoIncrement = false;
            UserPassword.Unique = false;
            UserPassword.ColumnName = "UserPassword";
            UserPassword.DataType = System.Type.GetType("System.String");
            Local_UserTable.Columns.Add(UserPassword);

            Access_Id.AutoIncrement = false;
            Access_Id.Unique = false;
            Access_Id.ColumnName = "Access_Id";
            Access_Id.DataType = System.Type.GetType("System.Int32");
            Local_UserTable.Columns.Add(Access_Id);

            AccessKey_Id.AutoIncrement = true;
            AccessKey_Id.Unique = true;
            AccessKey_Id.ColumnName = "AccessKey_Id";
            AccessKey_Id.DataType = System.Type.GetType("System.Int32");
            Local_AccessTable.Columns.Add(AccessKey_Id);

            AccessName.AutoIncrement = false;
            AccessName.Unique = false;
            AccessName.ColumnName = "AccessName";
            AccessName.DataType = System.Type.GetType("System.String");
            Local_AccessTable.Columns.Add(AccessName);

            AllowCreateID.AutoIncrement = false;
            AllowCreateID.Unique = false;
            AllowCreateID.ColumnName = "AllowCreateID";
            AllowCreateID.DataType = System.Type.GetType("System.Boolean");
            Local_AccessTable.Columns.Add(AllowCreateID);

            AllowDestroyID.AutoIncrement = false;
            AllowDestroyID.Unique = false;
            AllowDestroyID.ColumnName = "AllowDestroyID";
            AllowDestroyID.DataType = System.Type.GetType("System.Boolean");
            Local_AccessTable.Columns.Add(AllowDestroyID);

            AllowConfigAlarm.AutoIncrement = false;
            AllowConfigAlarm.Unique = false;
            AllowConfigAlarm.ColumnName = "AllowConfigAlarm";
            AllowConfigAlarm.DataType = System.Type.GetType("System.Boolean");
            Local_AccessTable.Columns.Add(AllowConfigAlarm);

            UserCreation.AutoIncrement = false;
            UserCreation.Unique = false;
            UserCreation.ColumnName = "UserCreation";
            UserCreation.DataType = System.Type.GetType("System.Boolean");
            Local_AccessTable.Columns.Add(UserCreation);

            DataColumn parentColumn = UserAccount.Tables["Local_AccessTable"].Columns["AccessKey_Id"];
            DataColumn childColumn = UserAccount.Tables["Local_UserTable"].Columns["Access_Id"];

            DataRelation relation = new DataRelation("parent2Child", parentColumn, childColumn);

            UserAccount.Tables["Local_UserTable"].ParentRelations.Add(relation);

        }
    }
}
