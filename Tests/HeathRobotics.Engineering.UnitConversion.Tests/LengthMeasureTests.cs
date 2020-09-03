using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HeathRobotics.Engineering.UnitConversion.Tests
{
    public class LengthMeasureTests
    {
        public LengthMeasureTests()
        {

        }

        [Theory]
        [InlineData(5.0, PrefixUnits.None, LengthUnits.Feet, "5 ft")]
        public void ToStringTest(double value, PrefixUnits prefix, LengthUnits units, string expectedValue)
        {
            var measure = new LengthMeasure()
            {
                Value = value,
                Prefix = prefix,
                Units = units
            };

            var result = measure.ToString();
            Assert.True(!string.IsNullOrWhiteSpace(result));
            Assert.Equal(expectedValue, result);

        }
        
    }
}
