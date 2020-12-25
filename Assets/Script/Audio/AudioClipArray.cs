using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BombShooting.Audio
{
    [CreateAssetMenu]
    public class AudioClipArray : ScriptableObject, IEnumerable<Sound>
    {
        //建立一個 Sound 的陣列
        public Sound[] sounds;

        public Sound this [int i] => this.sounds[i];
        public IEnumerator<Sound> GetEnumerator() => this.sounds.Cast<Sound>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}