using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.treatmentData
{
    class ConvertingData
    {
        public void conversingData(int id, int intMin, int intMax, int alarmMin, int alarmMax)
        {
            // cette fonction ajoute l'intervalle min - max et l'alarme min - max à l'id correspondant

            foreach (Base elem in Form1.trame)
            {
                if (elem.Id == id)
                {
                    ((Mesure)elem).ValMin = (int)intMin;
                    ((Mesure)elem).ValMax = (int)intMax;
                    ((Mesure)elem).AlarmMin = (int)alarmMin;
                    ((Mesure)elem).AlarmMax = (int)alarmMax;
                    elem.IsConverted = true;
                }
            }
        }
    }
}
