using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public string levelName;
    public Dropdown levelsDropdown;
    public void Update()
    {
        switch(levelsDropdown.value)
        {
            case 0: levelName = "Gilad1";
            break;
            case 1: levelName = "Tal2";
            break;
            case 2: levelName = "Yoel1";
            break;
        }
    }
}
