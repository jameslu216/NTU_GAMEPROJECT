using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombShooting.Battle
{
    public class Team : MonoBehaviour
    {
        [field : SerializeField]
        public string teamName { get; private set; }

        public bool IsPartner(Team other) => this.teamName.CompareTo(other.teamName) == 0;
    }
}