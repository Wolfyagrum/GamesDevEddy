using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public List<Equipment> equipmentList = new List<Equipment>();


    public Equipment GetRandomEquipment()
    {
        if(equipmentList.Count == 0)
        {
            print(equipmentList.Count);
            return null;
        }
        int random = Random.Range(0, equipmentList.Count);
        return equipmentList[random];
    }
}
