using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public GameObject parent;
    private List<GameObject> checkPointChecker = new List<GameObject>();
    private int cp;

    private void Start()
    {
        //checkPointChecker.Add(this.gameObject.transform.childCount);
        foreach(Transform child in parent.transform)
        {
            if(child.tag == "CheckPoint")
            {
                checkPointChecker.Add(child.gameObject);
            }
        }
        //Debug.Log(checkPointChecker.Count - 1 + " Found you");
    }

    /*
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
    */
}
