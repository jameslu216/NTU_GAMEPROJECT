using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombShooting.Battle
{
    public class Gun : MonoBehaviour
    {
        [SerializeField]
        private GameObject bullet;
        [SerializeField]
        private float bulletSpeed;
        [field : SerializeField]
        public float cooldown { get; private set; }

        public void Shoot(Vector2 dir)
        {
            var newBullet = Instantiate(
                this.bullet,
                transform.position,
                Quaternion.Euler((Vector3) dir)
            ).GetComponent<Bullet>();
            newBullet.velocity = dir.normalized * this.bulletSpeed;
        }
    }
}