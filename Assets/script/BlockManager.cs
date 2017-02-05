using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {
    int size_x,size_y;
    // Use this for initialization
    Vector2 block_size;
    public Block block;
    public Block[,] blocks;
    public int[] stair_at;
    private Transform pos;
    float scale;
    Vector2 start_pos;
    GameObject dungeon;

    public static BlockManager instance = null;
    void Awake(){
        instance = this;
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void generate_dungeon(int sx,int sy)
    {
        size_x = sx;
        size_y = sy;
        block_size.x = 5.1f;
        block_size.y = block_size.x / 4.0f;
        if(dungeon==null) dungeon = new GameObject("dungeon");
        pos = dungeon.transform;
        blocks = new Block[size_x, size_y];
        stair_at = new int[size_y];
        Block tmp;
        int max_width = size_x, min_width = 3<max_width? 3:max_width;
        for (int i = 0; i < size_y; i++)
        {
            int width= Random.Range(min_width, max_width+1);
            int start_at = 0;
            int min = 0;
            int max = size_x - width;
            //Debug.Log(width);
            if (i!=0){
                int del = stair_at[i - 1] - width+1;
                min = del > 0 ? del:0;
                int del2 = size_x - width;
                max = del2<stair_at[i-1]? del2 :stair_at[i-1];
            }
            start_at = Random.Range(min, max+1);

            if (i == 0){//first level
                stair_at[i] = Random.Range(0, width)+start_at;
                //Debug.Log("level:" + i + ",cur=" + stair_at[i]);
            }else{
                stair_at[i] = Random.Range(0,width-1)+start_at;
                if(stair_at[i - 1]<= stair_at[i]){
                    stair_at[i]++;
                }
                //Debug.Log("level:" + i + ",cur=" + stair_at[i] + ",prev=" + stair_at[i - 1]);
            }

            for (int j = 0; j < width; j++){
                int x = j + start_at;
                tmp = Instantiate(block, new Vector3(0,0,0), Quaternion.identity) as Block;
                
                tmp.init(x,i);
                tmp.transform.position = new Vector3(block_size.x * x, block_size.y * -i, 0f);
                tmp.transform.SetParent(pos);
                
                int type=0;
                if (stair_at[i] == x)
                {
                    type= TerrianCreator.stair_down;
                }else if (i > 0 && (stair_at[i - 1] == x)){
                    type = TerrianCreator.stair_up;
                    //Debug.Log("level:" + i + ",at="+j+ ",real=" + stair_at[i - 1]);
                    //type = BlockSprites.block_stair_up;
                }
                else
                {
                    type = Random.Range(0, TerrianCreator.instance.terrians.Length);
                    if (type == TerrianCreator.stair_down || type == TerrianCreator.stair_up)
                    {
                        type = 0;
                    }
                }
                //tmp.set_type(type);
                tmp.set_terrian(TerrianCreator.create_terrian(type));
                blocks[x, i] = tmp;
            }
        }
        scale = 0.8f;
        start_pos.x = (size_x - 1) * -0.5f * scale *  block_size.x;
        start_pos.y = -0.5f * scale * block_size.y;//-scale * 10 * block_size.y
        pos.position = new Vector3(start_pos.x, start_pos.y, 0);//
        Debug.Log("start_pos x=" + start_pos.x + ",y=" + start_pos.y);
        pos.localScale = new Vector3(scale, scale, 1);
    }
    public Block find_selected_block(float sx,float sy){
        Block block = null;
        float dx = sx - (start_pos.x - 0.5f * scale * block_size.x);
        float dy = -(sy - (start_pos.y + 0.5f * scale * block_size.y));
        int x = (int)System.Math.Floor(dx / (scale * block_size.x));
        int y = (int)System.Math.Floor(dy / (scale * block_size.y));
        
        if(x>=0&&x< size_x&&y>=0&&y< size_y)
        {
            
            block = blocks[x, y];
        }
        return block;
    }
    void Start () {
        size_x = 4;
        size_y = 4;
        dungeon = null;
        generate_dungeon(9,30);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
