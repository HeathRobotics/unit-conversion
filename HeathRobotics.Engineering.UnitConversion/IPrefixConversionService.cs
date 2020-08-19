
namespace HeathRobotics.Engineering.UnitConversion
{
    public interface IPrefixConversionService
    {
        double Convert(double value, PrefixUnits sourcePrefix, PrefixUnits targetPrefix);
    }
}
