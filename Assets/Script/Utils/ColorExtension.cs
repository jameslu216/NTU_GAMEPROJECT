using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombShooting.Utils
{
    public static class ColorExtension
    {
        public static Color Copy(this Color self, Color other)
        {
            return new Color(other.r, other.g, other.b, other.a);
        }
    }
}