using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    private void OnEnable()
    {
        controller.OnAction.AddListener(Action);
        filter.mesh = Mesh;
        SetEquipment(Equipment);
    }

    private void OnDisable()
    {
        controller.OnAction.RemoveListener(Action);
    }

    public override void Action()
    {
        this.transform.position += new Vector3(0, 0, 10);
    }
}
