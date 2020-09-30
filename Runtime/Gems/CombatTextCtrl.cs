using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TinyBitTurtle.Toolkit
{
    public class CombatTextCtrl<C/*class*/> : BufferedDataCtrl<C, CombatTextCtrl.CombatText> where C : MonoBehaviour
    {
        public CombatTextCtrlSettings settings;

        public class CombatText : MonoBehaviour
        {
            private float parametric;
            private float lifeSpan;
            private float age;
            private bool alive;
            private float alpha;
            private PooledObject pooledObject;

            public void NewText(string message, float duration, float speed, float angle)
            {
                // grab an object in pool
                GameObject newGameObject;
                combatText.NewText(pos, out newGameObject);
                // the angle of ejection
                float angle = Mathf.Clamp(ejectionAngle + UnityEngine.Random.Range(-spreadAngle * 0.5f, spreadAngle * 0.5f), -180, 180);
                // references
                CombatText NewCombatText = newGameObject.GetComponent<CombatText>();
                NewCombatText.Init(message, duration, speed, angle);
                pooledObject = GetComponent<PooledObject>();
                // message
                GetComponent<UILabel>().text = message;
                // initialize data
                parametric = 1;
                age = lifeSpan = duration;
                Vector3 speedVector = Vector3.up * speed;
                Vector3 ejectionVector = Quaternion.AngleAxis(angle, Vector3.forward) * speedVector;
                // movement physics
                Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
                rigidbody2D.gravityScale = settings.gravity;
                rigidbody2D.AddForce(ejectionVector, ForceMode2D.Impulse);
                // this text is visible
                alpha = GetComponent<UILabel>().alpha;
                alive = true;
            }
            
            private void Update()
            {
                if (alive == false)
                {
                    gameObject.SetActive(false);
                    return;
                }
                // curve position
                age -= Time.deltaTime;
                parametric = age / lifeSpan;
                // alpha changes
                alpha = settings.fadeCurve.Evaluate(parametric);
                // size changes
                float newSize = settings.sizeCurve.Evaluate(parametric) * settings.size;
                transform.localScale = new Vector3(newSize, newSize, newSize);
                // dead!
                if (age < 0)
                {
                    // trurn off
                    pooledObject.Disable();
                    alive = false;
                }
            }
            
            public float duration = 1;
            public float speed = 0.5f;
            [Range(0, 359)]
            public float ejectionAngle = 0.0f;
            [Range(-180, 180)]
            public float spreadAngle = 0.0f;
            public Level[] levels;

             [Serializable]
            public struct Level
            {
                public Color color;
                public string name;
                public float level;
            }

             public enum eLevel
            {
                fail = -1,
                normal,
                elevated,
                critical
            }
        }

        public CombatText combatText;
    }
}