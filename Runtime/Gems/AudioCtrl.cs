using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyBitTurtle.Toolkit
{
    public class AudioCtrl<C/*class*/> : BufferedDataCtrl<C, AudoCtrl.AudioObject> where C : MonoBehaviour
    {
        [System.Serializable]
        public struct AudioObject
        {
            public enum audioType
            {
                music,
                SFX
            } 
            [HideInInspector]
            public AudioSource audioSource;

            public AudioClip[] audioClip;
            public AudioType type;
            public float volume;
            public float fadeDuration;
        }
    }
}