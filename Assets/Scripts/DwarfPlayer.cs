using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfPlayer : Player
{
    private void OnEnable()
    {
        controller.OnAction.AddListener(Action);
        SetEquipment(Equipment);
    }

    private void OnDisable()
    {
        controller.OnAction.RemoveListener(Action);
    }

    public override void Action()
    {
        Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hitInfo, interactDistance);
        if (hitInfo.transform != null)
        {
            Crates hit = hitInfo.transform.gameObject.GetComponent<Crates>();
            if (hit != null)
            {
                hit.DestoryCrate();
            }
        }
    }
}
