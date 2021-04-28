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

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        DataSet UserAccount = new DataSet();
        DataTable dt = new DataTable();
        public static List<Base> trame = new List<Base>();

        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;"
                        +
                        @"Data Source=..\..\DB_UserAccess.accdb;Cache Authentication=True";

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
            dataInGrid();
            grid.DataSource = dt;
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //cette fonction récolte les données mesurées sur le port
            byte[] data = new byte[port.BytesToRead];
            port.Read(data, 0, data.Length);
            createData(data);
        }

        private bool trameComplete (byte[] data)
        {
            //fonction qui verifie si une trame est complète
            bool rep = false;
            int nbreData = 0;

            if (data.Length >= 10) //  taille minium d'une trame
            {
                if (data[0] == 85 && data[1] == 170 && data[2] == 85 && ((data[3] < 11  && data[3] >= 0) || (data[3] == 50))) //verifie si il y a le début de liste
                {
                    nbreData = data[4];
                    if (data[7+nbreData] == 170 && data[8 + nbreData] == 85 && data[9 + nbreData] == 170)//verifie si il y a la fin de liste
                    {
                        rep = true;
                    }
                }
            }
            return rep;
        }

        private void createData(byte[] buffer)
        {
            //cette fontion sépare chaque donnée 
            int id = 0;
            int nbreData = 0;
            int type = 0;
            UInt32 data = 0;
            int checkSum = 0;

            if (trameComplete(buffer))
            {
                id = buffer[3];
                nbreData = buffer[4];
                type = buffer[5];
                for(int i = 0; i < nbreData; i++)
                {
                    data += (UInt32)(buffer[6 + i]) << i * 8;
                }
                checkSum = buffer[6+nbreData];
                insertInObject(id, nbreData, type, (int)data, checkSum);
            }
        }

        private void insertInObject(int id, int nbreData, int type, int data, int checkSum)
        {
            //cette fontion ajoute les trames dans chaque classe en fonction de l'id
            if (verifId(id, data, checkSum))
            {
                if (id == 0)
                {
                    trame.Add(new Base(id, nbreData, type, "0", data, checkSum)); // à definir le type
                }
                if (id > 0 && id < 11)
                {
                    if (id == 1)
                    {
                        trame.Add(new Mesure(id, nbreData, type, "température", data, checkSum, 0, 0, 0, 0, 0, false));
                    }
                    else if (id == 2)
                    {
                        trame.Add(new Mesure(id, nbreData, type, "humidité", data, checkSum, 0, 0, 0, 0, 0, false));
                    }
                    else if (id == 3)
                    {
                        trame.Add(new Mesure(id, nbreData, type, "pression atmosphérique", data, checkSum, 0, 0, 0, 0, 0, false));
                    }
                    else if (id == 4)
                    {
                        trame.Add(new Mesure(id, nbreData, type, "luminosité", data, checkSum, 0, 0, 0, 0, 0, false));
                    }                  
                }
                else if (id == 50)
                {
                    trame.Add(new Alarme(id, nbreData, type,"50", data, checkSum)); // à définir le type
                }
            }
        }

        private bool verifId (int id, int data, int checkSum)
        {
            //fonction qui regarde si l'id se trouve deja dans la liste d'objet. Si vrai, remplace les valeurs de data et checksum.
            bool rep = true;
            foreach (Base elem in trame)
            {
                if(elem.Id == id)
                {
                    rep = false;
                    elem.Data = data;
                    elem.CheckSum = checkSum;
                }
            }
            return rep;
        }

        private void dataInGrid ()
        {
            //cette fonction affiche la liste de trame dans un datagridview. Remplace la valeur du date et checksum si les id sont égaux
            //ajoute une ligne si l'id n'est pas présent dans le grid

            foreach (Base elem in trame)
            {
                bool check = false;
                if( dt.Rows.Count == 0)
                {
                    dt.Columns.Add("Id", typeof(int));
                    dt.Columns.Add("Configuration", typeof(string));
                    dt.Columns.Add("Type", typeof(string));
                    dt.Columns.Add("Data", typeof(int));
                    dt.Columns.Add("Délai (en seconde)", typeof(int));
                    dt.Columns.Add("Alarme", typeof(string));
                    dt.Rows.Add(elem.Id, elem.isConfigurate(),elem.NameType, elem.Data, 1,elem.defId0());
                }
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Id"].Equals(elem.Id))
                    {
                        if (!elem.IsConverted) 
                        { 
                            row["Data"] = elem.Data;
                        }
                        else
                        {
                            row["Configuration"] = ((Mesure)elem).isConfigurate();
                            row["Data"] = ((Mesure)elem).conversing();
                            row["Alarme"] = ((Mesure)elem).limitAlarm();
                        }
                        check = true;
                    }
                }

                if(!check)
                {
                    dt.Rows.Add(elem.Id, elem.isConfigurate(), elem.NameType, elem.Data, 1, elem.defId0());
                }
            }
        }

        private void btConversing_Click(object sender, EventArgs e)
        {
            // cette fonction ajoute l'intervalle min - max et l'alarme min - max à l'id correspondant
            foreach(Base elem in trame)
            {
                if (elem.Id == nUDId.Value)
                {
                    ((Mesure)elem).ValMin = (int) nUDMin.Value;
                    ((Mesure)elem).ValMax = (int) nUDMax.Value;
                    ((Mesure)elem).AlarmMin = (int)nUDAlarmMin.Value;
                    ((Mesure)elem).AlarmMax = (int)nUDAlarmMax.Value;
                    elem.IsConverted = true;
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //cette fontion sauvegarde les paramètres entrés pour chaque ID dans un csv
            try
            {
                var filePath = "./../../Data.csv";
                using (StreamWriter writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write)))
                {
                    foreach (Base elem in trame)
                    {
                        if (elem.IsConverted)
                        {
                            writer.WriteLine(elem.Id + "," + ((Mesure)elem).ValMin + "," + ((Mesure)elem).ValMax + "," + ((Mesure)elem).AlarmMin + "," + ((Mesure)elem).AlarmMax);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            //cette fonction charge les paramètres qui sont dans un fichiers csv
            try
            {
                var filePath = "./../../Data.csv";
                using (var reader = new StreamReader(filePath))
                {
                    List<string> listConfig = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        foreach (Base elem in trame)
                        {
                            if (elem.Id == int.Parse(values[0]))
                            {
                                ((Mesure)elem).ValMin = int.Parse(values[1]);
                                ((Mesure)elem).ValMax = int.Parse(values[2]);
                                ((Mesure)elem).AlarmMin = int.Parse(values[3]);
                                ((Mesure)elem).AlarmMax = int.Parse(values[4]);
                                elem.IsConverted = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createDataSet()
        {
            
            DataColumn dcUserID;
            DataColumn dcAccessID;

            //creation de la table UserTable
            DataTable UserTable = UserAccount.Tables.Add("UserTable");
            UserTable.Columns.Add("ID", typeof(Int32));
            UserTable.Columns.Add("UserName", typeof(string));
            UserTable.Columns.Add("UserPassword", typeof(string));
            UserTable.Columns.Add("AccessID", typeof(Int32));

            //creation de la table AccessTable
            DataTable AccessTable = UserAccount.Tables.Add("AccessTable");
            AccessTable.Columns.Add("ID", typeof(Int32));
            AccessTable.Columns.Add("Name", typeof(string));
            AccessTable.Columns.Add("AllowCreateID", typeof(bool));
            AccessTable.Columns.Add("AllowDestroyID", typeof(bool));
            AccessTable.Columns.Add("AllowConfigAlarm", typeof(bool));
            AccessTable.Columns.Add("UserCreation", typeof(Int32));

            //reation des clés primaire + relation entre table
            UserTable.PrimaryKey = new DataColumn[] { UserTable.Columns["ID"] };
            AccessTable.PrimaryKey = new DataColumn[] { AccessTable.Columns["ID"] };
            UserAccount.Relations.Add("UserAccess", UserTable.Columns["AccessID"], AccessTable.Columns["ID"]);
            
            //creation de la clé étrangère
            dcUserID = UserAccount.Tables["UserTable"].Columns["ID"];
            dcAccessID = UserAccount.Tables["AccessTable"].Columns["ID"];
            ForeignKeyConstraint foreignKeyConstraint = new ForeignKeyConstraint(dcUserID, dcUserID);

            //contrainte de la table UserTable
            UserTable.Columns["UserName"].Unique = true;
            UserTable.Columns["UserName"].AllowDBNull = false;

            //contrainte de la table AccessTable
            AccessTable.Columns["Name"].AllowDBNull = false;
            AccessTable.Columns["AllowCreateID"].AllowDBNull = false;
            AccessTable.Columns["AllowDestroyID"].AllowDBNull = false;
            AccessTable.Columns["AllowConfigAlarm"].AllowDBNull = false;
            AccessTable.Columns["UserCreation"].AllowDBNull = false;

            dataAccessTable(AccessTable);
        }

        private void dataAccessTable(DataTable AccessTable)
        {
            AccessTable.Rows.Add(0, "AdminRights", true, true, true, true);
            AccessTable.Rows.Add(1, "MasterRights", true, true, true, false);
            AccessTable.Rows.Add(2, "MiddleRights", true, false, true, false);
            AccessTable.Rows.Add(3, "BasicRights", false, false, true, false);
            AccessTable.Rows.Add(4, "NoRights", false, false, false, false);
        }
    }
}
