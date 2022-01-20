using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemboxSpriteScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];
    public Sprite currentSprite;

    private void Start()
    {
        currentSprite = sprites[0];

        gameObject.GetComponent<Image>().sprite = currentSprite;
    }

    public void SetSprite(int spriteNumber)
    {
        currentSprite = sprites[spriteNumber];
        gameObject.GetComponent<Image>().sprite = currentSprite;
    }
}
