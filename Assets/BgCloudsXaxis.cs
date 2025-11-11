using UnityEngine;

public class BgCloudsXaxis : MonoBehaviour
{
     public float speed = 5f;
    public Vector3 direction = Vector3.right; 
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}