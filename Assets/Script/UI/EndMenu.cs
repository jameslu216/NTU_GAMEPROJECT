using BombShooting.System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private Button restart;
    [SerializeField]
    private Button exit;
    [SerializeField]
    private Image black;

    void Start()
    {
        this.text.text = $"{GameManager.Instance.loser.teamName} lose!";
        var gameManager = GameObject.Find("GameManager");
        if(gameManager)
            Destroy(gameManager);
        this.restart.onClick.AddListener(() =>
        {
            this.black
                .DOColor(Color.black, 0.3f)
                .OnComplete(() => SceneManager.LoadScene("Level1"));
        });
        this.exit.onClick.AddListener(Application.Quit);
    }
}