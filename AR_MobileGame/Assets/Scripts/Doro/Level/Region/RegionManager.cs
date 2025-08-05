using UnityEngine;
using UnityEngine.Serialization;

public class RegionManager : MonoBehaviour
{
    public SO_Region[] RegionList;
    public SO_Region CurrentRegion;

    public BiomeVisualManager BiomeVisuals;
    public GameObject MapUI;
    
    public void SelectRegion(SO_Region selectedRegion)
    {
        if (CurrentRegion != null && selectedRegion.RegionID == CurrentRegion.RegionID)
        {
            Debug.Log("Already in this region. Cannot travel again.");
            return;
        }
        
        CurrentRegion = selectedRegion;
        MapUI.SetActive(false);
        TravelToRegion(selectedRegion);
    }
    
    public void TravelToRegion(SO_Region selectedRegion)
    {
        Debug.Log($"Traveling to {selectedRegion.RegionID}");
        BiomeVisuals.ApplyBiomeSpritesBG(selectedRegion.RegionBiome);
        BiomeVisuals.TransitionBiomeColorsBG(selectedRegion.RegionBiome, BiomeVisuals.TransitionTime);
    }
}
