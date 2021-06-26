using Entities.Interfaces;

namespace Entities.Entities
{
    public record Coordinate : ICoordinate
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }

        public Coordinate(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}