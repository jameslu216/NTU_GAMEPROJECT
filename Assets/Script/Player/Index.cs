using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace BombShooting.Control
{
    public class Index : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        private void updateDirection(Vector3 newDirection)
        {
            // DOTween.To(
            //     () => transform.right,
            //     d => transform.right = d,
            //     newDirection,
            //     0.1f
            // );
            transform.right = newDirection;
        }

        private void Start()
        {
            var self = transform;
            target
                .ObserveEveryValueChanged(t => t.position)
                .Subscribe(pos =>
                {

                    this.updateDirection(pos - self.position);
                })
                .AddTo(this);
            self
                .ObserveEveryValueChanged(t => t.position)
                .Subscribe(pos =>
                {
                    // Debug.Log($"{gameObject.name}: {target.position} / {pos}");
                    this.updateDirection(target.position - pos);
                })
                .AddTo(this);
        }
    }
}