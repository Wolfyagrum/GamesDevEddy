using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ElfPlayer : Player
{
    AudioSource audioSource;
    private int Screams;
    [SerializeField] TextMeshProUGUI ScreamText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Screams = PlayerPrefs.GetInt("Screams");
        SetScreamText();
    }

    private void OnEnable()
    {
        controller = FindObjectOfType<InputManager>();
        controller.OnJump.AddListener(Jump);
        controller.OnAction.AddListener(Action);
        ScreamText.enabled = true;
        filter.mesh = Mesh;
        SetEquipment(Equipment);
    }

    private void OnDisable()
    {
        controller.OnJump.RemoveListener(Jump);
        controller.OnAction.RemoveListener(Action);
        ScreamText.enabled = false;
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
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioSource.Play();
        Screams++;
        PlayerPrefs.SetInt("Screams", Screams);
        SetScreamText();
    }

    private void SetScreamText()
    {
        ScreamText.text = "Screams: " + Screams;
    }
}
