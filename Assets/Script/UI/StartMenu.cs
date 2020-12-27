using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace BombShooting.UI
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField]
        private Button start;
        [SerializeField]
        private Button exit;
        [SerializeField]
        private Image black;

        void Start()
        {
            this.start.onClick.AddListener(() =>
            {
                this.black
                    .DOColor(Color.black, 0.3f)
                    .OnComplete(() => SceneManager.LoadScene("GameScene 1"));
            });
            this.exit.onClick.AddListener(() => Application.Quit());
        }
    }
}