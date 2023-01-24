using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private HumanPlayer HumanPlayer;
    [SerializeField] private ElfPlayer ElfPlayer;
    [SerializeField] private DwarfPlayer DwarfPlayer;

    private int index = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SwitchChar()
    {
        HumanPlayer.enabled = false;
        ElfPlayer.enabled = false;
        DwarfPlayer.enabled = false;

        if(index == 0)
        {
            index = 1;
            HumanPlayer.enabled = true;
        }

        else if(index == 1)
        {
            index = 2;
            ElfPlayer.enabled = true;
        }

        else if(index == 2)
        {
            index = 0;
            DwarfPlayer.enabled = true;
        }
    }

    public void EquipmentChange(Equipment equipment)
    {
        if (index == 0)
        {
            DwarfPlayer.SetEquipment(equipment);
        }

        else if (index == 1)
        {
            HumanPlayer.SetEquipment(equipment);
        }

        else if (index == 2)
        {
            ElfPlayer.SetEquipment(equipment);
        }
    }
}
