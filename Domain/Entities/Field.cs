using Entities.Interfaces;

namespace Entities.Entities
{
    public record Field : IFieldDefinition
    {
        public int XSize { get; }
        public int YSize { get; }

        public Field(int xSize, int ySize)
        {
            XSize = xSize;
            YSize = ySize;
        }
    };
}