using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPointScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckPoint")
        {
            Debug.Log("Checkpoint reached");
            if(other.gameObject.tag == "FinishLine")
            {
                Debug.Log("Test");
            }
        }
    }
}
