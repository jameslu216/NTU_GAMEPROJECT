using BombShooting.Control;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace BombShooting.UI
{
    public class PlayerViewMask : MonoBehaviour
    {
        [SerializeField]
        private PlayerStatus status;

        protected void Start()
        {
            var rect = GetComponent<RectTransform>();
            this.status.hasBomb
                .Select(bomb => bomb ? 2 : 1)
                .Subscribe(scalar =>
                    rect
                    .DOScale(Vector3.one * scalar, 1)
                    .SetEase(Ease.InOutBounce)
                )
                .AddTo(this);
        }
    }
}