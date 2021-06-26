﻿using System;
using Entities.Entities;
using Program.Extensions;
using Program.Interfaces;

namespace Program.Services
{
    public class DeliveryRobotService : IRobot
    {
        private readonly IDistanceCalculator _distanceCalculator;

        public DeliveryRobotService(IDistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
        }

        public void Delivery()
        {
            foreach (var robotCommand in _distanceCalculator.GetRoute()) Console.Write(robotCommand.ToFriendlyString());
        }
    }
}