using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnitRecipe : ScriptableObject
{
    public string model;
    public string job;
    public string attack;
    public string abilityCatalog;
    public string strategy;
    public Locomotions locomotion;
    public Alliances alliance;
}
