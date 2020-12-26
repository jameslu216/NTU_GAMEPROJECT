using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace BombShooting.Utils
{
    public class Follow : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        void Start()
        {
            transform
                .Follow(target, smooth : 1)
                .Subscribe()
                .AddTo(this);
        }
    }
}