using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemScript : MonoBehaviour
{
    public GameObject itemboxUI;
    public Animator animator;

    public float timer;
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = itemboxUI.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Itembox")
        {
            Destroy(other.gameObject);
            animator.SetBool("isThere", true);
        }
    }
}
