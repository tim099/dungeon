using UnityEngine;
using System.Collections;

public class BlockSprites : MonoBehaviour {
    static BlockSprites instance=null;
    //public Sprite[] dungeonSprite;
    public Sprite[] frontSprite;
    public Sprite[] front2Sprite;
    public Sprite[] midSprite;
    public Sprite transparent;
    public Sprite high_light;
    public Sprite high_light2;

    // Use this for initialization
    void Start () {
        instance = this;
    }
	public static BlockSprites get()
    {
        if (instance == null)
        {
            Debug.Log("BlockSprites get() create new instance");
            instance = GameObject.FindObjectOfType(typeof(BlockSprites)) as BlockSprites;
            //instance = new BlockSprites();
        }
        //Debug.Log("blockSprite:" + instance);
        return instance;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
