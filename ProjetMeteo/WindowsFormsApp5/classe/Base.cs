﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class Base
    {
        protected int id;
        protected int nbreData;
        protected int type;
        protected int data;
        protected int checkSum;
        protected bool isConverted;

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
        public bool IsConverted
        {
            get { return isConverted; }
            set { this.isConverted = value; }
        }
    }
}