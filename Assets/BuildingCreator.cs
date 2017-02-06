using UnityEngine;
using System.Collections;

public class BuildingCreator : MonoBehaviour {
    public Hashtable building_hash;
    //public Building[] buildings;
    public GameObject[] buildings;

    static BuildingCreator instance = null;
    public static int bar = 0;
    public static int field = 1;
    // Use this for initialization
    void Awake()
    {
        building_hash = new Hashtable();
        for(int i = 0; i < buildings.Length; i++)
        {
            building_hash.Add(buildings[i].GetComponent<Building>().building_name, i);
        }
        instance = this;
    }
    void Start () {
        /*
	    for(int i = 0; i < buildings.Length; i++)
        {
            buildings[i].SetActive(false);
        }
        */

	}
    public static Building create_building(string name)
    {
        if (instance.building_hash.Contains(name))
        {
            return create_building((int)instance.building_hash[name]);
        }

        Debug.Log("Building create_building(string name) fail,no building name:" + name);
        return null;

    }
    public static Building create_building(int i)
    {
        Building building = Instantiate(instance.buildings[i].GetComponent<Building>()) as Building;
        return building;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
