using UnityEngine;

public class TransformGyroFinal : MonoBehaviour
{
    public float speed = 5f;
    private bool hasBeenTriggered = false;
    public float triggerZPosition = 20f;
    private Animator anim;
    

    public Vector3 moveDirection = Vector3.forward;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement step
        // We use .normalized to ensure consistent speed regardless of the direction vector's magnitude
        // We multiply by Time.deltaTime to make the movement frame-rate independent
        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;

        // Apply the movement to the object's current position
        // This moves the object in world space

        if (!(transform.position.z >= triggerZPosition))
        {
            transform.position += movement;
        }
        else if (!hasBeenTriggered)
        {
            {
                hasBeenTriggered = true;
                anim.SetTrigger("StopPoint");
            }
        }
    }
}
