using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

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
                    case PrefixUnits.Milli:
                        value = value / 1000.0;
                        break;

                    case PrefixUnits.Kilo:
                        value = value * 1000.0;
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
                    case PrefixUnits.Milli:
                        value = value * 1000.0;
                        break;

                    case PrefixUnits.Kilo:
                        value = value / 1000.0;
                        break;
                }
            }
            return value;
        }
    }
}
