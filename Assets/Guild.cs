using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Guild : MonoBehaviour {
    public GameObject trade_menu;
    public Button Exit,Clear,Trade;
    public Slider[] sliders;
    public Text[] amount,market_text, sell_price_text, buy_price_text,cost_text;
    public Text total_cost_text;
    public long[] market = new long[4], price = new long[4];
    long total_cost;
    bool trading;
    // Use this for initialization
    void Awake()
    {
        
    }
    void Start () {
        total_cost = 0;
        for (int i=0;i< market.Length; i++)
        {
            market[i] = 100;
        }
        for (int i = 0; i < price.Length; i++)
        {
            price[i] = 4;
        }
        trading = false;
        Exit.onClick.AddListener(clickExit);
        Clear.onClick.AddListener(clickClear);
        Trade.onClick.AddListener(clickTrade);

        trade_menu.SetActive(false);
    }
    void trade()
    {
        if(ResourceManager.instance.money + total_cost >= 0)
        {
            ResourceManager.instance.money += total_cost;
            for (int i = 0; i < sliders.Length; i++)
            {
                long buy_amount = (long)(sliders[i].value * (float)market[i]);
                long sell_amount = (long)(-sliders[i].value * (float)ResourceManager.get_resource(i));
                if (buy_amount > 0)
                {
                    market[i] -= buy_amount;
                    ResourceManager.alter_resource(i, buy_amount);
                }
                else if (sell_amount > 0)
                {
                    market[i] += sell_amount;
                    ResourceManager.alter_resource(i, -sell_amount);
                }
            }
        }

    }
    void clickTrade()
    {
        trade();
        init_trade_menu();
    }
    void clickExit()
    {
        end_trade();
    }
    void clickClear()
    {
        init_trade_menu();
    }
    // Update is called once per frame
    void start_trade()
    {
        trading = true;
        trade_menu.SetActive(true);
        init_trade_menu();
        Gameloop.set_mode(Gameloop.mode_trade);
        Gameloop.pause_game();
    }
    void end_trade()
    {
        trade_menu.SetActive(false);
        trading = false;
        Gameloop.set_mode(Gameloop.mode_dungeon);
        Gameloop.unpause_game();
    }
    void init_trade_menu()
    {
        for(int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = 0f;
        }
    }
	void Update () {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() &&
             InputManager.instance.collide_object != null &&InputManager.instance.collide_object == gameObject){
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            if (InputManager.get_left_click())
            {
                start_trade();
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
        if (trading)
        {
            for (int i = 0; i < price.Length; i++)
            {
                sell_price_text[i].text = "sell_price:"+ (int)(0.75*price[i]);
            }
            for (int i = 0; i < price.Length; i++)
            {
                buy_price_text[i].text = "buy_price:" + price[i];
            }
            total_cost=0;
            for (int i=0;i< sliders.Length; i++)
            {
                long buy_amount = (long)(sliders[i].value * (float)market[i] );
                long sell_amount = (long)(-sliders[i].value * (float)ResourceManager.get_resource(i));
                long cost = 0;
                if (buy_amount > 0)
                {
                    amount[i].text = "buy:"+ ResourceManager.convert_to_str(buy_amount);
                    cost = -buy_amount * price[i];
                }
                else if(sell_amount > 0)
                {
                    amount[i].text = "sell:" + ResourceManager.convert_to_str(sell_amount);
                    cost = sell_amount * (int)(0.75 * price[i]);
                }
                else
                {
                    amount[i].text = "0";
                }
                total_cost += cost;

                cost_text[i].text = ResourceManager.convert_to_str(cost);
            }
            total_cost_text.text= "total:"+ResourceManager.convert_to_str(total_cost);
            for (int i = 0;i<market.Length;i++)
            {
                market_text[i].text = ResourceManager.convert_to_str(market[i]);
            }
        }
    }


}
