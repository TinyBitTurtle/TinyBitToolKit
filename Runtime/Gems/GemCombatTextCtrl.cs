using UnityEngine;
using System.Collections;

namespace TinyBitTurtle.Toolkit
{
    public class CombatTextCtrl<C/*class*/> : QueuedData<C, CombatTextSettings.CombatTextTemplate> where C : MonoBehaviour
    {
         [System.Serializable]
        public struct Level
        {
            public Color color;
            public string name;
            public float level;
        }

        public Level[] levels;

         [System.Serializable]
        public class CombatTextObject : MonoBehaviour
        {
            private float parametric;
            private float age;
            private bool alive;
            private float alpha;
            public CombatTextSettings settings;

            private void Update()
            {
                UpdateCombatTextObject();
            }
            
            private void UpdateCombatTextObject()
            {
                if (alive == false)
                {
                    gameObject.SetActive(false);
                    return;
                }
                // age changes
                age -= Time.deltaTime;
                parametric = age / template.lifeSpan;
                // alpha changes
                alpha = settings.fadeCurve.Evaluate(parametric);
                // size changes
                float newSize = settings.sizeCurve.Evaluate(parametric) * template.size;
                transform.localScale = new Vector3(newSize, newSize, newSize);
                // dead!
                if (age < 0)
                {
                    // turn off
                    PooledObject pooledObject = GetComponent<PooledObject>();
                    pooledObject.Disable();
                    alive = false;
                }
            }

        
            public enum Fade
            {
                FadeIn,
                FadeOut,
            }
            
            private void OnEnable()
            {
                // hook up the actions
                actionPopData += PlayCombatText;
            }

            private void OnDisable()
            {
                // disconnect the actions
                actionPopData -= PlayCombatText;
            }

            private void QueueCombatText(CombatTextSettings.CombatTextTemplate combatTextTemplate)
            {
        
            }

            // Play the Audio Sample
            private void PlayCombatText(CombatTextSettings.CombatTextTemplate combatTextTemplate)
            {
                // illegal template
            }
            
            private static IEnumerator CombatTextFade(CombatTextObject combatTextObject, CombatTextSettings.CombatTextTemplate combatTextTemplate, Fade fade)
            {
                // fade direction

                yield return null;
            
            }

            public void NewText(string message, float duration, float speed, float angle)
            {
                
            }
        }
    }
}