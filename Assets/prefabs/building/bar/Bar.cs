using UnityEngine;
using System.Collections;

public class Bar : Building {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /*
    public override string get_building_name()
    {
        return "Bar";
    }
    */
    public override void building_update()
    {
        //Debug.Log("bar update!!");
    }
}
