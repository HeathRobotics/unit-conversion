using System;

namespace HeathRobotics.Engineering.UnitConversion
{
    public interface IUnitConversionService
    {
        LengthMeasure ConvertLength(LengthMeasure measure, PrefixUnits targetPrefix, LengthUnits targetUnits);
    }
}
