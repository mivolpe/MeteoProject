using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.treatmentData
{
    class DisplayData
    {
        public DataTable dataInGrid(DataTable dt)
        {
            //cette fonction affiche la liste de trame dans un datagridview. Remplace la valeur du date et checksum si les id sont égaux
            //ajoute une ligne si l'id n'est pas présent dans le grid

            foreach (Base elem in Form1.trame)
            {
                bool check = false;
                if (dt.Rows.Count == 0)
                {
                    dt.Columns.Add("Id", typeof(int));
                    dt.Columns.Add("Configuration", typeof(string));
                    dt.Columns.Add("Type", typeof(string));
                    dt.Columns.Add("Data", typeof(int));
                    dt.Columns.Add("Délai (en seconde)", typeof(int));
                    dt.Columns.Add("Alarme", typeof(string));
                    dt.Rows.Add(elem.Id, elem.isConfigurate(), elem.NameType, elem.Data, 1, elem.defId0());
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

                if (!check)
                {
                    dt.Rows.Add(elem.Id, elem.isConfigurate(), elem.NameType, elem.Data, 1, elem.defId0());
                }
            }
            return dt;
        }
    }
}
