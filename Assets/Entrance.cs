using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() &&
        InputManager.instance.collide_object == gameObject)
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            if (InputManager.get_left_click())
            {
                Debug.Log("Hit Entrance ");
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 0.75f);
        }
    }
}
