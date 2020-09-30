using UnityEngine;
namespace TinyBitTurtle.Toolkit
{
    [CreateAssetMenu]
    public class CombatTextCtrlSettings : ScriptableObject
    {
        public AnimationCurve fadeCurve;
        public AnimationCurve sizeCurve;
        public float size = 1f;
        public float gravity = 0.1f;
        public float lifespan = 2.0f;
    }
    
}
