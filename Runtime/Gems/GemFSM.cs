using UnityEngine;

namespace TinyBitTurtle.Toolkit
{
    public class FSM : MonoBehaviour
    {
        protected Animator animator;

        // cache the animator
        private void Start()
        {
            animator = GetComponent<Animator>();
        }
    }

    public class FSMState : StateMachineBehaviour
    {
    }
}