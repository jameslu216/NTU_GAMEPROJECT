using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomFloor : MonoBehaviour
{
    public Tilemap tilemap;//引用的Tilemap，加入脚本后需要将对应tilemap拖进来
    public Tilemap cannotWalkMap;
    [SerializeField]
    public Tile Block;
    public Tile unWalkableTile;
    public int negX=-33;
    public int posX=32;
    public int negY=-33;
    public int posY=32;
    public int blocknum=10;
    
    void Update()
    {
       
        tilemap.ClearAllTiles();
    }
    void generateBlocks()
    {
        int i=0,x,y;
        while(i<blocknum)
        {
            x=Random.Range(negX,posX);
            y=Random.Range(negY,posY);
        if(cannotWalkMap.GetTile(new Vector3Int(x,y,0))!=unWalkableTile)
        {
            tilemap.SetTile(new Vector3Int(x,y,0),Block);
            i++;
        }
        }
    }
}