using UnityEngine;
using System.Collections;

public class BuildingCreator : MonoBehaviour {

    //public Building[] buildings;
    public GameObject[] buildings;
    static BuildingCreator instance = null;
    public static int bar = 0;
    // Use this for initialization
    void Awake()
    {
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
    public static Building create_building(int i)
    {
        Building building = Instantiate(instance.buildings[i].GetComponent<Building>()) as Building;
        return building;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
