using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsClass;

namespace Observer
{
    public class Speedometer
    {

        public event EventHandler ValueChanged;
        private int _currentSpeed;

        public Speedometer()
        {
            _currentSpeed = 0;
        }

        public virtual int CurrentSpeed
        {
            set
            {
                this._currentSpeed = value;
                OnValueChanged();
            }

            get
            {
                return _currentSpeed;
            }
        }

        protected void OnValueChanged()
        {
            if(ValueChanged != null)
            {
                ValueChanged(this, EventArgs.Empty);
            }
        }






    }
}
