using UnityEngine;

public class Cloud2XaxisMovement : MonoBehaviour
{
   public float speed = 4f;
    public Vector3 direction = Vector3.right; 
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
