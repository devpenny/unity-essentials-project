
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // This variable allows you to set the duration of a full day in seconds from the Inspector
    public float dayDurationInSeconds = 60.0f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation speed based on the day duration
        float rotationSpeed = 360.0f / dayDurationInSeconds;

        // Rotate the light around the X-axis to simulate the day-night cycle
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}