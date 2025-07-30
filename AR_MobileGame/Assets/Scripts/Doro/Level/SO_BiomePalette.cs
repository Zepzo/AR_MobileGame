using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Parallax/Biome Palette")]
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
    public Color SkyColor;
    
    //--------------- could potentially store colors, particles and sprites for props
}
