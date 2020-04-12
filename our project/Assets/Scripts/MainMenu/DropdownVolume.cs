using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownVolume : MonoBehaviour
{
    public Dropdown volumeDropdown;
    public int volume;
    public void Update()
    {
        switch(volumeDropdown.value)
        {
            case 0: volume = 0;
            break;
            case 1: volume = 1;
            break;
        }
    }
}
