using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BombShooting.System;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{
    public Image black;

    void Start()
    {
        GameManager.Instance.OnGameEnd.AddListener(() => {
            this.black.DOColor(Color.black, 0.3f);
        });
    }
}
