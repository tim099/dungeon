using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gameloop : MonoBehaviour {
    Block prev_block,selected_block;
    // Use this for initialization
    public GameObject buildbuttons;
    public Button[] buildButton;
    //public Button buildButton2;
    public Text[] buildtex;
    public Button buildExit;
    Camera main_camera = null;
    public int day;
    int day_loop;
    public static Gameloop instance = null;

    void Awake()
    {
        instance = this;
    }
    void Start () {
        day = 0;
        day_loop = 0;
        GameObject obj = GameObject.Find("MainCamera");
        if (obj != null) main_camera = obj.GetComponent<Camera>();
        buildbuttons.SetActive(false);
        buildButton[0].GetComponent<Button>().onClick.AddListener(ClickbuildButton1);
        buildButton[1].GetComponent<Button>().onClick.AddListener(ClickbuildButton2);
        buildButton[2].GetComponent<Button>().onClick.AddListener(ClickbuildButton3);
        buildButton[3].GetComponent<Button>().onClick.AddListener(ClickbuildButton4);
        buildExit.GetComponent<Button>().onClick.AddListener(ClickbuildExit);
        prev_block = null;
        selected_block = null;
    }
    void deselect_block()
    {
        selected_block.set_front3_type(0);
        selected_block = null;
        buildbuttons.SetActive(false);
    }
    void ClickbuildExit(){
        deselect_block();
    }
    void ClickbuildButton1(){
        selected_block.set_building(BuildingCreator.create_building(buildtex[0].text));
        deselect_block();
    }
    void ClickbuildButton2(){
        selected_block.set_building(BuildingCreator.create_building(buildtex[1].text));
        //InputManager.instance.left_click = false;
        deselect_block();
    }
    void ClickbuildButton3()
    {
        selected_block.set_building(BuildingCreator.create_building(buildtex[2].text));
        deselect_block();
    }
    void ClickbuildButton4()
    {
        selected_block.set_building(BuildingCreator.create_building(buildtex[3].text));
        deselect_block();
    }
    void init_build_button(Block block)
    {
        buildbuttons.SetActive(true);
        for (int i = 0; i < buildButton.Length; i++)
        {
            if (block.terrian.buildable.Length > i)
            {
                buildButton[i].transform.gameObject.SetActive(true);
                buildtex[i].text = block.terrian.buildable[i];
            }
            else
            {
                buildButton[i].transform.gameObject.SetActive(false);
            }
        }
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
                    //buildbuttons.SetActive(true);
                    init_build_button(selected_block);
                }
                //block.set_building(BuildingCreator.create_building(Random.Range(0,2)));
                //block.transform.gameObject.SetActive(false);
            }

            block.set_front3_type(1);
            prev_block = block;
            //Debug.Log("find block x=" + block.pos_x + ",y=" + block.pos_y);
        }


        day_loop++;
        if (day_loop > 300)
        {
            BlockManager.instance.day_update();
            day_loop = 0;
            day++;
        }
    }
}
