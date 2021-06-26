using System.Collections.Generic;
using Entities.Entities;

namespace Program.Interfaces
{
    public interface IParser
    {
        Field Field { get; }
        ICollection<Coordinate> Coordinates { get; }
    }
}