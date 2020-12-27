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

        void Start()
        {
            this.start.onClick.AddListener(() => SceneManager.LoadScene("GameScene 1"));
            this.exit.onClick.AddListener(() => Application.Quit());
        }
    }
}