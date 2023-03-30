using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongBounce : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    [SerializeField] private AudioClip bounceSound;
    private float volumeSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //code to get the velocity magnitude and convert to volume sound
        volumeSound = rb.velocity.magnitude; //maginitude converts velocity (Vector3) to a float. Refer to Unity API for more info
        //Debug.Log(volumeSound); 

        audioSource.PlayOneShot(bounceSound, volumeSound);

    }
}
