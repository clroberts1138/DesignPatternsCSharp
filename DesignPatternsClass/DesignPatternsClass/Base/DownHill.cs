using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsClass
{
    public class DownHill : AbstractMountainBike
    {
        public DownHill(IWheel wheel)
            : this(wheel,BikeColor.Red)
        {

        }

        public DownHill(IWheel wheel,BikeColor color)
            : base(wheel,color)
        {

        }
    }
}
