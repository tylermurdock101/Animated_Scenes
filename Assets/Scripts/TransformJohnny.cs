using UnityEngine;
using UnityEngine.SceneManagement;

public class TransformJohnny : MonoBehaviour
{
    public float speed = 5f;
    private bool hasBeenTriggered = false;
    public float triggerZPosition = -35f;

    // You can set the direction in the Unity Inspector
    public Vector3 moveDirection = Vector3.back;

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement step
        // We use .normalized to ensure consistent speed regardless of the direction vector's magnitude
        // We multiply by Time.deltaTime to make the movement frame-rate independent
        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;

        // Apply the movement to the object's current position
        // This moves the object in world space
        transform.position += movement;

        if (!hasBeenTriggered && transform.position.z < triggerZPosition)
        {
            // Set the flag to true so this only runs once
            hasBeenTriggered = true;

            // Load the new scene
            SceneManager.LoadScene("Scene 3");
        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
}
