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
        DataTable dt = new DataTable();
        public static String username = "pas connecté";
        public static int accessLvl = 5;
        public static List<Base> trame = new List<Base>();

        public Form1()
        {
            InitializeComponent();
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
    }
}
