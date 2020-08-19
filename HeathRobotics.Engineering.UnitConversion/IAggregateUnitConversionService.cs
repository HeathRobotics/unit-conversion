using System;
using System.Collections.Generic;
using System.Text;

namespace HeathRobotics.Engineering.UnitConversion
{
    public interface IAggregateUnitConversionService
    {
        LengthMeasure ConvertLength(LengthMeasure measure, PrefixUnits targetPrefix, LengthUnits targetUnits, int precision);
    }
}
