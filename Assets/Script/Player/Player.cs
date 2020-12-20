using System.Collections;
using System.Collections.Generic;
using BombShooting.Battle;
using BombShooting.System;
using UnityEngine;

namespace BombShooting.Control
{
    public class Player : MonoBehaviour
    {
        [field : SerializeField]
        public PlayerStatus status { get; private set; }

        [field : SerializeField]
        public ControlMap controlMap { get; private set; }
        public Vector2 face;

        private void Start()
        {
            this.face = Vector2.right;
        }

        public void OnDamage(Bullet bullet)
        {
            BombSystem.Instance.SwitchTarget(this);
        }
    }
}