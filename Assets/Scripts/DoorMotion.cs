using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator anim;
    private AudioSource doorOpenSound, doorCloseSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorOpenSound = GetComponent<AudioSource>();
        doorCloseSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("openDoor", true);
        doorOpenSound.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("openDoor", false);
        // doorCloseSound.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
