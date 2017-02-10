using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Guild : MonoBehaviour {
    public GameObject trade_menu;
    public Button Exit,Clear,Trade;
    public Slider[] sliders;
    public Text[] price;
    // Use this for initialization
    void Awake()
    {
        
    }
    void Start () {
        Exit.onClick.AddListener(clickExit);
        Clear.onClick.AddListener(clickClear);
        Trade.onClick.AddListener(clickTrade);

        trade_menu.SetActive(false);
    }
    void clickTrade()
    {

        init_trade_menu();
    }
    void clickExit()
    {
        trade_menu.SetActive(false);
        Gameloop.set_mode(Gameloop.mode_dungeon);
    }
    void clickClear()
    {
        init_trade_menu();
    }
    // Update is called once per frame
    void show_trade_menu()
    {
        trade_menu.SetActive(true);
        init_trade_menu();
        Gameloop.set_mode(Gameloop.mode_trade);
    }
    void init_trade_menu()
    {
        for(int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = 0f;
        }
    }
	void Update () {
        if (InputManager.instance.collide_object != null &&InputManager.instance.collide_object == gameObject){
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            if (InputManager.get_left_click())
            {
                show_trade_menu();
                Debug.Log("Hit Guild ");
            }
            else
            {

            }
            
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0.75f,0.75f,0.75f);
        }
    }
}
