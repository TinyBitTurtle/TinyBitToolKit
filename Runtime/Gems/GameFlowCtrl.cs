namespace TinyBitTurtle
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
}