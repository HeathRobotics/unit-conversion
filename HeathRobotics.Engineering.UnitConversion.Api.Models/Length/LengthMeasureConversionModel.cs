using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeathRobotics.Engineering.UnitConversion.Api.Models.Length
{
    public partial class LengthMeasureConversionModel
    {
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public double? Value { get; set; }

        [JsonProperty("prefix", NullValueHandling = NullValueHandling.Ignore)]
        public string Prefix { get; set; }

        [JsonProperty("units", NullValueHandling = NullValueHandling.Ignore)]
        public string Units { get; set; }

        [JsonProperty("target_prefix", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetPrefix { get; set; }

        [JsonProperty("target_units", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetUnits { get; set; }

        [JsonProperty("precision", NullValueHandling = NullValueHandling.Ignore)]
        public int? Precision { get; set; }
    }
}
