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
        var newPosition = target.position;
        newPosition.z = -10;
        transform.position = newPosition;
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