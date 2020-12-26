using BombShooting.Control;
using BombShooting.System;
using UnityEngine;

namespace BombShooting.Battle
{
    public class Gun : MonoBehaviour
    {
        [SerializeField]
        private GameObject bullet;
        private Player owner;
        private Team team;

        private void Start()
        {
            this.owner = GetComponentInParent<Player>();
            this.team = this.owner.gameObject.GetComponent<Team>();
        }

        public void Shoot(Vector2 dir)
        {
            var newBullet = Instantiate(
                this.bullet,
                transform.position,
                Quaternion.identity
            ).GetComponent<Bullet>();
            newBullet.transform.right = dir;
            newBullet.velocity = dir.normalized * owner.status.BulletSpeed;
            newBullet.team = this.team;
            AudioManager.Instance.PlayByName("shoot");
        }
    }
}