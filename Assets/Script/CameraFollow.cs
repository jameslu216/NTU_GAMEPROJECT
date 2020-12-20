using System.Collections;
using System.Collections.Generic;
using BombShooting.Control;
using BombShooting.Utils;
using UniRx;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void Start()
    {
        transform
            .Follow(
                target,
                smooth : 0.45f,
                lockZ : true
            )
            .Subscribe()
            .AddTo(this);
    }
}