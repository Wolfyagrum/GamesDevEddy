using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private FixedJoystick joyStick;

    public Vector2 movement;


    public UnityEvent OnJump;
    public UnityEvent OnAction;

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = new Vector2(joyStick.Horizontal, joyStick.Vertical);
    }

    public void JumpInput()
    {
        OnJump.Invoke();
    }

    public void Action()
    {
        OnAction.Invoke();
    }
}
