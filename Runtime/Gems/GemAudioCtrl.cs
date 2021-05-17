using UnityEngine;

namespace TinyBitTurtle.Toolkit
{
    public class AudioCtrl<C/*class*/> : QueuedData<C, AudioSettings.AudioTemplate> where C : MonoBehaviour
    {
        [System.Serializable]
        public class AudioObject
        {
            [HideInInspector]
            public AudioSource audioSource;
            public AudioClip audioClip;
        }
        
        public AudioSettings settings;
        private AudioObject lastMusic;

        private void OnEnable()
        {
            // hook up the action to be perform coming out of the data buffer
            actionPopData += PlayAudio;
        }

        private void OnDisable()
        {
            // disconnect the action to be perform coming out of the buffer
            actionPopData -= PlayAudio;
        }

        // Play the Audio Sample
        private void PlayAudio(AudioSettings.AudioTemplate audioTemplate)
        {
            // illegal audio template
            if (audioTemplate == null)
                return;
            
            // build AudioObject based on AudioTemplate
            AudioObject audioObject = Gems_Factory<AudioObject, AudioSettings.AudioTemplate>.Create(audioTemplate);

            // random sounds id multiple clips are specified
            int whichSound = 0;
            if (audioTemplate.audioClips.Length > 1)
            {
                whichSound = UnityEngine.Random.Range(0, audioTemplate.audioClips.Length);
            }
            // hook up random clip to source
            audioObject.audioSource.clip = audioTemplate.audioClips[whichSound];

            // we are dealing with musics
            if (audioTemplate.audioType == AudioSettings.AudioTemplate.AudioType.music)
            {
                // optional fade
                if (lastMusic.audioSource != null)
                {
                    if (audioTemplate.fadeDuration > 0)
                    {
                        FloatFadeCtrl.Instance.Fade(audioTemplate.fadeDuration, FloatFadeCtrl.Direction.FadeOut, lastMusic.audioSource.volume);
                        lastMusic.audioSource = null;
                    }
                    else
                    {
                        // stop prev music
                        lastMusic.audioSource.Stop();
                    }
                }

                // remenber the last music
                lastMusic = audioObject;
            }

            // optional volume specified
            if (audioTemplate.volume != 0)
                audioObject.audioSource.volume = audioTemplate.volume;
  
            // optional fade
            if (audioTemplate.fadeDuration != 0)
                FloatFadeCtrl.Instance.Fade(audioTemplate.fadeDuration, FloatFadeCtrl.Direction.FadeIn, lastMusic.audioSource.volume);

            audioObject.audioSource.Play();
        }

        private void StopAudio(AudioObject audioObject)
        {
            audioObject.audioSource.Stop();
        }
    }
}