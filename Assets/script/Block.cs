﻿using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    //private SpriteRenderer spriteRenderer;
    //Front front;
    GameObject cur_obj;
    //private SpriteR blocksprite;
    private SpriteR midsprite;
    private SpriteR frontsprite;
    private SpriteR front2sprite;
    private SpriteR front3sprite;

    private Building building;
    public Terrian terrian;
    //public Sprite[]  dungeonSprite;
    // Use this for initialization
    int mid_type,front_type,front2_type;
    public int pos_x, pos_y;
    public void init(int x,int y){
        cur_obj = gameObject;
        pos_x = x;
        pos_y = y;
        building = null;
        terrian = null;
        //Debug.Log("name="+cur_obj.name);

        //GameObject obj = GameObject.Find("Front");
        //if (obj != null)front = obj.GetComponent<Front>();
        /*
        for(int i = 0; i < cur_obj.transform.childCount; i++){
            GameObject obj = gameObject.transform.GetChild(i).gameObject;
            if (obj.name == "Front"){
                front = obj.GetComponent<Front>();
                Debug.Log("init front");
                break;
            }
        }
        type = Random.Range(0, BlockSprites.get().frontSprite.Length);
        front.set_sprite(BlockSprites.get().frontSprite[type]);
        */
        midsprite = SpriteR.new_sprite();
        midsprite.set_sorting_layer("mid");
        midsprite.transform.SetParent(cur_obj.transform);
        mid_type = Random.Range(0, BlockSprites.get().midSprite.Length);
        midsprite.set_sprite(BlockSprites.get().midSprite[mid_type]);

        frontsprite = SpriteR.new_sprite();
        frontsprite.set_sorting_layer("front");
        frontsprite.transform.SetParent(cur_obj.transform);
        front_type = Random.Range(0, BlockSprites.get().frontSprite.Length);
        frontsprite.set_sprite(BlockSprites.get().frontSprite[front_type]);

        front2sprite = SpriteR.new_sprite();
        front2sprite.set_sorting_layer("front2");
        front2sprite.transform.SetParent(cur_obj.transform);
        //front2_type = Random.Range(0, BlockSprites.get().front2Sprite.Length);
        front2_type = 1;
        front2sprite.set_sprite(BlockSprites.get().front2Sprite[front2_type]);

        front3sprite = SpriteR.new_sprite();
        front3sprite.set_sorting_layer("front3");
        front3sprite.transform.SetParent(cur_obj.transform);
        front3sprite.set_sprite(BlockSprites.get().transparent);
    }
    void Awake(){

        
        //sprite = GetComponent<SpriteR>();
    }
    void Start(){
        //type = Random.Range(0, BlockSprites.get().dungeonSprite.Length);
        //set_type(type);
    }
    public void set_building(Building _building){
        //Debug.Log("build!!");
        if (_building == null) return;
        if (building != null)
        {
            //Debug.Log("Destroy(building)!!");
            Destroy(building.gameObject);
            building = null;
        }
        building = _building;
        
        building.transform.SetParent(gameObject.transform);
        building.transform.position = gameObject.transform.position;

        building.transform.localScale = gameObject.transform.localScale;
    }
    /*
	public void set_type(int _type){
        type = _type;

        blocksprite.set_sprite(BlockSprites.get().dungeonSprite[type]);
        //spriteRenderer.sprite = BlockSprites.get().dungeonSprite[type];
    }
    */
    public void set_terrian(Terrian _terrian)
    {
        if (terrian!=null)
        {
            Destroy(terrian.transform.gameObject);
            terrian = null;
        }
        terrian = _terrian;//TerrianCreator.create_terrian(type)

        terrian.transform.SetParent(gameObject.transform);
        terrian.transform.position = gameObject.transform.position;

        terrian.transform.localScale = gameObject.transform.localScale;
    }
    public void set_front_type(int _type)
    {
        front_type = _type;
        frontsprite.set_sprite(BlockSprites.get().frontSprite[front_type]);
    }
    public void set_front2_type(int _type)
    {
        front2_type = _type;
        front2sprite.set_sprite(BlockSprites.get().front2Sprite[front2_type]);
    }
    public void set_front3_type(int _type)
    {
        switch (_type)
        {
            case 0:
                front3sprite.set_sprite(BlockSprites.get().transparent);
                break;
            case 1:
                front3sprite.set_sprite(BlockSprites.get().high_light);
                break;
            case 2:
                front3sprite.set_sprite(BlockSprites.get().high_light2);
                break;
        }

        
    }
    // Update is called once per frame
    public void day_update()
    {
        if (building != null)
        {
            building.day_update();
        }
    }
    void Update () {
        /*
        if (building != null){
            building.building_update();
        }
        */
    }
}
