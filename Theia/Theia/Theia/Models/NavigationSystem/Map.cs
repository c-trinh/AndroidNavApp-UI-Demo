using System;
using System.Collections.Generic;
using System.Text;
using static Theia.Models.NavigationSystem.Direction;

namespace Theia.Models.NavigationSystem
{
    public class BuildingMap
    {
        private List<StepCountedDirection> CountedDirections { get; set; }
        int CurrentStepCount { get; set; }

        public DirectionName CurrentDirection { get; set; }
        int StepsNeeded { get; set; }
        int NextDirectionStepsNeeded { get; set; }
        int DirectionCount;
        public BuildingMap()
        {
            CountedDirections = new List<StepCountedDirection>();
            CurrentStepCount = 0;
            StepsNeeded = 0;
            NextDirectionStepsNeeded = 0;
            //CurrentDirection = DirectionName.Right;
            //CountedDirections = new List<StepCountedDirection>();
            DirectionCount = 0;
        }

        public void AddDirection(StepCountedDirection direction)
        {
            CountedDirections.Add(direction);
        }

        public DirectionName NextDirection
        {
            get
            {
                CurrentStepCount++;
                if (CurrentStepCount < StepsNeeded
                    && DirectionCount != 0) return CurrentDirection;

                if (DirectionCount < CountedDirections.Count)
                {
                    NextDirectionStepsNeeded = CountedDirections[DirectionCount].Steps;
                    CurrentDirection = CountedDirections[DirectionCount].NextDirection;
                }

                DirectionCount++;

                if (DirectionCount == CountedDirections.Count){
                    DirectionCount = 0;

                }
                
                StepsNeeded += NextDirectionStepsNeeded;
                return CurrentDirection;

            }
        }
    }
}
