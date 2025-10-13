using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public AudioClip collectSound; // Le son à jouer
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collectSound);
            // ajouter points, sons, etc.

            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(gameObject);



        }
    }
}
