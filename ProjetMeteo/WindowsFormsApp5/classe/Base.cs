using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class Base
    {
        private int id;
        private int nbreData;
        private int type;
        private int data;
        private int checkSum;

        public Base(int id, int nbreData, int type, int data, int checkSum)
        {
            this.id = id;
            this.nbreData = nbreData;
            this.type = type;
            this.data = data;
            this.checkSum = checkSum;
        }

        public int getId
        {
            get { return id; }
        }
        public int getNbreData
        {
            get { return nbreData; }
        }
        public int getType
        {
            get { return type; }
        }
        public int getData
        {
            get { return data; }
        }
        public int getCheckSum
        {
            get { return checkSum; }
        }
    }
}
