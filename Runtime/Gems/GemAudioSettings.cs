using UnityEngine;

namespace TinyBitTurtle.Toolkit
{
    [CreateAssetMenu]
    public class AudioSettings
    { 
        public class AudioTemplate : Core_Template
        {
            public enum AudioType
            {
                music,
                SFX
            }
            public AudioType audioType;
            [Range(0, 1)]
            public float volume;
            public int fadeDuration = -1;
            public AudioClip[] audioClips;
        }
    }
}