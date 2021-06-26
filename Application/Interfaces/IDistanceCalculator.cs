using System.Collections.Generic;
using Entities.Entities;

namespace Program.Interfaces
{
    public interface IDistanceCalculator
    {
        public ICollection<RobotCommand> GetRoute();
    }
}