using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsClass
{
    public class UltraWheel
    {
        private int size;

        public UltraWheel(int size)
        {
            this.size = size;
        }

        public virtual int WheelSize
        {
            get { return size; }
        }

        public override string ToString()
        {
            return "ULTRA WHEEL " + size;
        }
    }
}
