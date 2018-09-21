using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsClass 
{
    public abstract class AbstractRoadBike : AbstractBike
    {
        public AbstractRoadBike(IWheel wheel)
            :this(wheel,BikeColor.Chrome)
        {
        }

        public AbstractRoadBike(IWheel wheel,BikeColor color)
            : base(wheel,color)
        {
        }

        public override decimal Price
        {
            get { return 540.00m; }
        }
    }
}
