using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace BombShooting.System
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get => _instance;
        }

        [field : SerializeField]
        public LongReactiveProperty remainTime { get; private set; }

        void Start()
        {
            if(_instance)
            {
                Debug.LogError("Duplicated game manager");
                Destroy(this);
            }
            _instance = this;
        }

        public void StartGame()
        {
            Debug.Log("Game start!");
            Observable
                .Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
                .Select(_ => this.remainTime.Value)
                .TakeWhile(t => t > 0)
                .Do(_ => this.remainTime.Value--)
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