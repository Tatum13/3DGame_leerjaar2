using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Item : MonoBehaviour
{
    public string itemName;

    public Sprite itemSprite;
    public GameObject itemModel;
    
    public virtual void UseItem()
    {

    }
}
