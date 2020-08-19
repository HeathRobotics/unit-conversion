using Microsoft.Extensions.Logging;
using System;

namespace HeathRobotics.Engineering.UnitConversion
{
    public class PrefixConversionService : IPrefixConversionService
    {
        private readonly ILogger<PrefixConversionService> logger;

        public PrefixConversionService(ILogger<PrefixConversionService> logger)
        {
            this.logger = logger;
        }

        public double Convert(double value, PrefixUnits sourcePrefix, PrefixUnits targetPrefix)
        {
            var siValue = ToSI(value, sourcePrefix);
            var targetValue = FromSI(siValue, targetPrefix);
            return targetValue;
        }

        private double ToSI(double value, PrefixUnits sourcePrefix)
        {
            if (sourcePrefix != PrefixUnits.None)
            {
                switch (sourcePrefix)
                {
                    case PrefixUnits.Yotta:
                        value = value * Math.Pow(10.0, 24);
                        break;
                    case PrefixUnits.Zetta:
                        value = value * Math.Pow(10.0, 21);
                        break;
                    case PrefixUnits.Exa:
                        value = value * Math.Pow(10.0, 18);
                        break;
                    case PrefixUnits.Peta:
                        value = value * Math.Pow(10.0, 15);
                        break;
                    case PrefixUnits.Tera:
                        value = value * Math.Pow(10.0, 12);
                        break;
                    case PrefixUnits.Giga:
                        value = value * Math.Pow(10.0, 9);
                        break;
                    case PrefixUnits.Mega:
                        value = value * Math.Pow(10.0, 6);
                        break;
                    case PrefixUnits.Kilo:
                        value = value * Math.Pow(10.0, 3);
                        break;
                    case PrefixUnits.Hecto:
                        value = value * Math.Pow(10.0, 2);
                        break;
                    case PrefixUnits.Deka:
                        value = value * 10.0;
                        break;
                    case PrefixUnits.Deci:
                        value = value / 10.0;
                        break;
                    case PrefixUnits.Centi:
                        value = value / 100.0;
                        break;
                    case PrefixUnits.Milli:
                        value = value / Math.Pow(10.0, 3);
                        break;
                    case PrefixUnits.Micro:
                        value = value / Math.Pow(10.0, 6);
                        break;
                    case PrefixUnits.Nano:
                        value = value / Math.Pow(10.0, 9);
                        break;
                    case PrefixUnits.Pico:
                        value = value / Math.Pow(10.0, 12);
                        break;
                    case PrefixUnits.Femto:
                        value = value / Math.Pow(10.0, 15);
                        break;
                    case PrefixUnits.Atto:
                        value = value / Math.Pow(10.0, 18);
                        break;
                    case PrefixUnits.Zepto:
                        value = value / Math.Pow(10.0, 21);
                        break;
                    case PrefixUnits.Yocto:
                        value = value / Math.Pow(10.0, 24);
                        break;

                }
            }
            return value;
        }

        private double FromSI(double value, PrefixUnits targetPrefix)
        {
            if (targetPrefix != PrefixUnits.None)
            {
                switch (targetPrefix)
                {
                    case PrefixUnits.Yotta:
                        value = value / Math.Pow(10.0, 24);
                        break;
                    case PrefixUnits.Zetta:
                        value = value / Math.Pow(10.0, 21);
                        break;
                    case PrefixUnits.Exa:
                        value = value / Math.Pow(10.0, 18);
                        break;
                    case PrefixUnits.Peta:
                        value = value / Math.Pow(10.0, 15);
                        break;
                    case PrefixUnits.Tera:
                        value = value / Math.Pow(10.0, 12);
                        break;
                    case PrefixUnits.Giga:
                        value = value / Math.Pow(10.0, 9);
                        break;
                    case PrefixUnits.Mega:
                        value = value / Math.Pow(10.0, 6);
                        break;
                    case PrefixUnits.Kilo:
                        value = value / Math.Pow(10.0, 3);
                        break;
                    case PrefixUnits.Hecto:
                        value = value / Math.Pow(10.0, 2);
                        break;
                    case PrefixUnits.Deka:
                        value = value / 10.0;
                        break;
                    case PrefixUnits.Deci:
                        value = value * 10.0;
                        break;
                    case PrefixUnits.Centi:
                        value = value * 100.0;
                        break;
                    case PrefixUnits.Milli:
                        value = value * Math.Pow(10.0, 3);
                        break;
                    case PrefixUnits.Micro:
                        value = value * Math.Pow(10.0, 6);
                        break;
                    case PrefixUnits.Nano:
                        value = value * Math.Pow(10.0, 9);
                        break;
                    case PrefixUnits.Pico:
                        value = value * Math.Pow(10.0, 12);
                        break;
                    case PrefixUnits.Femto:
                        value = value * Math.Pow(10.0, 15);
                        break;
                    case PrefixUnits.Atto:
                        value = value * Math.Pow(10.0, 18);
                        break;
                    case PrefixUnits.Zepto:
                        value = value * Math.Pow(10.0, 21);
                        break;
                    case PrefixUnits.Yocto:
                        value = value * Math.Pow(10.0, 24);
                        break;

                }
            }
            return value;
        }
    }
}
