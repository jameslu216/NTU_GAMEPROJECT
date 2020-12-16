using System.Collections;
using System.Collections.Generic;
using BombShooting.Control;
using BombShooting.Utils;
using UnityEngine;

namespace BombShooting.System
{
    public class BombSystem : Singleton<BombSystem>
    {
        private Player target;

        void Start()
        {
            this.target = PlayerSystem.Instance.randomPlayer();
        }

        public void SwitchTarget(Player newTarget)
        {
            if(this.target == newTarget)
            {
                Debug.Log("The same player got the bomb!");
                return;
            }
            this.target = newTarget;
        }
    }
}