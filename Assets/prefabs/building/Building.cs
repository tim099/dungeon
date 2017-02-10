using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    // Use this for initialization
    public string building_name;
    public long money_yield, food_yield, water_yield, crystal_yield, herb_yield;
    long[] resource_yield = new long[4];
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
        resource_yield[0] = food_yield;
        resource_yield[1] = water_yield;
        resource_yield[2] = crystal_yield;
        resource_yield[3] = herb_yield;

        if (ResourceManager.instance.money+ money_yield >= 0)
        {
            bool flag = false;
            for(int i = 0; i < resource_yield.Length; i++)
            {
                if(ResourceManager.instance.resource[i]+ resource_yield[i] < 0)
                {
                    flag = true;//no enough resource
                    break;
                }
            }
            if (!flag)//yeild success!!
            {
                ResourceManager.instance.money += money_yield;
                for (int i = 0; i < resource_yield.Length; i++)
                {
                    ResourceManager.instance.resource[i] += resource_yield[i];
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
	
	}

    public virtual void building_update()
    {
        //Debug.Log("building update!!");
    }
}
