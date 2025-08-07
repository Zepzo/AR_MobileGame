using UnityEngine;

public class BiomeVisualManager : MonoBehaviour
{
    public ParallaxManager ParallaxManager;
    
    public SO_BiomePalette CurrentBiome;
    private int _currentBiomeIndex = 0;
    
    public float TransitionTime = 1f;
    
    void Start()
    {
        ApplyBiomeSpritesBG(CurrentBiome);
        ApplyBiomeColorsBG(CurrentBiome);
    }
    
    public void ApplyBiomeSpritesBG(SO_BiomePalette biome)
    {
        CurrentBiome = biome;

        ParallaxManager.Layers[0].SetSprite(biome.SkySprite);
        ParallaxManager.Layers[1].SetSprite(biome.CloudSprite);
        ParallaxManager.Layers[2].SetSprite(biome.MountainSprite);
        ParallaxManager.Layers[3].SetSprite(biome.VegetationSpriteA);
        ParallaxManager.Layers[4].SetSprite(biome.VegetationSpriteB);
        
        ParallaxManager.Layers[5].SetSprite(biome.GroundSprite);
        
        ParallaxManager.Layers[6].SetSprite(biome.FrontSpriteA);
        ParallaxManager.Layers[7].SetSprite(biome.FrontSpriteB);
        ParallaxManager.Layers[8].SetSprite(biome.FrontSpriteC);
        ParallaxManager.Layers[9].SetSprite(biome.FrontSpriteD);
        ParallaxManager.Layers[10].SetSprite(biome.FrontSpriteE);
    }
    
    public void ApplyBiomeColorsBG(SO_BiomePalette biome)
    {
        CurrentBiome = biome;

        ParallaxManager.Layers[0].SetColor(biome.SkyColor);
        ParallaxManager.Layers[1].SetColor(biome.CloudColor);
        ParallaxManager.Layers[2].SetColor(biome.MountainColor);
        ParallaxManager.Layers[3].SetColor(biome.VegetationAColor);
        ParallaxManager.Layers[4].SetColor(biome.VegetationBColor);
        
        ParallaxManager.Layers[5].SetColor(biome.GroundColor);
        
        ParallaxManager.Layers[6].SetColor(biome.FrontColorA);
        ParallaxManager.Layers[7].SetColor(biome.FrontColorB);
        ParallaxManager.Layers[8].SetColor(biome.FrontColorC);
        ParallaxManager.Layers[9].SetColor(biome.FrontColorD);
        ParallaxManager.Layers[5].SetColor(biome.FrontColorE);
    }
    
    public void TransitionBiomeColorsBG(SO_BiomePalette biome, float transitionTime)
    {
        CurrentBiome = biome;
        TransitionTime = transitionTime;

        ParallaxManager.Layers[0].SetTargetColor(biome.SkyColor, transitionTime);
        ParallaxManager.Layers[1].SetTargetColor(biome.CloudColor, transitionTime);
        ParallaxManager.Layers[2].SetTargetColor(biome.MountainColor, transitionTime);
        ParallaxManager.Layers[3].SetTargetColor(biome.VegetationAColor, transitionTime);
        ParallaxManager.Layers[4].SetTargetColor(biome.VegetationBColor, transitionTime);
        
        ParallaxManager.Layers[5].SetColor(biome.GroundColor);
        
        ParallaxManager.Layers[6].SetColor(biome.FrontColorA);
        ParallaxManager.Layers[7].SetColor(biome.FrontColorB);
        ParallaxManager.Layers[8].SetColor(biome.FrontColorC);
        ParallaxManager.Layers[9].SetColor(biome.FrontColorD);
        ParallaxManager.Layers[5].SetColor(biome.FrontColorE);
    }
}
//other methods that spawn the vegetation props