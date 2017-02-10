using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    // Use this for initialization
    Camera main_camera=null;
    public GUIStyle style;
    public Vector3 mousePos;
    public bool left_click;
    public static InputManager instance=null;
    public GameObject collide_object;

    void Awake(){
        instance = this;
        collide_object = null;
    }
    void Start () {
        mousePos = new Vector3(0, 0, 0);
        GameObject obj = GameObject.Find("MainCamera");
        if (obj != null) main_camera = obj.GetComponent<Camera>();
        left_click = false;
    }
    void find_collide_object()
    {
        collide_object = null;
        Vector2 mouseWorldPos = mousePos;
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        if (hit.collider != null)
        {
            collide_object = hit.transform.gameObject;
            if (hit.transform.name == gameObject.name)
            {

            }
            //Debug.Log("Hit Collider: " + hit.transform.name);
        }
    }
    // Update is called once per frame
    public static bool get_left_click()
    {
        if (instance.left_click == true){
            instance.left_click = false;
            return true;
        }
        return false;
    }
    void Update () {
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        find_collide_object();
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
        if (Input.GetButtonDown("Fire1"))
        {
            left_click = true;
        }
        if (Input.GetButtonUp("Fire1")){
            left_click = false;
        }
    }
}
