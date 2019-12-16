using System;
using System.Collections.Generic;
using System.Text;

namespace Theia.Models.NavigationSystem
{
    public class Direction 
    {
        public enum DirectionName
        {
            Left,
            Right,
            Straight,
            North,
            East,
            South,
            West,
            Idle
        }

        
        public static string LeftSpeech = "Go Left";
        public static string RightSpeech = "Go Right";
        public static string StraightSpeech = "Go Straight";
        public static string StopSpeech = "Stop";
        public static string NorthSpeech = "Facing North";
        public static string EastSpeech = "Facing East";
        public static string SouthSpeech = "Facing Sounth";
        public static string WestSpeech = "Facing West";
        /*
            DirectionImage
            {
                Left = "arrow_left.png";
                Right = "arrow_right.png",
                Straight = "arrow_forward.png",
                Idle = "map_icon.png"
            }
            */
    }
}
