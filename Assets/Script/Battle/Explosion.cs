using DG.Tweening;
using UniRx;
using UnityEngine;

namespace BombShooting.Battle
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField]
        private Transform mask;
        [SerializeField]
        private Transform circle;

        void Start()
        {
            this.mask.localScale = this.circle.localScale = Vector3.zero;
            DOTween.Sequence()
                .Join(this.mask.DOScale(Vector3.one, 0.8f))
                .Join(this.circle.DOScale(Vector3.one, 0.6f))
                .SetEase(Ease.OutCubic)
                .OnComplete(() => Destroy(gameObject));
        }
    }
}