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
        public BoolReactiveProperty hasBomb { get; private set; }
        public bool canControl { get; private set; }
        private IDisposable controlRecover;

        public float MoveSpeed => this.moveSpeed * (this.hasBomb.Value ? 1 : BombSystem.Instance.MoveSpeedBuff);
        public float ShootCooldown => this.shootCooldown / Mathf.Max(Mathf.Epsilon, (this.hasBomb.Value ? 1 : BombSystem.Instance.ShootSpeedBuff));
        public float BulletSpeed => this.bulletSpeed * (this.hasBomb.Value ? 1 : BombSystem.Instance.BulletSpeedBuff);

        public void AddBomb()
        {
            if(!this.canControl)
                return;
            this.hasBomb.Value = true;
            this.canControl = false;
            // release previous stream if exist
            this.controlRecover?.Dispose();
            this.controlRecover = Observable
                .Timer(TimeSpan.FromSeconds(3))
                .Subscribe(_ => this.canControl = true);
        }

        public void RemoveBomb() => this.hasBomb.Value = false;

        private void OnEnable() => this.Reset();

        public void Reset()
        {
            this.canControl = true;
            this.hasBomb = new BoolReactiveProperty(false);
        }

    }
}