using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public InputManager controller;
    public EquipmentManager equipmentManager;

    public float moveSpeed;
    public float jumpForce;
    public float jumpRay;
    public float interactDistance;
    public int jumpAmount;
    public int timesJumped;

    private bool canJump = true;

    public Mesh Mesh;
    public MeshFilter filter;
    public MeshRenderer MeshRenderer;
    public Equipment Equipment;

    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Awake()
    {
        controller = FindObjectOfType<InputManager>();
        equipmentManager = FindObjectOfType<EquipmentManager>();
        print(equipmentManager);
        SetEquipment(equipmentManager.GetRandomEquipment());
        rb = GetComponent<Rigidbody>();
        MeshRenderer = GetComponent<MeshRenderer>();
        controller.OnJump.AddListener(Jump);
        controller.OnAction.AddListener(Action);
        filter = GetComponent<MeshFilter>();
    }

    public virtual void FixedUpdate()
    {
        rb.velocity = new Vector3(controller.movement.x * (moveSpeed + Equipment.SpeedMod), rb.velocity.y, controller.movement.y * (moveSpeed + Equipment.SpeedMod));
    }

    public virtual void Jump()
    {
        if (IsGrounded())
        {
            timesJumped = 0;
        }

        if (timesJumped < jumpAmount)
        {
            float tempJumpForce = jumpForce + Equipment.JumpMod;
            rb.AddForce(Vector3.up * tempJumpForce, ForceMode.Impulse);
            print(Equipment.JumpMod);
            timesJumped++;
        }
    }

    public bool IsGrounded()
    {
        bool hitGround = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, jumpRay, groundLayer);
        Debug.DrawRay(transform.position, Vector3.down * jumpRay, Color.red);
        return (hitGround);
    }

    public virtual void Action()
    {
        print("normal player");
    }

    public void SetEquipment(Equipment equipment)
    {
        if(equipment == Equipment)
        {
            print(equipment.ToString());
            return;
        }
        else
        {
            if (equipment != null)
            {
                Equipment = equipment;
                MeshRenderer.material.color = Equipment.color;
                print("setcolor");
            }
        }
    }
}
