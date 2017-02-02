using UnityEngine;
using System.Collections;

public class SpriteR : MonoBehaviour {
    private SpriteRenderer spriteRenderer=null;
    private static SpriteR instance=null;
    // Use this for initialization
    public void init()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
    void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (instance == null)
        {
            instance = this;
        }
    }
    public static SpriteR new_sprite()
    {
        if (instance == null)
        {
            Debug.Log("SpriteR new_sprite() fail,instance not exist!!");
            return null;
        }
        SpriteR s= Instantiate(instance, new Vector3(0,0,0),Quaternion.identity) as SpriteR;
        s.init();
        return s;
    }
    public void set_sorting_layer(string name)
    {
        spriteRenderer.sortingLayerName = name;
    }
    public void set_sprite(Sprite sprite)
    {
        if (spriteRenderer == null){
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        //Debug.Log("SpriteR set sprite");
        spriteRenderer.sprite = sprite;
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
