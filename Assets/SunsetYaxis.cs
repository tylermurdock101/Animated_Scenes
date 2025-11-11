using UnityEngine;

public class SunsetYaxis : MonoBehaviour
{
    public float duration = 11f;
    public float startY = 115f;
    public float endY = -185f;
    
    private Vector3 startPos;
    private Vector3 endPos;
    private float timer = 0f;

    void Start()
    {
        startPos = new Vector3(transform.position.x, startY, transform.position.z);
        endPos = new Vector3(transform.position.x, endY, transform.position.z);
        
        // Move to start position
        transform.position = startPos;
    }

    void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;
            transform.position = Vector3.Lerp(startPos, endPos, progress);
        }
    }
}