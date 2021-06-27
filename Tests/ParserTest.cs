using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Entities;
using Program.Interfaces;
using Program.Services;
using Xunit;

namespace Tests
{
    public class ParserTest
    {
        [Fact]
        public void PointsParseTest()
        {
            var parserService =
                new ParserService("5x5 (0, 0) (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)");
            IEnumerable<Coordinate> coordinates = new List<Coordinate>
            {
                new() {XCoordinate = 0, YCoordinate = 0},
                new() {XCoordinate = 1, YCoordinate = 3},
                new() {XCoordinate = 4, YCoordinate = 4},
                new() {XCoordinate = 4, YCoordinate = 2},
                new() {XCoordinate = 4, YCoordinate = 2},
                new() {XCoordinate = 0, YCoordinate = 1},
                new() {XCoordinate = 3, YCoordinate = 2},
                new() {XCoordinate = 2, YCoordinate = 3},
                new() {XCoordinate = 4, YCoordinate = 1}
            };
            Assert.True(!parserService.Coordinates.Except(coordinates).Any());
        }

        [Fact]
        public void FieldParseTest()
        {
            IParser parserService = new ParserService("5x5");
            var parsedField = parserService.Field;
            var correctField = new Field
            {
                XSize = 5,
                YSize = 5
            };
            Assert.Equal(parsedField, correctField);
        }

        [Fact]
        public void PointsParseWithIncorrectDataTest()
        {
            IParser parserService =
                new ParserService("dgfhdfghdfghdfghdfhfgh");
            Assert.ThrowsAny<Exception>(() =>
            {
                var _ = parserService.Coordinates;
                var count = _.Count;
            });
        }

        [Fact]
        public void FieldParseWithIncorrectDataTest()
        {
            IParser parserService =
                new ParserService("rtwhwrthwr");
            Assert.ThrowsAny<Exception>(() =>
            {
                var _ = parserService.Field;
                var x = _.XSize;
            });
        }
    }
}