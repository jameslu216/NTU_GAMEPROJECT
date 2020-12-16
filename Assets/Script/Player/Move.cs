using System.Linq;
using UniRx;
using UnityEngine;

namespace BombShooting.Control
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Move : MonoBehaviour
    {
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
            var player = GetComponent<Player>();
            var controlMap = player.controlMap;
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
                    var velocity = keyCodes
                        .Zip(
                            this.dirs,
                            (keyCode, dir) => dir * (Input.GetKey(keyCode) ? 1 : 0)
                        )
                        .Aggregate((x, y) => x + y)
                        .normalized * player.status.MoveSpeed;
                    rb2d.velocity = velocity;
                    if(velocity != Vector2.zero)
                        player.face = rb2d.velocity;
                })
                .AddTo(this);
        }
    }
}