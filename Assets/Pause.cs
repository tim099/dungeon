using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Pause : MonoBehaviour {
    public Button pause;
    public Sprite pause_s,start_s;
    public Image img;
    // Use this for initialization
    void Start () {
        pause.GetComponent<Button>().onClick.AddListener(pause_click);
    }
	void pause_click()
    {
        Gameloop.instance.pause = Gameloop.instance.pause ^ true;
    }
	// Update is called once per frame
	void Update () {
        if (Gameloop.instance.pause)
        {
            img.sprite = pause_s;
        }
        else
        {
            img.sprite = start_s;
        }
        //pause.s = pause_s;
        
    }
}
