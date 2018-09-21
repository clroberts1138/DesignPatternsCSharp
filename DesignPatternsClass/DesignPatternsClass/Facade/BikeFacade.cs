using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsClass;

namespace Facade
{
    public class BikeFacade
    {
        public virtual void PrepareForSale(IBicycle bicycle)
        {
            Registration reg = new Registration(bicycle);
            reg.AllocateBikeNumber();
            Documentation.PrintBrochure(bicycle);
            bicycle.CleanFrame();
            bicycle.AirTires();
            bicycle.TestRide();
        }
    }
}
