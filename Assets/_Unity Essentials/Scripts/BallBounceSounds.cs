using System;
using UnityEngine;

public class BallBounceSounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision other) {
        if (other.relativeVelocity.magnitude > 0.1f) {
            audioSource.Stop();
            float newVolume = Mathf.Clamp(other.relativeVelocity.magnitude / 7.0f, 0f, 1f);
            audioSource.volume = newVolume;
            Debug.Log("Ball Velocity Magnitude: " + other.relativeVelocity.magnitude + " Ball Calculated Volume: " + audioSource.volume);
            audioSource.Play();
        }
    }
}
