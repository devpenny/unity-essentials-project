using UnityEngine;

public class WoodBlockSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other) {
        if (!(other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Player")) || other.relativeVelocity.magnitude == 0) return;
        audioSource.Stop();
        audioSource.volume = Mathf.Clamp(other.relativeVelocity.magnitude / 10f, 0f, 1f);
        Debug.Log("Block Velocity Magnitude: " + other.relativeVelocity.magnitude + " Block Calculated Volume: " + audioSource.volume);
        audioSource.Play();
    }
}
