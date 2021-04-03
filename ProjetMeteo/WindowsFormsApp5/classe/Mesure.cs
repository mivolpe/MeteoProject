using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class Mesure : Base
    {
        protected int valMin;
        protected int valMax;
        protected int alarmMin;
        protected int alarmMax;
        protected int dataConvert;


        public Mesure(int id, int nbreData, int type, string nameType, int data, int checkSum, int valMin, int valMax, int alarmMin, int alarmMax, int dataConvert, bool isConverted)
            : base(id, nbreData, type, nameType, data, checkSum)
        {
            this.valMin = valMin;
            this.valMax = valMax;
            this.alarmMin = alarmMin;
            this.alarmMax = alarmMax;
            this.dataConvert = dataConvert;
            this.isConverted = isConverted;
        }

        public int ValMin
        {
            get { return valMin; }
            set { this.valMin = value; }
        }
        public int ValMax
        {
            get { return valMax; }
            set { this.valMax = value; }
        }
        public int AlarmMin
        {
            get { return alarmMin; }
            set { this.alarmMin = value; }
        }
        public int AlarmMax
        {
            get { return alarmMax; }
            set { this.alarmMax = value; }
        }
        public int DataConvert
        {
            get { return dataConvert; }
            set { this.dataConvert = value; }
        }

        public int conversing()
        {
            double division;

            division = data / (Math.Pow(2, nbreData * 8) - 1);
            dataConvert = (int)(division * (valMax - valMin) + valMin);

            return dataConvert;
        }

        public string  limitAlarm()
        {
            string rep = "";

            if (isConverted)
            {
                if (dataConvert < alarmMin)
                {
                    rep = "Basse";
                }
                else if (dataConvert > alarmMax)
                {
                    rep = "Haute";
                }
            }
            return rep;
        }


    }
}
