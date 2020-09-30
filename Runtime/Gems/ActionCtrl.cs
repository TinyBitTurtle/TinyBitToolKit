using System;
using UnityEngine;

    public class ActionCtrl<C> : TinyBitTurtle.Toolkit.ActionCtrl<C> where C : MonoBehaviour
    {
        [HideInInspector]
        public Action<string> actionAudioPlay = null;
        [HideInInspector]
        public Action<GameObject> actionSpawn = null;
        [HideInInspector]
        public Action<Vector3> actionEffectPlay = null;
        [HideInInspector]
        public Action<int> actionScoreChange = null;
        [HideInInspector]
        public Action<Vector2> OnClicked = null;
        [HideInInspector]
        public Action<Vector2, Vector2> OnSwiped = null;
        [HideInInspector]
        public Action OnPinched = null;
        [HideInInspector]
        public Action actionGameplayStart = null;
        [HideInInspector]
        public Action actionGameplayStop = null;
    }
	
	