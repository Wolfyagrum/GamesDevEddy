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
    public TextMeshProUGUI ScreamText;

    private void OnEnable()
    {
        SetEquipment(Equipment);
        audioSource = GetComponent<AudioSource>();
        Screams = PlayerPrefs.GetInt("Screams");
    }

    private void OnDisable()
    {
        ScreamText.enabled = false;
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

    public void SetScreamText()
    {
        ScreamText.text = "Screams: " + Screams;
    }
}
