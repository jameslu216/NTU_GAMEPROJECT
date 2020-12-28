using BombShooting.System;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BombShooting.UI
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField]
        private Color warning;

        private void Start()
        {
            TMP_Text text = GetComponentInChildren<TMP_Text>();
            Image image = GetComponentInChildren<Image>();
            GameManager.Instance.remainTime
                .TakeWhile(t => t > 10)
                .DoOnCompleted(() => image.DOColor(this.warning, 0.5f))
                .Subscribe()
                .AddTo(this);
            GameManager.Instance.remainTime
                .Subscribe(str =>
                {
                    text.text = str.ToString();
                })
                .AddTo(this);
        }
    }
}