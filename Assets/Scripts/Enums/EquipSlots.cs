using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum EquipSlots
{
    None = 0,
    Primary = 1 << 0,
    Secondary = 1 << 1,
    Head = 1 << 2,
    Body = 1 << 3,
    Accessary = 1 << 4
}
