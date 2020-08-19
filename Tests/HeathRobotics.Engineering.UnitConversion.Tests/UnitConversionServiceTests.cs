using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace HeathRobotics.Engineering.UnitConversion.Tests
{
    public class UnitConversionServiceTests
    {
        private readonly IUnitConversionService unitConversionService;

        public UnitConversionServiceTests()
        {
            var mockPrefixLogger = new Mock<ILogger<PrefixConversionService>>();
            var prefixConversionService = new PrefixConversionService(mockPrefixLogger.Object);

            var mockLogger = new Mock<ILogger<UnitConversionService>>();
            this.unitConversionService = new UnitConversionService(mockLogger.Object, prefixConversionService);
        }

        [Theory]
        [InlineData(5.0, PrefixUnits.None, LengthUnits.Feet, PrefixUnits.None, LengthUnits.Meters, 3, 1.524)]
        public void ConvertTest(double origValue, PrefixUnits origPrefix, LengthUnits origUnits,
            PrefixUnits targetPrefix, LengthUnits targetUnits, int precision, double expectedValue)
        {
            var origMeasure = new LengthMeasure() { Value = origValue, Prefix = origPrefix, Units = origUnits };
            var targetMeasure = this.unitConversionService.ConvertLength(origMeasure, targetPrefix, targetUnits);

            Assert.NotNull(targetMeasure);
            Assert.Equal(Math.Round(expectedValue, precision), targetMeasure.Value);
        }
    }
}
