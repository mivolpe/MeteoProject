using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class Alarme : Base
    {
        public Alarme(int id, int nbreData, int type, string nameType, int data, int checkSum)
            : base(id, nbreData, type, nameType, data, checkSum)
        { }
    }
}
