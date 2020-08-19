using Microsoft.Extensions.Logging;
using System;

namespace HeathRobotics.Engineering.UnitConversion
{
    public class UnitConversionService : IAggregateUnitConversionService
    {
        private readonly ILogger<UnitConversionService> logger;
        private readonly IUnitConversionService<LengthMeasure, LengthUnits> lengthUnitConversionService;

        public UnitConversionService(ILogger<UnitConversionService> logger,
            IUnitConversionService<LengthMeasure, LengthUnits> lengthUnitConversionService
            )
        {
            this.logger = logger;
            this.lengthUnitConversionService = lengthUnitConversionService;
        }

        public LengthMeasure ConvertLength(LengthMeasure measure, PrefixUnits targetPrefix, LengthUnits targetUnits, int precision)
        {
            return this.lengthUnitConversionService.Convert(measure, targetPrefix, targetUnits, precision);
        }
    }
}
