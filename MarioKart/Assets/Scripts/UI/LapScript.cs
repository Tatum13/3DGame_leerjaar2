using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapScript : MonoBehaviour
{
    public TMP_Text lapText;
    public int lapGetal = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("YOU PASSED THE FINISHLINE!");
        }
    }
}
