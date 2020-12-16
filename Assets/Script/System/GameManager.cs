using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace BombShooting.System
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int remainTime;
        public ReactiveProperty<long> remainTimeObservable { get; private set; } = new ReactiveProperty<long>();

        void Start()
        {
            this.remainTimeObservable.Value = this.remainTime;
        }

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