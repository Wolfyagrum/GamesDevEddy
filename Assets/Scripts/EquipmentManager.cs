using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public List<Equipment> equipmentList = new List<Equipment>();


    public Equipment GetRandomEquipment()
    {
        int random = Random.Range(0, equipmentList.Count);
        return equipmentList[random];
    }
}
