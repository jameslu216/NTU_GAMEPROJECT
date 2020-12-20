﻿using System;
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
        public Team team;

        private void Awake()
        {
            this.rb2d = GetComponent<Rigidbody2D>();
            Observable
                .Timer(TimeSpan.FromSeconds(this.lifetime))
                .Subscribe(_ => Destroy(gameObject))
                .AddTo(this);
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                if(other.gameObject.GetComponent<Team>().IsPartner(this.team))
                    return;
                this.OnPlayerCollision(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}