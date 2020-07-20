using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts.Model
{
    public class WorldData
    {
        public PlayerData[] Players { get; set; }

        public AirportData SelectedAirport { get; set; }

        public AirportData[] Airports { get; set; }
    }
}
