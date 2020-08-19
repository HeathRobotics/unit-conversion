using Microsoft.Extensions.Logging;
using System;

namespace HeathRobotics.Engineering.UnitConversion
{
    public class LengthUnitConversionService : IUnitConversionService<LengthMeasure, LengthUnits>
    {
        private readonly ILogger<LengthUnitConversionService> logger;
        private readonly IPrefixConversionService prefixConversionService;

        public LengthUnitConversionService(ILogger<LengthUnitConversionService> logger,
            IPrefixConversionService prefixConversionService)
        {
            this.logger = logger;
            this.prefixConversionService = prefixConversionService;
        }

        public LengthMeasure Convert(LengthMeasure measure, PrefixUnits targetPrefix, LengthUnits targetUnits, int precision)
        {
            var si = ToSI(measure);
            var target = FromSI(si.Value, targetPrefix, targetUnits);
            target.Value = Math.Round(target.Value, precision);
            return target;
        }

        private LengthMeasure ToSI(LengthMeasure measure)
        {
            measure.Value = this.prefixConversionService.Convert(measure.Value, measure.Prefix, PrefixUnits.None);

            var siMeasure = new LengthMeasure() { Value = 0.0, Units = LengthUnits.Meters, Prefix = PrefixUnits.None };
            switch (measure.Units)
            {
                case LengthUnits.Meters:
                    siMeasure.Value = measure.Value * 1.0;
                    break;
                case LengthUnits.Feet:
                    siMeasure.Value = measure.Value * 0.3048;
                    break;
                case LengthUnits.Miles:
                    siMeasure.Value = measure.Value * 1609.344;
                    break;
                case LengthUnits.Yards:
                    siMeasure.Value = measure.Value * 0.9144;
                    break;
            }

            return siMeasure;
        }

        private LengthMeasure FromSI(double value, PrefixUnits targetPrefix, LengthUnits targetUnits)
        {
            var targetMeasure = new LengthMeasure() { Value = 0.0, Units = targetUnits, Prefix = targetPrefix };
            switch (targetUnits)
            {
                case LengthUnits.Meters:
                    targetMeasure.Value = value / 1.0;
                    break;
                case LengthUnits.Feet:
                    targetMeasure.Value = value / 0.3048;
                    break;
                case LengthUnits.Miles:
                    targetMeasure.Value = value / 1609.344;
                    break;
                case LengthUnits.Yards:
                    targetMeasure.Value = value / 0.9144;
                    break;
            }

            targetMeasure.Value = this.prefixConversionService.Convert(targetMeasure.Value, PrefixUnits.None, targetPrefix);

            return targetMeasure;
        }
    }
}
