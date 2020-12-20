using System;
using BombShooting.System;
using UniRx;
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
        public bool canControl { get; private set; }
        private IDisposable controlRecover;

        public float MoveSpeed => this.moveSpeed * (this.hasBomb ? 1 : BombSystem.Instance.MoveSpeedBuff);
        public float ShootCooldown => this.shootCooldown / Mathf.Max(Mathf.Epsilon, (this.hasBomb ? 1 : BombSystem.Instance.ShootSpeedBuff));
        public float BulletSpeed => this.bulletSpeed * (this.hasBomb ? 1 : BombSystem.Instance.BulletSpeedBuff);

        public void AddBomb()
        {
            this.hasBomb = true;
            this.canControl = false;
            // release previous stream if exist
            this.controlRecover?.Dispose();
            this.controlRecover = Observable
                .Timer(TimeSpan.FromSeconds(3))
                .Subscribe(_ => this.canControl = true);
        }
        public void RemoveBomb() => this.hasBomb = false;

        private void Awake()
        {
            this.canControl = true;
            this.hasBomb = false;
        }
    }
}