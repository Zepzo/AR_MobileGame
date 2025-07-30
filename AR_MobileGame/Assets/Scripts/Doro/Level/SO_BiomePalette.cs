using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Parallax/Biome Palette")]
public class SO_BiomePalette : ScriptableObject
{
    public Sprite SkySprite;
    public Sprite CloudSprite;
    public Sprite MountainSprite;
    public Sprite VegetationSpriteA;
    public Sprite VegetationSpriteB;
    
    public Sprite GroundSprite;
    
    //--------------- could potentially store colors, particles and sprites for props
}
