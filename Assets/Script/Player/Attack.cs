using System;
using BombShooting.Battle;
using UniRx;
using UnityEngine;

namespace BombShooting.Control
{
    public class Attack : MonoBehaviour
    {
        [SerializeField]
        private Gun gun;

        private void Start()
        {
            var player = GetComponent<Player>();
            var controlMap = player.controlMap;
            var canShoot = true;
            Observable
                .EveryUpdate()
                .Where(_ => Input.GetKeyDown(controlMap.attack) && canShoot == true)
                .Subscribe(_ =>
                {
                    this.gun.Shoot(player.face);
                    canShoot = false;
                    Observable
                        .Timer(TimeSpan.FromSeconds(this.gun.cooldown))
                        .Subscribe(__ => canShoot = true);
                })
                .AddTo(this);
        }
    }
}