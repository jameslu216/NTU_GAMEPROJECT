using BombShooting.Battle;
using BombShooting.System;
using BombShooting.Utils;
using DG.Tweening;
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
            this.face
                .Subscribe(dir =>
                {
                    transform.right = dir;
                })
                .AddTo(this);
            var sr = GetComponent<SpriteRenderer>();
            // TODO: mayber a better way to extend color method...
            var originalColor = Color.black.Copy(sr.color);
            this.status.hasBomb
                .Subscribe(bomb =>
                    sr.DOColor(
                        bomb ? Color.gray : originalColor,
                        0.5f
                    )
                )
                .AddTo(this);
        }

        public void OnDamage(Bullet bullet)
        {
            BombSystem.Instance.SwitchTarget(this);
        }
    }
}