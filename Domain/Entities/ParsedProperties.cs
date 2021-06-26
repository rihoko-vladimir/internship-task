using System.Collections.Generic;

namespace Entities.Entities
{
    public record ParsedProperties
    {
        public Field Field { get; init; }
        public ICollection<Coordinate> StopPoints { get; init; }
    }
}