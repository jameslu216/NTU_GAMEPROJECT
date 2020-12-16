using System.Collections;
using System.Collections.Generic;
using BombShooting.System;
using UnityEngine;

namespace BombShooting.Control
{
    [CreateAssetMenu(menuName = "Player/Status")]
    public class PlayerStatus : ScriptableObject
    {
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float shootCooldown;
        [SerializeField]
        private float bulletSpeed;
        private bool hasBomb;
        private bool canControl;

        public float MoveSpeed => this.moveSpeed * (this.hasBomb ? 1 : BombSystem.Instance.MoveSpeedBuff);
        public float ShootCooldown => this.shootCooldown / Mathf.Max(Mathf.Epsilon, (this.hasBomb ? 1 : BombSystem.Instance.ShootSpeedBuff));
        public float BulletSpeed => this.bulletSpeed * (this.hasBomb ? 1 : BombSystem.Instance.BulletSpeedBuff);

        public void AddBomb() => this.hasBomb = true;
        public void RemoveBomb() => this.hasBomb = false;

        private void Awake()
        {
            this.canControl = true;
            this.hasBomb = false;
        }
    }
}