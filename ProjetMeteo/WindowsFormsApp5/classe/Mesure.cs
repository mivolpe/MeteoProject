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
        protected int dataConvert;


        public Mesure(int id, int nbreData, int type, int data, int checkSum, int valMin, int valMax, int dataConvert, bool isConverted)
            : base(id, nbreData, type, data, checkSum)
        {
            this.valMin = valMin;
            this.valMax = valMax;
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
    }
}
