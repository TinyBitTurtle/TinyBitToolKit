using UnityEngine;
using System.Collections;

namespace TinyBitTurtle.Toolkit
{
    public class FloatFadeCtrl : SingletonMonoBehaviour<FloatFadeCtrl>
    {
        public enum Direction
        {
            NoFade,
            FadeIn,
            FadeOut,
        }

        protected virtual void BeginFade()
        {
        }

        protected virtual void EndFade()
        {
        }

        public void Fade(float duration, Direction direction, float fadeProperty)
        {
            StartCoroutine(FadeCoroutine(duration, direction, fadeProperty));
        }

        private IEnumerator FadeCoroutine(float duration, Direction direction, float fadeProperty)
        {
            // fade direction
            bool fadeIn = (direction == Direction.FadeIn);
            // fade step
            float step = fadeIn ? 1 * (1f / duration) : -1 * (1f / duration);
            // fade to
            float fadeTarget = fadeIn ? fadeProperty : 0;
            // starting fade value
            float fadeValue = fadeIn ? 0 : fadeProperty;
            BeginFade();
            //actionStartFade?.Invoke(fadeValue);

            // we loop until target is reached
            while (fadeIn ? fadeValue < fadeTarget : fadeValue > fadeTarget)
            {
                // calculate the new value
                fadeValue += Time.deltaTime * step;
                // set the volume to the new value
                fadeProperty = fadeValue;

                yield return null;
            }

              //actionEndFade?.Invoke(fadeValue);soundObject.audioSource.Stop();
            EndFade();

            fadeProperty = fadeTarget;
        }  
    }
}