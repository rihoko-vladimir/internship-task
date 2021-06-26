using Entities.Interfaces;

namespace Entities.Entities
{
    public record StopPoint : IStopPoint
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }

        public StopPoint(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}