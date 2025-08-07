using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Level/Biome Palette")]
public class SO_BiomePalette : ScriptableObject
{
    public Sprite SkySprite;
    public Color SkyColor;
    
    public Sprite CloudSprite;
    public Color CloudColor;
    
    public Sprite MountainSprite;
    public Color MountainColor;
    
    public Sprite VegetationSpriteA;
    public Color VegetationAColor;
    
    public Sprite VegetationSpriteB;
    public Color VegetationBColor;
    
    public Sprite GroundSprite;
    public Color GroundColor;
    
    
    //-------------------------------------------------------------- Foreground
    public Sprite FrontSpriteA;
    public Color FrontColorA;
    
    public Sprite FrontSpriteB;
    public Color FrontColorB;
    
    public Sprite FrontSpriteC;
    public Color FrontColorC;
    
    public Sprite FrontSpriteD;
    public Color FrontColorD;
    
    public Sprite FrontSpriteE;
    public Color FrontColorE;

}
