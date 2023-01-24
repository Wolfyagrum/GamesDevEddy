using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Equipment", order = 1)]
public class Equipment : ScriptableObject
{
    public float SpeedMod;
    public float JumpMod;
    public Color color;
}
