using UnityEngine;
using System.Collections;

public class Gameloop : MonoBehaviour {
    Block prev_block,selected_block;
    // Use this for initialization
    public GameObject buildbuttons;
    public UnityEngine.UI.Button buildButton1;
    public UnityEngine.UI.Button buildButton2;
    public UnityEngine.UI.Button buildExit;
    Camera main_camera = null;

    void Start () {
        GameObject obj = GameObject.Find("MainCamera");
        if (obj != null) main_camera = obj.GetComponent<Camera>();
        buildbuttons.SetActive(false);
        buildButton1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ClickbuildButton1);
        buildButton2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ClickbuildButton2);
        buildExit.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ClickbuildExit);
        prev_block = null;
        selected_block = null;
    }
    void deselect_block()
    {
        selected_block.set_front3_type(0);
        selected_block = null;
        buildbuttons.SetActive(false);
    }
    void ClickbuildExit()
    {
        deselect_block();
    }
    void ClickbuildButton1()
    {
        //InputManager.instance.left_click = false;
        selected_block.set_building(BuildingCreator.create_building(0));
        deselect_block();
        Debug.Log("You have clicked the button1!");
    }
    void ClickbuildButton2()
    {
        selected_block.set_building(BuildingCreator.create_building(1));
        //InputManager.instance.left_click = false;
        deselect_block();


        Debug.Log("You have clicked the button2!");
    }
    // Update is called once per frame
    void Update () {

        Vector3 mousePos = InputManager.instance.mousePos;
        //GUI.Label(new Rect(Screen.width * start_pos, 55, 20, 20),"x="+mousePos.x+",y="+mousePos.y+",z="+mousePos.z, money_style);
        if (prev_block != null)
        {
            prev_block.set_front3_type(0);
            prev_block = null;
        }
        if (selected_block)
        {
            selected_block.set_front3_type(2);
        }
        Block block = BlockManager.instance.find_selected_block(mousePos.x, mousePos.y);
        if (block != null){
            if (InputManager.get_left_click()){
                if (!selected_block){
                    main_camera.transform.position = new Vector3(block.transform.position.x,block.transform.position.y,-10);
                    //deselect_block();
                    block.set_front3_type(2);

                    block.set_front2_type(3);
                    selected_block = block;
                    buildbuttons.SetActive(true);
                }
                //block.set_building(BuildingCreator.create_building(Random.Range(0,2)));
                //block.transform.gameObject.SetActive(false);
            }


            block.set_front3_type(1);
            

            
            

            prev_block = block;
            //Debug.Log("find block x=" + block.pos_x + ",y=" + block.pos_y);
        }
    }
}
