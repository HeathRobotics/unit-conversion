using System;
using System.Collections.Generic;
using System.Text;

namespace HeathRobotics.Engineering.UnitConversion
{
    public class LengthMeasure
    {
        public double Value { get; set; }
        public PrefixUnits Prefix { get; set; }
        public LengthUnits Units { get; set; }
    }
}
