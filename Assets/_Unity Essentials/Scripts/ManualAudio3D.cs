using UnityEngine;

public class ManualAudio3D : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1f; // 1 = Fully 3D
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
