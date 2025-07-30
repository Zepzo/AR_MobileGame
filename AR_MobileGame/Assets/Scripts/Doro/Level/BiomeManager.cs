using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BiomeManager : MonoBehaviour
{
    public SO_BiomePalette CurrentBiome;
    public ParallaxManager ParallaxManager;
    
    void Start()
    {
        ApplyBiome(CurrentBiome);
    }

    public void ApplyBiome(SO_BiomePalette biome)
    {
        CurrentBiome = biome;

        ParallaxManager.Layers[0].SetSprite(biome.SkySprite);
        ParallaxManager.Layers[1].SetSprite(biome.CloudSprite);
        ParallaxManager.Layers[2].SetSprite(biome.MountainSprite);
        ParallaxManager.Layers[3].SetSprite(biome.VegetationSpriteA);
        ParallaxManager.Layers[4].SetSprite(biome.VegetationSpriteB);
        
        //ParallaxManager.Layers[5].SetSprite(biome.GroundSprite);

        //---------- whatever else is in the biome scriptable object
    }
}
