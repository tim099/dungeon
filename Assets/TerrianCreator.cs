using UnityEngine;
using System.Collections;

public class TerrianCreator : MonoBehaviour {
    public GameObject[] terrians;
    public GameObject[] terrians2;
    public GameObject[] terrians3;
    public static TerrianCreator instance = null;
    public static int cave = 0;
    public static int water = 1;
    public static int stair_down = 2;
    public static int stair_up = 3;
    // Use this for initialization
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
	
	}
    public static Terrian create_terrian(int i)
    {
        Terrian ins = Instantiate(instance.terrians[i].GetComponent<Terrian>()) as Terrian;
        return ins;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
