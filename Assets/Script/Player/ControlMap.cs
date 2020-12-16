using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombShooting.Control
{
    [CreateAssetMenu(menuName = "Player/Control Map")]
    public class ControlMap : ScriptableObject
    {
        public KeyCode up;
        public KeyCode down;
        public KeyCode left;
        public KeyCode right;
        public KeyCode attack;
    }
}