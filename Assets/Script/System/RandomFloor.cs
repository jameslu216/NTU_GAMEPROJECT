using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomFloor : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap cannotWalkMap;
    [SerializeField]
    public Tile Block;
    public Tile unWalkableTile;
    public int negX = -33;
    public int posX = 32;
    public int negY = -33;
    public int posY = 32;
    public int blocknum = 10;

    private void Update()
    {
        tilemap.ClearAllTiles();
    }

    private void generateBlocks()
    {
        int i = 0, x, y;
        while(i < blocknum)
        {
            x = Random.Range(negX, posX);
            y = Random.Range(negY, posY);
            if(cannotWalkMap.GetTile(new Vector3Int(x, y, 0)) != unWalkableTile)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), Block);
                i++;
            }
        }
    }
}