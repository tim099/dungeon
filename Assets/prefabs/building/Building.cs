using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    // Use this for initialization
    public virtual string get_building_name()
    {
        return "building_name";
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void building_update()
    {
        //Debug.Log("building update!!");
    }
}
