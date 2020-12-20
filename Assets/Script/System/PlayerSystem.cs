using System.Collections;
using System.Collections.Generic;
using BombShooting.Control;
using BombShooting.Utils;
using UnityEngine;

public class PlayerSystem : Singleton<PlayerSystem>
{
    [SerializeField]
    private List<Player> players = new List<Player>();
    public IEnumerable<Player> Players
    {
        get => this.players.AsReadOnly();
    }

    public Player randomPlayer()
    {
        if(this.players.Count == 0)
            return null;
        return this.players[Random.Range(0, this.players.Count)];
    }
}