using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerManager Player = other.GetComponent<PlayerManager>();
        if(Player != null)
        {
            Player.transform.position = new Vector3(0, 2, 0);
        }
    }
}
