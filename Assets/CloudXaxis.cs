using UnityEngine;

public class CloudXaxis : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = Vector3.left; 
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}

