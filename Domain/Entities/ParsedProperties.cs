using System.Collections.Generic;
using Entities.Interfaces;

namespace Entities.Entities
{
    public record ParsedProperties
    {
        public IFieldDefinition Field { get; }
        public List<IStopPoint> StopPoints { get; }

        public ParsedProperties(IFieldDefinition field, List<IStopPoint> stopPoints)
        {
            this.Field = field;
            this.StopPoints = stopPoints;
        }
    }
}