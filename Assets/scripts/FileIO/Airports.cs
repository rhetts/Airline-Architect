using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.scripts.Model;


namespace Assets.scripts.FileIO
{
    class Airports
    {

        private static AirportData[] m_airports;

        public static AirportData[] GetAirports()
        {
            try
            {


                if (null != m_airports)
                    return m_airports;

                var asset = Resources.Load<TextAsset>("airports");

                if (null == asset)
                    throw new FileNotFoundException("airports");
                //var file = new CsvHelper.CsvReader(fileX, CultureInfo.InvariantCulture);


                var text = new StringReader(asset.text);
                CsvHelper.CsvReader reader;
                text.ReadLine(); //skip first line

                reader = new CsvHelper.CsvReader(text, CultureInfo.InvariantCulture);
                reader.Configuration.HasHeaderRecord = false ;


                m_airports = reader.GetRecords<AirportData>().Where(a => a.Type != "heliport" && a.Type != "closed" && a.Type != "small_airport" && a.Type != "seaplane_base" && a.Type != "medium_airport").ToArray();

               return m_airports;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
