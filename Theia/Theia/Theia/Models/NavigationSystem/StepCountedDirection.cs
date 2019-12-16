using System;
using System.Collections.Generic;
using System.Text;
using static Theia.Models.NavigationSystem.Direction;

namespace Theia.Models.NavigationSystem
{
    public class StepCountedDirection : Direction
    {
        public StepCountedDirection(DirectionName direction, int steps)
        {
            NextDirection = direction;
            Steps = steps;
        }
        public DirectionName NextDirection { get; set; }
        public int Steps { get; set; }
    }
}
