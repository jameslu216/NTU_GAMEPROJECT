using System.Collections.Generic;
using System.Linq;
using BombShooting.Audio;
using BombShooting.Utils;
using UnityEngine;

namespace BombShooting.System
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField]
        // 儲存音檔資訊的 list
        private AudioClipArray sceneClipArray = null;
        [SerializeField]
        private bool destroyOnLoad;
        // 名稱對應到音檔的Dictionary
        private Dictionary<string, AudioSource> name2Audio = new Dictionary<string, AudioSource>();

        private void Start()
        {
            if(sceneClipArray) // 如果儲存音檔資訊的 list 不是 null
            {
                // 遍歷這個 list 裡的所有東西
                foreach(Sound s in sceneClipArray)
                {
                    // 新增一個空的 AudioSource
                    AudioSource audio = gameObject.AddComponent<AudioSource>();
                    // 幫新增的 AudioSource 填資料
                    s.InitAudioSource(audio);
                    // 把名字和 AudioSource 的 pair 新增到 dictionary 內
                    name2Audio.Add(s.name, audio);
                }
            }
            else
            {
                Debug.LogWarning("Clip array is not assigned!");
            }
        }

        protected override bool shouldDestroy() => this.destroyOnLoad;

        private AudioSource requireAudio(string name)
        {
            if(!this.name2Audio.ContainsKey(name))
            {
                Debug.LogError($"Audio source ({name}) not found!");
                return null;
            }
            return this.name2Audio[name];
        }

        public void PlayByName(string name)
        {
            var audio = this.requireAudio(name);
            // stop first (it may be playing now)
            audio?.Stop();
            audio?.Play();
        }

        public void StopByName(string name)
        {
            this.requireAudio(name)?.Stop();
        }

        public void StopAll()
        {
            // 對於每個在 Dictionary 內的 AudioSource
            // 如果這個音效正在播放，暫停播放
            name2Audio.Values
                .Where(audio => audio.isPlaying)
                .ToList()
                .ForEach(audio => audio.Stop());
        }
    }
}