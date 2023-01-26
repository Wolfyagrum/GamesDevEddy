using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject HumanPlayer;
    [SerializeField] private GameObject ElfPlayer;
    [SerializeField] private GameObject DwarfPlayer;

    [SerializeField] private TextMeshProUGUI ScreamText;

    private GameObject current;

    private int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        current = Instantiate(HumanPlayer, new Vector3(0,2,0), Quaternion.identity);
    }

    public void SwitchChar()
    {
        Vector3 location = current.transform.position;
        Destroy(current);
        if (index == 0)
        {
            index = 1;
            current = Instantiate(HumanPlayer,new Vector3(location.x,location.y,location.z), Quaternion.identity);
        }

        else if(index == 1)
        {
            index = 2;
            current = Instantiate(ElfPlayer, new Vector3(location.x, location.y, location.z), Quaternion.identity);
            ElfPlayer elf = current.GetComponent<ElfPlayer>();
            elf.ScreamText = ScreamText;
            ScreamText.enabled = true;
            elf.SetScreamText();
        }

        else if(index == 2)
        {
            index = 0;
            current = Instantiate(DwarfPlayer, new Vector3(location.x, location.y, location.z), Quaternion.identity);
        }
    }

    public void EquipmentChange(Equipment equipment)
    {

        ElfPlayer elf = current.GetComponent<ElfPlayer>();
        DwarfPlayer dwarf = current.GetComponent<DwarfPlayer>();
        HumanPlayer human = current.GetComponent<HumanPlayer>();
        if(elf != null)
        {
            elf.SetEquipment(equipment);
        }
        else if(dwarf != null)
        {
            dwarf.SetEquipment(equipment);
        }
        else if(human != null)
        {
            human.SetEquipment(equipment);
        }
    }
}
