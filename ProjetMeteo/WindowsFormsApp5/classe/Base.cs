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

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        public int NbreData
        {
            get { return nbreData; }
            set { this.nbreData = value; }
        }
        public int Type
        {
            get { return type; }
            set { this.type = value; }
        }
        public int Data
        {
            get { return data; }
            set { this.data = value; }
        }
        public int CheckSum
        {
            get { return checkSum; }
            set { this.checkSum = value; }
        }
    }
}
