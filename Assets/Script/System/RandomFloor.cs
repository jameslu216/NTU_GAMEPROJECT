using System.Linq;
using BombShooting.System;
using UniRx;
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
    public float cullDistance = 10;

    private Transform[] players;

    private void Start()
    {
        var initVal = GameManager.Instance.remainTime.Value;
        this.players = PlayerSystem.Instance.Players
            .Select(p => p.transform)
            .ToArray();
        GameManager.Instance.remainTime
            .Select(t => initVal - t)
            .Where(t => t % 5 == 0)
            .Subscribe(t => this.generateBlocks())
            .AddTo(this);
    }

    private void generateBlocks()
    {
        tilemap.ClearAllTiles();
        int i = 0, x, y;
        while(i < blocknum)
        {
            x = Random.Range(negX, posX);
            y = Random.Range(negY, posY);
            var genPos = new Vector3Int(x, y, 0);
            if(
                this.players
                .Select(t => Vector3.Distance(t.position, genPos))
                .All(dis => dis >= this.cullDistance || dis <= 3)
            )
                continue;
            if(cannotWalkMap.GetTile(genPos) != unWalkableTile)
            {
                tilemap.SetTile(genPos, Block);
                i++;
            }
        }
    }
}