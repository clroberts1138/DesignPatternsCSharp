using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsClass;

namespace Adapter
{
    public class UltraWheelAdapter : AbstractWheel
    {
        public UltraWheelAdapter(UltraWheel ultrawheel) 
            :base(ultrawheel.WheelSize, false)
        {

        }
    }
}
