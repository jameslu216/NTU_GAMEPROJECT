using BombShooting.System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BombShooting.UI
{
    public class Countdown : MonoBehaviour
    {
        private void Start()
        {
            TMP_Text text = GetComponent<TMP_Text>();
            GameManager.Instance.remainTime
                .Subscribe(str =>
                {
                    text.text = str.ToString();
                });
        }
    }
}