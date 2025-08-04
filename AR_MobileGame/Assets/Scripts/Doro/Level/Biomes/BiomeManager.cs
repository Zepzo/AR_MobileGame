using System;
using UnityEngine;

public class BiomeManager : MonoBehaviour
{
    public SO_BiomePalette[] BiomeList;
    public int CurrentBiomeIndex;
    public BiomeVisualManager BiomeVisuals;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchBiome();
            Debug.Log("Biome has been switched");
        }
    }

    public void SwitchBiome()
    {
        CurrentBiomeIndex = (CurrentBiomeIndex + 1) % BiomeList.Length;
        SO_BiomePalette nextBiome = BiomeList[CurrentBiomeIndex];
        BiomeVisuals.ApplyBiomeSpritesBG(nextBiome);
        BiomeVisuals.TransitionBiomeColorsBG(nextBiome, BiomeVisuals.TransitionTime);
    }
}
