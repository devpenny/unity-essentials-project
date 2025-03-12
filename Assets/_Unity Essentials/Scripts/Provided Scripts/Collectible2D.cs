using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible2D : MonoBehaviour
{

    public float rotationSpeed = 0.5f;
    public GameObject onCollectEffect;
    public AudioClip onCollectSound;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
         // Check if the other object has a PlayerController2D component
        if (other.GetComponent<PlayerController2D>() != null) {  
            PlayClip();
            // Destroy the collectible
            Destroy(gameObject);
            // Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }

    private void PlayClip() {
        GameObject audioObject = new GameObject("Temporary Audio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = onCollectSound;
        audioSource.Play();
        Debug.Log("Playing audio: " + onCollectSound.name);
        Destroy(audioObject, onCollectSound.length);
        Debug.Log("Scheduled destruction for: " + onCollectSound.name);
    }
}


