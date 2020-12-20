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
                    DOTween.To(
                        () => transform.right,
                        v => transform.right = v,
                        (Vector3) dir,
                        0.3f
                    );
                })
                .AddTo(this);
            var sr = GetComponent<SpriteRenderer>();
            // TODO: mayber a better way to extend color method...
            var originalColor = Color.black.Copy(sr.color);
            this.status.hasBomb
                .Subscribe(bomb =>
                {
                    Debug.Log(gameObject.name + " got a bomb? " + bomb);
                    sr.DOColor(
                        bomb ? Color.red : originalColor,
                        0.5f
                    );
                })
                .AddTo(this);
        }

        public void OnDamage(Bullet bullet)
        {
            BombSystem.Instance.SwitchTarget(this);
        }
    }
}