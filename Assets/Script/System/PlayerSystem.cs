using System.Collections;
using System.Collections.Generic;
using BombShooting.Control;
using BombShooting.Utils;
using UnityEngine;

public class PlayerSystem : Singleton<PlayerSystem>
{
    private List<Player> players;
    public IEnumerable<Player> Players => this.players.AsReadOnly();

    private void Start()
    {
        this.players = new List<Player>(GameObject.FindObjectsOfType<Player>());
    }

    public Player randomPlayer()
    {
        if(this.players.Count == 0)
            return null;
        return this.players[Random.Range(0, this.players.Count)];
    }
}