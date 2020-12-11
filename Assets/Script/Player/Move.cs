using System.Linq;
using UniRx;
using UnityEngine;

namespace BombShooting.Control
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Move : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        private Vector2[] dirs = new []
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right,
        };

        private void Start()
        {
            var rb2d = GetComponent<Rigidbody2D>();
            var controlMap = GetComponent<Player>().controlMap;
            Observable
                .EveryUpdate()
                .Select(_ => new []
                {
                    controlMap.up,
                        controlMap.down,
                        controlMap.left,
                        controlMap.right,
                })
                .Subscribe(keyCodes =>
                {
                    rb2d.velocity = keyCodes
                        .Zip(
                            this.dirs,
                            (keyCode, dir) => dir * (Input.GetKey(keyCode) ? 1 : 0)
                        )
                        .Aggregate((x, y) => x + y)
                        .normalized * this.speed;
                })
                .AddTo(this);
        }
    }
}