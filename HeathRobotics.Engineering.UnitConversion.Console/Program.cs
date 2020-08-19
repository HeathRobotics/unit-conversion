using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;

namespace HeathRobotics.Engineering.UnitConversion.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var mockPrefixLogger = new Mock<ILogger<PrefixConversionService>>();
            var prefixConversionService = new PrefixConversionService(mockPrefixLogger.Object);

            var mockLengthLogger = new Mock<ILogger<LengthUnitConversionService>>();
            var lengthUnitConversionService = new LengthUnitConversionService(mockLengthLogger.Object, prefixConversionService);

            var mockLogger = new Mock<ILogger<UnitConversionService>>();
            var unitConversionService = new UnitConversionService(mockLogger.Object, lengthUnitConversionService);

            var lineItems = new List<LineItem<LengthUnits>>();
            var li1 = new LineItem<LengthUnits>()
            {
                OrigValue = 5.0,
                OrigPrefix = PrefixUnits.None,
                OrigUnits = LengthUnits.Feet,
                TargetPrefix = PrefixUnits.None,
                TargetUnits = LengthUnits.Meters,
                Precision = 3,
                ExpectedValue = "1.524 m"

            };
            lineItems.Add(li1);

            foreach (var lineItem in lineItems)
            {

                var origMeasure = new LengthMeasure() { Value = lineItem.OrigValue, Prefix = lineItem.OrigPrefix, Units = lineItem.OrigUnits };
                var targetMeasure = unitConversionService.ConvertLength(origMeasure, lineItem.TargetPrefix, lineItem.TargetUnits, lineItem.Precision);

                System.Console.WriteLine($"Original value: {origMeasure.ToString()}");
                System.Console.WriteLine($"Converted value: {targetMeasure.ToString()}.");
                System.Console.WriteLine($"Expected value: {lineItem.ExpectedValue}.");
                System.Console.WriteLine("------------------------------------------------------------");
            }

            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
