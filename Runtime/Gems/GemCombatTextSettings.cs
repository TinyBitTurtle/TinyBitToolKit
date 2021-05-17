using UnityEngine;

namespace TinyBitTurtle.Toolkit
{
    public enum eLevel
    {
        fail = -1,
        normal,
        elevated,
        critical
    }

    [CreateAssetMenu]
    public class CombatTextSettings : ScriptableObject
    {
        public AnimationCurve fadeCurve;
        public AnimationCurve sizeCurve;
        public float ejectionAngle;
        public float spreadAngle;
        public float speed = 0.5f;
        public float gravity = 0.1f;
        public class CombatTextTemplate : ATemplate
        {
            public float size = 1f;
            public float lifespan = 2.0f;
            public float duration = 1;
        }        
    }
}
