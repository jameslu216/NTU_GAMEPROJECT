using System;
using System.Collections;
using System.Collections.Generic;
using BombShooting.Utils;
using UniRx;
using UnityEngine;

namespace BombShooting.System
{
    public class GameManager : Singleton<GameManager>
    {
        [field : SerializeField]
        public LongReactiveProperty remainTime { get; private set; }

        public void StartGame()
        {
            Debug.Log("Game start!");
            Observable
                .Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
                .Select(t => this.remainTime - t)
                .TakeWhile(t => t > 0)
                .Do(_ => this.remainTimeObservable.Value--)
                .DoOnCompleted(() => this.endGame(-1))
                .Subscribe();
        }

        // called when game end
        // pass -1 if fair
        private void endGame(int winTeam)
        {
            Debug.Log("Game end!");
        }
    }
}