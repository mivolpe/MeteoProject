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

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        List<Base> trame = new List<Base>();

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
            if (verifId(id, nbreData, type, data, checkSum))
            {
                if (id == 0)
                {
                    trame.Add(new Base(id, nbreData, type, data, checkSum));
                }
                if (id > 0 && id < 11)
                {
                    trame.Add(new Mesure(id, nbreData, type, data, checkSum));
                }
                else if (id == 50)
                {
                    trame.Add(new Alarme(id, nbreData, type, data, checkSum));
                }
            }
            
        }
        private bool verifId (int id, int nbreData, int type, int data, int checkSum)
        {
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

            foreach (Base elem in trame)
            {
                bool check = false;
                if( dt.Rows.Count == 0)
                {
                    dt.Columns.Add("Id", typeof(int));
                    dt.Columns.Add("Nbre de Data", typeof(int));
                    dt.Columns.Add("Type", typeof(int));
                    dt.Columns.Add("Data", typeof(int));
                    dt.Columns.Add("Checksum", typeof(int));
                    dt.Rows.Add(elem.Id, elem.NbreData, elem.Type, elem.Data, elem.CheckSum);

                }
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Id"].Equals(elem.Id))
                    {
                        row["Data"] = elem.Data;
                        row["CheckSum"] = elem.CheckSum;
                        check = true;
                    }
                }

                if(!check)
                {
                    dt.Rows.Add(elem.Id, elem.NbreData, elem.Type, elem.Data, elem.CheckSum);
                }
            }

        }
    }
}
