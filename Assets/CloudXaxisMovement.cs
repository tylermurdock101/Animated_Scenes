using UnityEngine;

public class CloudXaxisMovement : MonoBehaviour
{
   public float speed = 4f;
    public Vector3 direction = Vector3.left; 
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
