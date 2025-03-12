// 11/03/2025 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;                // Reference to the player object
    private new Camera camera;
    public float speedFOVMultiplier = 20;            // Field of view during high speeds
    public float fovChangeSpeed = 2f;
    private float playerSpeed;
    private float normalFOV;           // Normal field of view
    private float speedFOV;


    private void Start() {
        camera = GetComponent<Camera>();
        normalFOV = camera.fieldOfView;
    }
    void LateUpdate()
    {
        speedFOV = normalFOV * (1 + speedFOVMultiplier / 100);
        playerSpeed = player.GetComponent<Rigidbody>().linearVelocity.magnitude;
        float targetFOV = playerSpeed > 0.2f ? speedFOV : normalFOV;
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, targetFOV, fovChangeSpeed * Time.deltaTime);
    }
}