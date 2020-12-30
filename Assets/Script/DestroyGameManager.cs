using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BombShooting.System;
public class DestroyGameManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnGameEnd.AddListener(() => {
            Destroy(GameManager.Instance.gameObject);
        });
    }
}
