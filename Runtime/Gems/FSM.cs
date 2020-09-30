using UnityEngine;

public class FSM : MonoBehaviour
{
    protected Animator animator;

    /// <summary>
    /// default state
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}