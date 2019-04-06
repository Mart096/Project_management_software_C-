using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaPMS
{
    public class CustomEventArgs
    {
        private int buttonval;

        public int Buttonval { get { return buttonval; } }

        public CustomEventArgs(int val) : base()
        {
            buttonval = val;
        }
    }
}
