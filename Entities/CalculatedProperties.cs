using System.Collections.Generic;

namespace Entities
{
    public record CalculatedProperties
    {
        public IFieldDefinition Field { get; }
        public List<IStopPoint> StopPoints { get; }

        public CalculatedProperties(IFieldDefinition field, List<IStopPoint> stopPoints)
        {
            this.Field = field;
            this.StopPoints = stopPoints;
        }
    }
}