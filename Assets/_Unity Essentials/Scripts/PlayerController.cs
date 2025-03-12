using Unity.VisualScripting;
using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.
    public float flyForce = 0.12f;
    public float maxAltitude = 10f;

    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && rb.transform.position.y < maxAltitude) {
            float diff = maxAltitude - rb.transform.position.y;
            Vector3 newVelocity = new Vector3(rb.linearVelocity.x, diff/maxAltitude*flyForce, rb.linearVelocity.z);
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, newVelocity, 0.5f);
        }
    }

    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed;

        // Smoothly adjust velocity to avoid sticking
        Vector3 newVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, newVelocity, 0.5f); // Lerp to smoothly transition velocities

        // Rotate player based on horizontal input
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
