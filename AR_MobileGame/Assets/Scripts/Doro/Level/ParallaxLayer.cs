using UnityEngine;
using UnityEngine.Serialization;

public class ParallaxLayer : MonoBehaviour
{
    public float ParallaxFactor;
    public SpriteRenderer[] Tiles;
    public Camera MainCamera;

    void Start()
    {
        if (MainCamera == null)
            MainCamera = Camera.main;
    }

    public void SetSprite(Sprite sprite)
    {
        foreach (var tile in Tiles)
            tile.sprite = sprite;
    }

    public void Scroll(float speed)
    {
        transform.position += Vector3.left * ParallaxFactor * speed * Time.deltaTime;
        
        foreach (var tile in Tiles)
        {
            if (IsOutOfView(tile))
                RepositionTile(tile);
        }
    }

    bool IsOutOfView(SpriteRenderer tile)
    {
        float tileRight = tile.bounds.max.x;
        float cameraLeft = MainCamera.ViewportToWorldPoint(Vector3.zero).x;

        return tileRight < cameraLeft;
    }

    void RepositionTile(SpriteRenderer tile)
    {
        float maxRight = float.MinValue;

        foreach (var t in Tiles)
        {
            if (t.transform.position.x > maxRight)
            {
                maxRight = t.transform.position.x;
            }
        }

        float tileWidth = tile.bounds.size.x;
        tile.transform.position = new Vector3(maxRight + tileWidth, tile.transform.position.y, tile.transform.position.z);
    }
}
