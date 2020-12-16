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
            var canShoot = true;
            Observable
                .EveryUpdate()
                .Where(_ => Input.GetKeyDown(player.controlMap.attack) && canShoot == true)
                .Subscribe(_ =>
                {
                    this.gun.Shoot(player.face);
                    canShoot = false;
                    // disable shoot for a while
                    Observable
                        .Timer(TimeSpan.FromSeconds(player.status.ShootCooldown))
                        .Subscribe(__ => canShoot = true);
                })
                .AddTo(this);
        }
    }
}