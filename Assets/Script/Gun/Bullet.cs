using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombShooting.Battle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D rb2d;

        private void Awake()
        {
            this.rb2d = GetComponent<Rigidbody2D>();
        }

        public Vector2 velocity
        {
            get => this.rb2d.velocity;
            set => this.rb2d.velocity = value;
        }
    }
}