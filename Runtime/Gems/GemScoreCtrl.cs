using UnityEngine;

namespace TinyBitTurtle.Toolkit
{
    [System.Serializable]
    public class ScoreObject : MonoBehaviour
    {
    }
    public class ScoreCtrl<C/*class*/> : QueuedData<C, ScoreSettings.ScoreTemplate> where C : MonoBehaviour
    {
  
    }
}
