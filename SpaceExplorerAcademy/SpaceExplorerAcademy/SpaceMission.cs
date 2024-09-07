using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorerAcademy
{
    //This class represents a spcae mission that can be assigned to cadets
    public class SpaceMission
    {
        public string Name { get; set; } //Name of the mission
        public int Difficulty { get; set; } //Difficulty level of the mission
        public override string ToString() => $"{Name} (Difficulty: {Difficulty})";
        //Override the ToString to provide a custom string representation of the mission 
    }
}
