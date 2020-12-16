﻿using BombShooting.Battle;
using BombShooting.Control;
using BombShooting.Utils;
using UniRx;
using UnityEngine;

namespace BombShooting.System
{
    public class BombSystem : Singleton<BombSystem>
    {
        [field : SerializeField]
        public float MoveSpeedBuff { get; private set; }

        [field : SerializeField]
        public float BulletSpeedBuff { get; private set; }

        [field : SerializeField]
        public float ShootSpeedBuff { get; private set; }

        private Player target;

        void Start()
        {
            this.target = PlayerSystem.Instance.randomPlayer();
            this.target.status.AddBomb();
            GameManager.Instance.remainTime
                .Where(t => t == 0)
                .Subscribe(t => GameManager.Instance.loser = target.GetComponent<Team>())
                .AddTo(this);
        }

        public void SwitchTarget(Player newTarget)
        {
            if(this.target == newTarget)
            {
                Debug.Log("The same player got the bomb!");
                return;
            }
            this.target.status.RemoveBomb();
            this.target = newTarget;
            this.target.status.AddBomb();
        }
    }
}