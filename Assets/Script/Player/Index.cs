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
            DOTween.To(
                () => transform.right,
                d => transform.right = d,
                newDirection,
                0.1f
            );
        }

        private void Start()
        {
            var self = transform;
            target
                .ObserveEveryValueChanged(t => t.position - self.position)
                .Subscribe(this.updateDirection)
                .AddTo(this);
            self
                .ObserveEveryValueChanged(t => target.position - t.position)
                .Subscribe(this.updateDirection)
                .AddTo(this);
        }
    }
}