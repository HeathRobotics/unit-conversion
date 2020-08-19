using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeathRobotics.Engineering.UnitConversion
{
    public class UnitConversionService : IUnitConversionService
    {
        private readonly ILogger<UnitConversionService> logger;
        private readonly IPrefixConversionService prefixConversionService;

        public UnitConversionService(ILogger<UnitConversionService> logger,
            IPrefixConversionService prefixConversionService)
        {
            this.logger = logger;
            this.prefixConversionService = prefixConversionService;
        }

        public LengthMeasure ConvertLength(LengthMeasure measure, PrefixUnits targetPrefix, LengthUnits targetUnits)
        {
            var si = MeasureToSI(measure);
            var target = SIToMeasure(si.Value, targetPrefix, targetUnits);
            return target;
        }

        private LengthMeasure MeasureToSI(LengthMeasure measure)
        {
            measure.Value = this.prefixConversionService.Convert(measure.Value, measure.Prefix, PrefixUnits.None);

            var siMeasure = new LengthMeasure() { Value = 0.0, Units = LengthUnits.Meters, Prefix = PrefixUnits.None };
            switch(measure.Units)
            {
                case LengthUnits.Meters:
                    siMeasure.Value = measure.Value * 1.0;
                    break;
                case LengthUnits.Feet:
                    siMeasure.Value = measure.Value * 0.3048;
                    break;
            }

            return siMeasure;
        }

        private LengthMeasure SIToMeasure(double value, PrefixUnits targetPrefix, LengthUnits targetUnits)
        {
            var targetMeasure = new LengthMeasure() { Value = 0.0, Units = targetUnits, Prefix = targetPrefix};
            switch (targetUnits)
            {
                case LengthUnits.Meters:
                    targetMeasure.Value = value / 1.0;
                    break;
                case LengthUnits.Feet:
                    targetMeasure.Value = value / 0.3048;
                    break;
            }

            targetMeasure.Value = this.prefixConversionService.Convert(targetMeasure.Value, PrefixUnits.None, targetPrefix);

            return targetMeasure;
        }
    }
}
