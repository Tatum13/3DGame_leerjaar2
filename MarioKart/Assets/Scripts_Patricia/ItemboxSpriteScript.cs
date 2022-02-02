using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemboxSpriteScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];
    public Image currentSprite;

    public Animator animator;

    private void Start()
    {
        currentSprite = gameObject.GetComponent<Image>();
        currentSprite.sprite = sprites[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && currentSprite.sprite == sprites[0])
        {
            SetSprite(1);
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl) && currentSprite.sprite == sprites[1])
        {
            SetSprite(2);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && currentSprite.sprite == sprites[2])
        {
            animator.SetBool("isThere", false);
        }
    }

    public void SetSprite(int spriteNumber)
    {
        currentSprite.sprite = sprites[spriteNumber];
    }
}
