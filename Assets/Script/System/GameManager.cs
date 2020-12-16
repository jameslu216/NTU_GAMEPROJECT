using System;
using System.Collections;
using System.Collections.Generic;
using BombShooting.Utils;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace BombShooting.System
{
    public class GameManager : Singleton<GameManager>
    {
        [field : SerializeField]
        public LongReactiveProperty remainTime { get; private set; }
        public UnityEvent OnGameStart;
        public UnityEvent OnGameEnd;
        public int winTeam = -1;

        public void StartGame()
        {
            Debug.Log("Game start!");
            Observable
                .Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
                .Select(t => this.remainTime.Value)
                .TakeWhile(t => t > 0)
                .Do(_ => this.remainTime.Value--)
                .DoOnCompleted(() => this.EndGame(this.winTeam))
                .Subscribe();
            this.OnGameStart.Invoke();
        }

        // called when game end
        // pass -1 if fair
        public void EndGame(int winTeam)
        {
            Debug.Log("Game end!");
            this.OnGameEnd.Invoke();
        }
    }
}