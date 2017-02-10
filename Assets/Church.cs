using UnityEngine;
using System.Collections;

public class Church : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (InputManager.instance.collide_object!=null&&
            InputManager.instance.collide_object == gameObject){
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            if (InputManager.get_left_click()){
                Debug.Log("Hit Church ");
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 0.75f);
        }

    }
}
