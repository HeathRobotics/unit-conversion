
namespace HeathRobotics.Engineering.UnitConversion
{
    public interface IUnitConversionService<T1, T2> where T1 : BaseMeasure<T2>
    {
        T1 Convert(T1 measure, PrefixUnits targetPrefix, T2 targetUnits, int precision);
    }
}
