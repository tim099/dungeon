using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

    private GUIStyle money_style;
    public long money, food, water, crystal, herb;

    Camera main_camera = null;
    public Sprite moneySpr,foodSpr,waterSpr,crystalSpr,herbSpr;
    private SpriteR money_sprite, food_sprite, water_sprite, crystal_sprite,herb_sprite;
    public static ResourceManager instance = null;
    
    void Awake(){
        instance = this;
    }
    void Start () {
        
        money = 1000;
        food = 1005;
        water = 1023;
        crystal = 333;
        herb = 4343;
        
        GameObject obj = GameObject.Find("MainCamera");
        if (obj != null) main_camera = obj.GetComponent<Camera>();
        gameObject.transform.SetParent(main_camera.transform);

        ///*
        int cur_at = 0;
        float start_pos = -8.2f, delta = 2.77f;
        money_sprite = SpriteR.new_sprite();
        money_sprite.set_sorting_layer("UI");
        money_sprite.transform.SetParent(gameObject.transform);
        money_sprite.transform.position = new Vector3(start_pos+(cur_at++*delta), 4.5f, 0);//.Set(5, 0, 0);
        money_sprite.set_sprite(moneySpr);

        food_sprite = SpriteR.new_sprite();
        food_sprite.set_sorting_layer("UI");
        food_sprite.transform.SetParent(gameObject.transform);
        food_sprite.transform.position = new Vector3(start_pos + (cur_at++ * delta), 4.5f, 0);//.Set(5, 0, 0);
        food_sprite.set_sprite(foodSpr);

        water_sprite = SpriteR.new_sprite();
        water_sprite.set_sorting_layer("UI");
        water_sprite.transform.SetParent(gameObject.transform);
        water_sprite.transform.position = new Vector3(start_pos + (cur_at++ * delta), 4.5f, 0);//.Set(5, 0, 0);
        water_sprite.set_sprite(waterSpr);

        crystal_sprite = SpriteR.new_sprite();
        crystal_sprite.set_sorting_layer("UI");
        crystal_sprite.transform.SetParent(gameObject.transform);
        crystal_sprite.transform.position = new Vector3(start_pos + (cur_at++ * delta), 4.5f, 0);
        crystal_sprite.set_sprite(crystalSpr);

        herb_sprite = SpriteR.new_sprite();
        herb_sprite.set_sorting_layer("UI");
        herb_sprite.transform.SetParent(gameObject.transform);
        herb_sprite.transform.position = new Vector3(start_pos + (cur_at++ * delta), 4.5f, 0);
        herb_sprite.set_sprite(herbSpr);
        //*/
        money_style = new GUIStyle();
        money_style.fontSize = (int)(30.0*(Screen.width/1280.0));
        money_style.normal.textColor = Color.yellow;

        /*
        water=0;
        food=0;
        
        crystal=0;
        herb=0;
        */
    }
    string convert_to_str(long val){
        int i;
        for (i = 0; i < 4&& val > 1000000; i++){
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
        float start_pos=0.07f,delta=0.152f;
        int i=0;
        GUI.Label(new Rect(Screen.width* (start_pos + (i++ * delta)), 15,20, 20), convert_to_str(money), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), 15, 20, 20), convert_to_str(food), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), 15, 20, 20), convert_to_str(water), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), 15, 20, 20), convert_to_str(crystal), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), 15, 20, 20), convert_to_str(herb), money_style);
        GUI.Label(new Rect(Screen.width * (start_pos + (i++ * delta)), 15, 20, 20), "day:"+Gameloop.instance.day, money_style);

        //GUI.Label(new Rect(Screen.width * start_pos, 55, 20, 20), "width=" + Screen.width+ ",height=" + Screen.height, money_style);
        //"width=" + Screen.width
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.F)){
            money = (long)(1.5* (double)money);
        }
    }
}
