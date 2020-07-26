using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts.Model
{    public class AirportData
    {
        //"id","ident","type","name","latitude_deg","longitude_deg","elevation_ft","continent","iso_country","iso_region","municipality","scheduled_service","gps_code","iata_code","local_code","home_link","wikipedia_link","keywords"
        //1941,"CYVR","large_airport","Vancouver International Airport",49.193901062,-123.183998108,14,"NA","CA","CA-BC","Vancouver","yes","CYVR","YVR",,"http://www.yvr.ca/","https://en.wikipedia.org/wiki/Vancouver_International_Airport",

        [CsvHelper.Configuration.Attributes.Default(0)]
        public int Id { get; set; }
        public string ICAO { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public float Latitude { get; set; }
        public float Longitude { get; set; }

        [CsvHelper.Configuration.Attributes.Default(0)]
        public int Altitude { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }

        [CsvHelper.Configuration.Attributes.BooleanTrueValues("yes")]
        [CsvHelper.Configuration.Attributes.BooleanFalseValues("no")]
        public bool ScheduledService { get; set; }

        [CsvHelper.Configuration.Attributes.Ignore]
        public int Population { get; set; }

        [CsvHelper.Configuration.Attributes.Ignore]
        public float WealthFactor { get; set; }

        [CsvHelper.Configuration.Attributes.Ignore]
        public float TourismFactor { get; set; }
        

        [CsvHelper.Configuration.Attributes.Ignore]
        public int Runways { get; set; }



        public override string ToString()
        {
            return Name;
        }

    }

}
