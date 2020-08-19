using System;
using System.Collections.Generic;
using System.Text;

namespace HeathRobotics.Engineering.UnitConversion
{
    public class LengthMeasure : BaseMeasure<LengthUnits>
    {

        public override string ToString()
        {
            var prefixDesc = string.Empty;
            switch(this.Prefix)
            {
                case PrefixUnits.Yotta:
                    prefixDesc = "Y";
                    break;
                case PrefixUnits.Zetta:
                    prefixDesc = "Z";
                    break;
                case PrefixUnits.Exa:
                    prefixDesc = "E";
                    break;
                case PrefixUnits.Peta:
                    prefixDesc = "P";
                    break;
                case PrefixUnits.Tera:
                    prefixDesc = "T";
                    break;
                case PrefixUnits.Giga:
                    prefixDesc = "G";
                    break;
                case PrefixUnits.Mega:
                    prefixDesc = "M";
                    break;
                case PrefixUnits.Kilo:
                    prefixDesc = "h";
                    break;
                case PrefixUnits.Hecto:
                    prefixDesc = "h";
                    break;
                case PrefixUnits.Deka:
                    prefixDesc = "da";
                    break;
                case PrefixUnits.Deci:
                    prefixDesc = "d";
                    break;
                case PrefixUnits.Centi:
                    prefixDesc = "c";
                    break;
                case PrefixUnits.Milli:
                    prefixDesc = "m";
                    break;
                case PrefixUnits.Micro:
                    prefixDesc = "µ";
                    break;
                case PrefixUnits.Nano:
                    prefixDesc = "n";
                    break;
                case PrefixUnits.Pico:
                    prefixDesc = "p";
                    break;
                case PrefixUnits.Femto:
                    prefixDesc = "f";
                    break;
                case PrefixUnits.Atto:
                    prefixDesc = "a";
                    break;
                case PrefixUnits.Zepto:
                    prefixDesc = "z";
                    break;
                case PrefixUnits.Yocto:
                    prefixDesc = "y";
                    break;
            }

            var unitDesc = string.Empty;
            switch(this.Units)
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

            var result = $"{this.Value} {prefixDesc}{unitDesc}";
            return result;
        }
    }
}
