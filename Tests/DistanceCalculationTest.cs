using System;
using Program.Interfaces;
using Program.Services;
using Xunit;

namespace Tests
{
    public class DistanceCalculationTest
    {
        [Fact]
        public void TestCalculationWithCorrectData()
        {
            IParser parser = new ParserService("5x5 (0, 0) (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)");
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            calculator.GetRoute();
        }

        [Fact]
        public void TestCalculationWithInCorrectData()
        {
            IParser parser = new ParserService("sdkjlhrknvsrkykjdgsdjfgknsdglds");
            IDistanceCalculator calculator = new DistanceCalculationService(parser);
            Assert.ThrowsAny<Exception>(calculator.GetRoute);
        }
    }
}