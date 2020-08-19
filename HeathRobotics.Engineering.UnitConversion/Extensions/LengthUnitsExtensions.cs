using System;
using System.Collections.Generic;
using System.Text;

namespace HeathRobotics.Engineering.UnitConversion.Extensions
{
    public static class LengthUnitsExtensions
    {
        public static string GetLabel(this LengthUnits units)
        {
            var unitDesc = string.Empty;
            switch (units)
            {
                case LengthUnits.Meters:
                    unitDesc = "m";
                    break;
                case LengthUnits.Feet:
                    unitDesc = "ft";
                    break;
                case LengthUnits.Miles:
                    unitDesc = "mi";
                    break;
                case LengthUnits.Yards:
                    unitDesc = "yd";
                    break;
            }
            return unitDesc;
        }
    }
}
