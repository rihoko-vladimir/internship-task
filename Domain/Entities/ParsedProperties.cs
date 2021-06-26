using System.Collections.Generic;
using Entities.Interfaces;

namespace Entities.Entities
{
    public record ParsedProperties
    {
        public IFieldDefinition Field { get; }
        public ICollection<ICoordinate> StopPoints { get; }

        public ParsedProperties(IFieldDefinition field, ICollection<ICoordinate> stopPoints)
        {
            this.Field = field;
            this.StopPoints = stopPoints;
        }
    }
}