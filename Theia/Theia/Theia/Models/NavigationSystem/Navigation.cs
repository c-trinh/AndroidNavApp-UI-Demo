using System;
using System.Collections.Generic;
using System.Text;
using static Theia.Models.NavigationSystem.Direction;

namespace Theia.Models.NavigationSystem
{
    public class Navigation
    {
        //Class controls if the navigation system is started or stopped.
        BuildingMap Map;
        public Navigation()
        {
            Map = new BuildingMap();
            Direction = DirectionName.Right;
            Started = false;
            NavigationImageSource = "map_icon.png";
        }

        public bool LoadMap(string map)
        {
            if (map.Trim() == "Test map")
            {
                Map.AddDirection(new StepCountedDirection(DirectionName.North, 7));
                Map.AddDirection(new StepCountedDirection(DirectionName.Straight, 30));
                Map.AddDirection(new StepCountedDirection(DirectionName.Right, 7));
                Map.AddDirection(new StepCountedDirection(DirectionName.Straight, 10));
                Map.AddDirection(new StepCountedDirection(DirectionName.Right, 7));
                Map.AddDirection(new StepCountedDirection(DirectionName.Straight, 20));
                Map.AddDirection(new StepCountedDirection(DirectionName.Left, 7));
                Map.AddDirection(new StepCountedDirection(DirectionName.Straight, 7));
                Map.AddDirection(new StepCountedDirection(DirectionName.Idle, 7));
                return true;
            }
            return false;
        }

        public string NavigationImageSource { get; set; }
       
        public DirectionName Direction { get => Map.CurrentDirection;
            set => Map.CurrentDirection = value; }

        private bool started;
        public bool Started
        {
            get
            {
                return started;
            }
            set
            {
                stopped = !value;
                started = value;
            }
        }

        private bool stopped;
        public bool Stopped
        {
            get
            {
                return stopped;
            }
            set
            {
                started = !value;
                stopped = value;
            }
        }

        

        public DirectionName GetNextDirection()
        {
            
            return Map.NextDirection;
        }
    }
}
