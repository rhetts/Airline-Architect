using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Assets.scripts.Model;


namespace Assets.scripts.GameObjects
{
    class Airport:MonoBehaviour
    {
        AirportData data;


        public static GameObject InstantiateMe(GameObject prototype, Vector3 pos, Quaternion rotation, AirportData airportData)
        {
            var newObject = Instantiate(prototype, pos, rotation);
            var airportScript = newObject.GetComponent<Airport>();
            //var x = newObject.

            airportScript.data = airportData;

            var child = newObject.transform.Find("nameLabel").gameObject;

            var text = child.GetComponent("TextMeshPro") as TextMeshPro;

            text.text = airportData.ICAO;

            if(airportData.ICAO.StartsWith("C"))
                text.color = new Color(1, 0, 0);
            
            
            return newObject;
        }



        private void OnMouseDown()
        {
            //Debug.Log("sup dawgs");
            World.Instance.SelectAirport(data);
        }


    }
}
