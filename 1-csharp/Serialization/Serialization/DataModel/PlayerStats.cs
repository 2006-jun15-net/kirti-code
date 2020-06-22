using System;
using System.Collections.Generic;

namespace Serialization.DataModel
{
    public class PlayerStats
    {
        public PlayerStats()
        {
        }

        public string Name { get; set; }

        public double FreeThrowPercentage { get; set; }

        public double PointsPerGame { get; set; }

        public Dictionary<int, double> ArcLocation {get; set; }

        // not uncommon to have spcial classes just fo representing the format used for serialization
        // POCO (plain old CLR object)
    }
}
