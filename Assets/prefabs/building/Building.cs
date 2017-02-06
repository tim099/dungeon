using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    // Use this for initialization
    public string building_name;
    public long money_yield, food_yield, water_yield, crystal_yield, herb_yield;
    //public int 
    /*
    public virtual string get_building_name()
    {
        return "building_name";
    }
    */
    void Start () {
	
	}
    public void day_update()
    {
        ResourceManager.instance.money += money_yield;
        ResourceManager.instance.food += food_yield;
        ResourceManager.instance.water += water_yield;
        ResourceManager.instance.crystal += crystal_yield;
        ResourceManager.instance.herb += herb_yield;
    }
    // Update is called once per frame
    void Update () {
	
	}

    public virtual void building_update()
    {
        //Debug.Log("building update!!");
    }
}
