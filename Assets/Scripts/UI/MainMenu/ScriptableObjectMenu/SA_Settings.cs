using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "settings", menuName = "Settings", order = 0)]
public class SA_Settings : ScriptableObject
{
    [Range(0, 100)]
    public int Volume;
}
