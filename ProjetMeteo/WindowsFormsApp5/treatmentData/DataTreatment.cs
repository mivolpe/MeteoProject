using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.treatmentData
{
    class DataTreatment
    {

        private bool trameComplete(byte[] data)
        {
            //fonction qui verifie si une trame est complète
            bool rep = false;
            int nbreData = 0;

            if (data.Length >= 10) //  taille minium d'une trame
            {
                if (data[0] == 85 && data[1] == 170 && data[2] == 85 && ((data[3] < 11 && data[3] >= 0) || (data[3] == 50))) //verifie si il y a le début de liste
                {
                    nbreData = data[4];
                    if (data[7 + nbreData] == 170 && data[8 + nbreData] == 85 && data[9 + nbreData] == 170)//verifie si il y a la fin de liste
                    {
                        rep = true;
                    }
                }
            }
            return rep;
        }

        public void createData(byte[] buffer)
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
                for (int i = 0; i < nbreData; i++)
                {
                    data += (UInt32)(buffer[6 + i]) << i * 8;
                }
                checkSum = buffer[6 + nbreData];
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
                    Form1.trame.Add(new Base(id, nbreData, type, "0", data, checkSum)); 
                }
                if (id > 0 && id < 11)
                {
                    if (id == 1)
                    {
                        Form1.trame.Add(new Mesure(id, nbreData, type, "température", data, checkSum, 0, 0, 0, 0, 0, false));
                    }
                    else if (id == 2)
                    {
                        Form1.trame.Add(new Mesure(id, nbreData, type, "humidité", data, checkSum, 0, 0, 0, 0, 0, false));
                    }
                    else if (id == 3)
                    {
                        Form1.trame.Add(new Mesure(id, nbreData, type, "pression atmosphérique", data, checkSum, 0, 0, 0, 0, 0, false));
                    }
                    else if (id == 4)
                    {
                        Form1.trame.Add(new Mesure(id, nbreData, type, "luminosité", data, checkSum, 0, 0, 0, 0, 0, false));
                    }
                }
                else if (id == 50)
                {
                    Form1.trame.Add(new Alarme(id, nbreData, type, "50", data, checkSum)); 
                }
            }
        }

        private bool verifId(int id, int data, int checkSum)
        {
            //fonction qui regarde si l'id se trouve deja dans la liste d'objet. Si vrai, remplace les valeurs de data et checksum.
            bool rep = true;
            foreach (Base elem in Form1.trame)
            {
                if (elem.Id == id)
                {
                    rep = false;
                    elem.Data = data;
                    elem.CheckSum = checkSum;
                }
            }
            return rep;
        }
    }
}
