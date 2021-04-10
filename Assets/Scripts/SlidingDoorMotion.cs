using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorMotion : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("doorOpen", true);
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("doorOpen", false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
