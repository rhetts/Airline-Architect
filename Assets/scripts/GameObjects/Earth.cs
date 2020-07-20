using Assets.scripts.FileIO;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Earth : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        World.Instance.NewGame();

        //var airports = Airports.GetAirports();


        foreach (var ap in World.Instance.WorldData.Airports)
        {
            var pos = ToVector3(ap.Latitude, ap.Longitude, 0);
            
            //Instantiate(obj);
            //var newObject = Instantiate(AirportPrototype, pos, RotateTo(pos, this.transform.position));
            var newObject = Assets.scripts.GameObjects.Airport.InstantiateMe(World.Instance.AirportPrototype, pos, RotateTo(pos, this.transform.position), ap);

            //var airportScript = newObject.GetComponent<Assets.scripts.GameObjects.Airport>();

            
        }
    }


    private Quaternion RotateTo(Vector3 source, Vector3 target)
    {
        //find the vector pointing from our position to the target
        var _direction = (target - source).normalized;
        
        //create the rotation we need to be in to look at the target
        var _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * Ro
        return _lookRotation;
    }



    //f  = 0                              # flattening
    //ls = atan((1 - f)**2 * tan(lat))    # lambda

    //x = rad* cos(ls) * cos(lon) + alt* cos(lat) * cos(lon)
    //y = rad* cos(ls) * sin(lon) + alt* cos(lat) * sin(lon)
    //z = rad* sin(ls) + alt* sin(lat)

    //return c4d.Vector(x, y, z)



    private Vector3 ToVector3(float lat, float lon, float alt)
    {
        // see http://www.mathworks.de/help/toolbox/aeroblks/llatoecefposition.html
        //lon = 0f;
        lat = Mathf.Deg2Rad * lat * 1;
        lon = Mathf.Deg2Rad * lon * 1;
        //lat = 0;


        var f = 0;                         // flattening
        var ls = Mathf.Pow(Mathf.Atan((1 - f)), 2) * Mathf.Tan(lat);    // lambda
        var rad = 502f;

        var x = rad * Mathf.Cos(ls) * Mathf.Cos(lon) + alt * Mathf.Cos(lat) * Mathf.Cos(lon);
        var z = rad * Mathf.Cos(ls) * Mathf.Sin(lon) + alt * Mathf.Cos(lat) * Mathf.Sin(lon);
        var y = rad * Mathf.Sin(ls) + alt * Mathf.Sin(lat);

        
        return new Vector3(x, y, z);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
