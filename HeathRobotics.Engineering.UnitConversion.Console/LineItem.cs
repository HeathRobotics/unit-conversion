using System;
using System.Collections.Generic;
using System.Text;

namespace HeathRobotics.Engineering.UnitConversion.Console
{
    public class LineItem<T1>
    {
        public double OrigValue { get; set; }
        public PrefixUnits OrigPrefix { get; set; }
        public T1 OrigUnits { get; set; }
        public PrefixUnits TargetPrefix { get; set; }
        public T1 TargetUnits { get; set; }
        public int Precision { get; set; }
        public string ExpectedValue { get; set; }
    }
}
