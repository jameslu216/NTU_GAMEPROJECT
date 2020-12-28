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
            Tween tween = null;
            this.face.Value = Vector2.right;
            this.face
                .Select(dir => Vector3.SignedAngle(Vector2.right, dir, Vector3.forward))
                .Subscribe(deg =>
                {
                    tween?.Complete();
                    tween = transform
                        .DORotate(
                            Quaternion.Euler(0, 0, deg).eulerAngles,
                            Mathf.Lerp(0.3f, 0.7f, (deg - Quaternion.Euler(transform.right).z) / 180)
                        )
                        .SetEase(Ease.OutQuad);
                })
                .AddTo(this);
            var sr = GetComponent<SpriteRenderer>();
            // TODO: mayber a better way to extend color method...
            var originalColor = Color.black.Copy(sr.color);
            this.status.hasBomb
                .Subscribe(bomb =>
                {
                    sr.DOColor(
                        bomb ? Color.red : originalColor,
                        0.5f
                    );
                })
                .AddTo(this);
        }

        public void OnDamage(Bullet bullet) => BombSystem.Instance.SwitchTarget(this);
    }
}