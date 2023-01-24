using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        controller = FindObjectOfType<InputManager>();
        controller.OnJump.AddListener(Jump);
        controller.OnAction.AddListener(Action);
        filter.mesh = Mesh;
        SetEquipment(Equipment);
    }

    private void OnDisable()
    {
        controller.OnJump.RemoveListener(Jump);
        controller.OnAction.RemoveListener(Action);
    }

    public override void Jump()
    {
        if (IsGrounded())
        {
            timesJumped = 0;
        }

        if (timesJumped < jumpAmount)
        {
            float tempJumpForce = jumpForce + Equipment.JumpMod;
            rb.AddForce(Vector3.up * tempJumpForce, ForceMode.Impulse);
            timesJumped++;
        }
    }

    public override void Action()
    {
        this.transform.position += new Vector3(0, 0, 10);
    }
}
