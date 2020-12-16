using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombShooting.Control
{
    public class Player : MonoBehaviour
    {
        [field : SerializeField]
        public ControlMap controlMap { get; private set; }
        public Vector2 face;

        private void Start()
        {
            this.face = Vector2.right;
        }
    }
}