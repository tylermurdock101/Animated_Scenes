using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    // A flag to make sure we only try to load the scene once
    private bool hasBeenTriggered = false;
    public float triggerZPosition = 10f;

    // You can set the direction in the Unity Inspector
    public Vector3 moveDirection = Vector3.forward;

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
        Debug.Log(transform.position);

        if (!hasBeenTriggered && transform.position.z > triggerZPosition)
        {
            // Set the flag to true so this only runs once
            hasBeenTriggered = true;

            // Load the new scene
            SceneManager.LoadScene("Scene 2");
        }
    }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {

    }
}
