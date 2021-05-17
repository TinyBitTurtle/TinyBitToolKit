using UnityEngine.SceneManagement;
using UnityEngine;

namespace TinyBitTurtle.Toolkit
{
    public class GameFlowCtrl : FSM
    {
        // register the Screen change event
        void OnEnable()
        {
            TransitionCtrl.OnMidFade += UISwitchPanel;
        }

        void OnDisable()
        {
            TransitionCtrl.OnMidFade -= UISwitchPanel;
        }

        // switch state
        public void UISwitchPanel(UnityEngine.Object triggerName)
        {
            animator.ResetTrigger(triggerName.name);
            animator.SetTrigger(triggerName.name);
        }
    }

     [System.Serializable]
        public class GameFlowState : FSMState
        {
            public Object scene;
            public string panelName;

            private GameObject panelInstance;

            /// reset all panels
            private void Awake()
            {
                panelInstance = GameObject.Find(panelName);

                // position at 0,0,0 and make panel invisible
                if (panelInstance)
                {
                    panelInstance.transform.position = Vector3.zero;
                    panelInstance.SetActive(false);
                }
            }

            override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                if (panelInstance != null)
                    panelInstance.SetActive(true);

                if (scene != null)
                    SceneManager.LoadScene(scene.name, LoadSceneMode.Additive);
            }

            override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                if (panelInstance != null)
                    panelInstance.SetActive(false);

                if (scene != null)
                    SceneManager.UnloadSceneAsync(scene.name);
            }
        }
}