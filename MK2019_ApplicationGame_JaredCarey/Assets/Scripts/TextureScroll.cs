using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    [Range(0, 1)]
    public float scrollXSpeed = 0.5f;
    [Range(0, 1)]
    public float scrollYSpeed = 0.5f;
    public Renderer renderer;

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * scrollXSpeed;
        float offsetY = Time.time * scrollYSpeed;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
