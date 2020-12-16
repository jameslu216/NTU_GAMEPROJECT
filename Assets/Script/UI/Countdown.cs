using BombShooting.System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BombShooting.UI
{
    [RequireComponent(typeof(Text))]
    public class Countdown : MonoBehaviour
    {
        private void Start()
        {
            Text text = GetComponent<Text>();
            GameManager.Instance.remainTime.SubscribeToText(text);
        }
    }
}