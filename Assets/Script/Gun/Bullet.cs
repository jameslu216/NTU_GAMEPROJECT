using System;
using System.Collections;
using System.Collections.Generic;
using BombShooting.Control;
using UniRx;
using UnityEngine;

namespace BombShooting.Battle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float lifetime;
        private Rigidbody2D rb2d;
        private Dictionary<string, Action<GameObject>> collisionCallbacks;

        private void Awake()
        {
            this.collisionCallbacks = new Dictionary<string, Action<GameObject>>()
            { { "Player", this.OnPlayerCollision }, { "Wall", this.OnWallCollision },
            };
            this.rb2d = GetComponent<Rigidbody2D>();
            Observable
                .Timer(TimeSpan.FromSeconds(this.lifetime))
                .Subscribe(_ => Destroy(gameObject));
        }

        public Vector2 velocity
        {
            get => this.rb2d.velocity;
            set => this.rb2d.velocity = value;
        }

        private void OnPlayerCollision(GameObject player)
        {
            var p = player.GetComponent<Player>();
            Debug.Assert(p, "Can not find player component!");
            p.OnDamage(this);
        }

        private void OnWallCollision(GameObject wall)
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var tags = new [] { "Player", "Wall" };
            foreach(var tag in tags)
            {
                if(other.gameObject.CompareTag(tag))
                {
                    this.collisionCallbacks[tag](other.gameObject);
                    break;
                }
            }
        }
    }
}