using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/Region")]
public class SO_Region : ScriptableObject
{
    public string RegionName; //---------------- for Firestore maybe?
    public RegionID RegionID;
    public SO_BiomePalette RegionBiome;
    public int RequiredSteps;
}
