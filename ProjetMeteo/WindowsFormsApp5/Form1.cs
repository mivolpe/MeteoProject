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

        public Form1()
        {
            InitializeComponent();
        }

        private void btLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            btStart.Enabled = false;
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.Open();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            btStart.Enabled = true;
            port.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //transfertInList();
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[port.BytesToRead];
            port.Read(data, 0, data.Length);
            transfertInList(data);
        }

        private bool trameComplete (byte[] data)
        {
            //fonction qui verifie si une trame est complète
            bool rep = false;
            int nbreData = 0;

            if (data.Length >= 10) //  taille minium d'une trame
            {
                if (data[0] == 85 && data[1] == 170 && data[2] == 85) //verifie si il y a le début de liste
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

        private void transfertInList(byte[] buffer)
        {
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
                dataInGrid(id, nbreData, type, (int)data, checkSum);
                grid.DataSource = dt;
            }
        }

        private void createGrid ()
        {
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nbre de Data", typeof(int));
            dt.Columns.Add("Type", typeof(int));
            dt.Columns.Add("Data", typeof(int));
            dt.Columns.Add("Checksum", typeof(int));

            grid.DataSource = dt;
            grid.Visible = true;
        }

        private void dataInGrid (int id, int nbreData, int type, int data, int checkSum)
        {
            dt.Rows.Add(new Object[] { id, nbreData, type, data, checkSum });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createGrid();
        }
    }
}
