using BombShooting.Battle;
using BombShooting.System;
using UniRx;
using UnityEngine;

namespace BombShooting.Control
{
    public class Player : MonoBehaviour
    {
        [field : SerializeField]
        public PlayerStatus status { get; private set; }

        [field : SerializeField]
        public ControlMap controlMap { get; private set; }
        public Vector2ReactiveProperty face;

        private void Start()
        {
            this.face.Value = Vector2.right;
            this.face.Subscribe(dir =>
            {
                transform.right = dir;
            });
        }

        public void OnDamage(Bullet bullet)
        {
            BombSystem.Instance.SwitchTarget(this);
        }
    }
}