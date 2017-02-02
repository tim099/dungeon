using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    // Use this for initialization
    Camera main_camera=null;
    public GUIStyle style;
    public Vector3 mousePos;
    public static InputManager instance=null;
    void Awake(){
        instance = this;
    }
    void Start () {
        mousePos = new Vector3(0, 0, 0);
        GameObject obj = GameObject.Find("MainCamera");
        if (obj != null) main_camera = obj.GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.A)){
            main_camera.transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)){
            main_camera.transform.position += new Vector3(0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.W)){
            main_camera.transform.position += new Vector3(0, 0.1f, 0);
        }
        if (Input.GetKey(KeyCode.S)){
            main_camera.transform.position += new Vector3(0, -0.1f, 0);
        }
        if (Input.GetKey(KeyCode.Escape))Application.Quit();
        if (Input.GetButtonDown("Fire1")){
            //Debug.Log("x="+Input.mousePosition.x+",y="+ Input.mousePosition.y + ",z=" + Input.mousePosition.z);
        }
    }
}
