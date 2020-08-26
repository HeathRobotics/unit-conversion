using HeathRobotics.Engineering.UnitConversion.Api.Models.Length;
using Newtonsoft.Json;
using System;

namespace HeathRobotics.Engineering.UnitConversion.Api.Models
{
    public static class Serialize
    {
        public static string ToJson(this LengthMeasureConversionModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
