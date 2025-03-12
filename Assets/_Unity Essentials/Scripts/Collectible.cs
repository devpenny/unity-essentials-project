using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float amplitude = 0.5f; // Range of movement (how high/low it moves)
    public float speed = 1f; // Speed of movement
    public float rotationSpeed = 0.5f;
    public GameObject onCollectEffect;
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Instantiate(onCollectEffect, transform.position, transform.rotation);
            GetComponent<AudioSource>().Play();
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        }
    }
}
