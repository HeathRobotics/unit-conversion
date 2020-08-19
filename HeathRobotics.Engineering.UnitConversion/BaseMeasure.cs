using System;
using System.Collections.Generic;
using System.Text;

namespace HeathRobotics.Engineering.UnitConversion
{
    public abstract class BaseMeasure<T1>
    {
        public double Value { get; set; }
        public PrefixUnits Prefix { get; set; }
        public T1 Units { get; set; }
    }
}
