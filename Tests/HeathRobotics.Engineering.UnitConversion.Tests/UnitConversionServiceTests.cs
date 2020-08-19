using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HeathRobotics.Engineering.UnitConversion.Tests
{
    public class UnitConversionServiceTests
    {
        private readonly IAggregateUnitConversionService unitConversionService;

        public UnitConversionServiceTests()
        {
            var mockPrefixLogger = new Mock<ILogger<PrefixConversionService>>();
            var prefixConversionService = new PrefixConversionService(mockPrefixLogger.Object);

            var mockLengthLogger = new Mock<ILogger<LengthUnitConversionService>>();
            var lengthUnitConversionService = new LengthUnitConversionService(mockLengthLogger.Object, prefixConversionService);

            var mockLogger = new Mock<ILogger<UnitConversionService>>();
            this.unitConversionService = new UnitConversionService(mockLogger.Object, lengthUnitConversionService);
        }

        [Theory]
        [InlineData(5.0, PrefixUnits.None, LengthUnits.Feet, PrefixUnits.None, LengthUnits.Meters, 3, 1.524)]
        [InlineData(5280.0, PrefixUnits.None, LengthUnits.Feet, PrefixUnits.None, LengthUnits.Meters, 3, 1609.344)]
        [InlineData(5280.0, PrefixUnits.None, LengthUnits.Feet, PrefixUnits.Kilo, LengthUnits.Meters, 6, 1.609344)]
        public void ConvertTest(double origValue, PrefixUnits origPrefix, LengthUnits origUnits,
            PrefixUnits targetPrefix, LengthUnits targetUnits, int precision, double expectedValue)
        {
            var origMeasure = new LengthMeasure() { Value = origValue, Prefix = origPrefix, Units = origUnits };
            var targetMeasure = this.unitConversionService.ConvertLength(origMeasure, targetPrefix, targetUnits, precision);

            Assert.NotNull(targetMeasure);
            Assert.Equal(expectedValue, targetMeasure.Value);
        }
    }
}
