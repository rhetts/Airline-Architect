using Assets.scripts.FileIO;
using Assets.scripts.GameObjects;
using Assets.scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    static World _instance;


    public GameObject AirportPrototype;
    public GameObject TextPanel;

    public WorldData WorldData { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        //var x = Input.anyKey;
    }


    internal static World Instance
    {
        get
        {
            //if (null == _instance)
            //    _instance = new World();

            return _instance;
        }
    }


    internal void SelectAirport(AirportData airport)
    {
        WorldData.SelectedAirport = airport;

        var str = string.Format("{0}\r\n{1,1}\r\n{2,1}\r\n{3}\r\n", airport.Name, airport.Latitude, airport.Longitude, airport.Region);

        TextPanel.GetComponent<UnityEngine.UI.Text>().text = str;
    }
}
