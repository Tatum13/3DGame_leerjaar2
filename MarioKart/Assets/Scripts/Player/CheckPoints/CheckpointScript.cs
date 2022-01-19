using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public bool activated = false;
    public static GameObject[] CheckpointList;

    void Start()
    {
        CheckpointList = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    private void ActivateCheckpoint()
    {
        foreach(GameObject cp in CheckpointList)
        {
            //cp.GetComponent(iets).activated = false;
            //cp.GetComponent(iets).SetBool("Active", false);
            //cp.gameObject.GetComponent<>.activated = false;
        }
        activated = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ActivateCheckpoint();
        }
    }
    /*
    public static Vector3 GetActiveCheckpointPosition()
    {
        Vector3 result = new Vector3(0, 0, 0);
        if(CheckpointList != null)
        {
            foreach(GameObject cp in CheckpointList)
            {
                if (cp.GetComponent().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }
        return result;
    }
    */
}
