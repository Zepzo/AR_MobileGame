using System.Collections;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float ParallaxFactor;
    public SpriteRenderer[] Tiles;
    public Camera MainCamera;
    public bool MoveRight = false;

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

    public void SetColor(Color color)
    {
        foreach (var tile in Tiles)
            tile.color = color;
    }

    public Color GetColor()
    {
        return Tiles.Length > 0 ? Tiles[0].color : Color.white;
    }

    //------------------------------------------------------------------- tile movement
    public void Scroll(float speed)
    {
        Vector3 direction = MoveRight ? Vector3.right : Vector3.left;
        transform.position += direction * ParallaxFactor * speed * Time.deltaTime;

        foreach (var tile in Tiles)
        {
            if (IsOutOfView(tile))
                RepositionTile(tile);
        }
    }

    bool IsOutOfView(SpriteRenderer tile)
    {
        if (MoveRight)
        {
            float tileLeft = tile.bounds.min.x;
            float cameraRight = MainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            return tileLeft > cameraRight;
        }
        else
        {
            float tileRight = tile.bounds.max.x;
            float cameraLeft = MainCamera.ViewportToWorldPoint(Vector3.zero).x;
            return tileRight < cameraLeft;
        }
    }

    void RepositionTile(SpriteRenderer tile)
    {
        float tileWidth = tile.bounds.size.x;

        if (MoveRight)
        {
            float minLeft = float.MaxValue;
            foreach (var t in Tiles)
            {
                if (t.transform.position.x < minLeft)
                {
                    minLeft = t.transform.position.x;
                }
            } 
            tile.transform.position = new Vector3(minLeft - tileWidth, tile.transform.position.y, tile.transform.position.z);
        }
        else
        {
            float maxRight = float.MinValue;
            foreach (var t in Tiles)
            {
                if (t.transform.position.x > maxRight)
                {
                    maxRight = t.transform.position.x;
                }
            }
            
            tile.transform.position = new Vector3(maxRight + tileWidth, tile.transform.position.y, tile.transform.position.z);
        }
    }
    
    //------------------------------------------------------------------- tile Colors
    private Coroutine colorLerpCoroutine;

    public void SetTargetColor(Color newColor, float duration)
    {
        if (colorLerpCoroutine != null)
            StopCoroutine(colorLerpCoroutine);

        colorLerpCoroutine = StartCoroutine(LerpColorCoroutine(newColor, duration));
    }

    private IEnumerator LerpColorCoroutine(Color targetColor, float duration)
    {
        Color[] startColors = new Color[Tiles.Length];
        for (int i = 0; i < Tiles.Length; i++)
            startColors[i] = Tiles[i].color;

        float time = 0f;
        while (time < duration)
        {
            for (int i = 0; i < Tiles.Length; i++)
            {
                Tiles[i].color = Color.Lerp(startColors[i], targetColor, time / duration);
            }

            time += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < Tiles.Length; i++)
            Tiles[i].color = targetColor;
    }
}