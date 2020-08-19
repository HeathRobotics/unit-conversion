using System;
using System.Collections.Generic;
using System.Text;
using HeathRobotics.Engineering.UnitConversion.Extensions;

namespace HeathRobotics.Engineering.UnitConversion
{
    public class LengthMeasure : BaseMeasure<LengthUnits>
    {

        public override string ToString()
        {
            var prefixDesc = this.Prefix.GetLabel();
            var unitDesc = this.Units.GetLabel();
            var result = $"{this.Value} {prefixDesc}{unitDesc}";
            return result;
        }
    }
}
