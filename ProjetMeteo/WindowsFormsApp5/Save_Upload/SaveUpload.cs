using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5.Save_Upload
{
    class SaveUpload
    {
        public void saveConfig()
        {
            try
            {
                var filePath = "./../../Data.csv";
                using (StreamWriter writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write)))
                {
                    foreach (Base elem in Form1.trame)
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

        public void uploadConfig()
        {
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

                        foreach (Base elem in Form1.trame)
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
    }
}
