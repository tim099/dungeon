using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ResourceManager : MonoBehaviour {

    private GUIStyle money_style;
    public long money;//, food, water, crystal, herb
    public const int food_id = 0, water_id = 1, crystal_id = 2, herb_id = 3;
    public long[] resource = new long[4];
    Camera main_camera = null;
    //public Sprite moneySpr,foodSpr,waterSpr,crystalSpr,herbSpr;
    //private SpriteR money_sprite, food_sprite, water_sprite, crystal_sprite,herb_sprite;

    public Text money_text;
    public Text[] resource_text;
    public static ResourceManager instance = null;
    void Awake(){
        instance = this;
    }
    void Start () {
        money = 200;
        for(int i = 0; i < resource.Length; i++)
        {
            resource[i] = 10;
        }
        GameObject obj = GameObject.Find("MainCamera");
        if (obj != null) main_camera = obj.GetComponent<Camera>();
        gameObject.transform.SetParent(main_camera.transform);
        /*
        int cur_at = 0;
        float start_pos = -8.2f, delta = 2.77f* offset;
        money_sprite = init_resource_sprite();
        money_sprite.transform.position = new Vector3(start_pos+(cur_at++*delta), 4.5f, 0);//.Set(5, 0, 0);
        money_sprite.set_sprite(moneySpr);
        */
        money_style = new GUIStyle();
        money_style.fontSize = (int)(30.0*(Screen.width/1280.0));
        money_style.normal.textColor = Color.yellow;
    }
    SpriteR init_resource_sprite()
    {
        SpriteR sprite= SpriteR.new_sprite();
        sprite.set_sorting_layer("UI");
        sprite.transform.SetParent(gameObject.transform);
        return sprite;
    }
    public static string convert_to_str(long val){
        int i;
        for (i = 0; i < 4&& val > 10000; i++){
            val /= 1000;
        }
        string str_unit = "";
        switch (i){
            case 1:
                str_unit = "K";
                break;
            case 2:
                str_unit = "M";
                break;
            case 3:
                str_unit = "B";
                break;
            case 4:
                str_unit = "T";
                break;
        }
        string str = val.ToString();

        return str+ str_unit;
    }
    void OnGUI(){
        //Debug.Log("width=" + Screen.width);
        /*
        float start_pos=0.07f,delta=0.151f* offset;
        int i=0;
        GUI.Label(new Rect(Screen.width* (start_pos + (i++ * delta)), Screen.height*0.025f, 20, 20), convert_to_str(money), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), Screen.height * 0.025f, 20, 20), convert_to_str(food), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), Screen.height * 0.025f, 20, 20), convert_to_str(water), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), Screen.height * 0.025f, 20, 20), convert_to_str(crystal), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), Screen.height * 0.025f, 20, 20), convert_to_str(herb), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), Screen.height * 0.025f, 20, 20),
            "date:"+Gameloop.instance.month+"/" +Gameloop.instance.day, money_style);
        */
        //GUI.Label(new Rect(Screen.width * start_pos, 55, 20, 20), "width=" + Screen.width+ ",height=" + Screen.height, money_style);
        //"width=" + Screen.width
    }
    // Update is called once per frame
    public static long get_resource(int type)
    {
        return instance.resource[type];
    }
    public static void alter_resource(int type,long amount)
    {
        instance.resource[type]+=amount;
    }
    void Update () {
        if (Input.GetKeyUp(KeyCode.F)){
            money = (long)(1.5* (double)money);
        }
        money_text.text = convert_to_str(money);
        for(int i=0;i< resource_text.Length; i++)
        {
            resource_text[i].text = convert_to_str(resource[i]);
        }
        /*
        water_text.text = convert_to_str(resource[water]);
        food_text.text = convert_to_str(resource[food]);
        herb_text.text = convert_to_str(resource[herb]);
        crystal_text.text = convert_to_str(resource[crystal]);
        */
    }
}
