using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Speed : MonoBehaviour {
    public Sprite[] speed_sprites;
    public Button speed;
    public Image img;
    // Use this for initialization
    void Start () {
        speed.GetComponent<Button>().onClick.AddListener(speed_click);
    }
    void speed_click()
    {
        if (Gameloop.instance.game_speed < speed_sprites.Length-1)
        {
            Gameloop.instance.game_speed++;
        }
        else
        {
            Gameloop.instance.game_speed = 0;
        }
        

    }
    // Update is called once per frame
    void Update () {
        img.sprite = speed_sprites[Gameloop.instance.game_speed];
    }
}
