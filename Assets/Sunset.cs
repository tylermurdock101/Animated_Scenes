using UnityEngine;

public class Sunset : MonoBehaviour
{
    public float sunsetDuration = 10f; // Exactly 10 seconds
    public bool startSunsetOnPlay = true;
    
    public Color startColor = Color.white;
    public Color endColor = new Color(1f, 0.4f, 0.2f); // Deep orange
    
    public float startIntensity = 1f;
    public float endIntensity = 0.3f;
    
    private Light sunLight;
    private float sunsetTimer = 0f;
    private bool isSunsetting = false;
    private Quaternion startRotation;
    private Quaternion endRotation;

    void Start()
    {
        // Get the directional light component
        sunLight = GetComponent<Light>();
        
        if (sunLight == null)
        {
            Debug.LogError("No Light component found on this GameObject!");
            return;
        }
        
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(-10f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        
        sunLight.color = startColor;
        sunLight.intensity = startIntensity;
        
        if (startSunsetOnPlay)
        {
            StartSunset();
        }
    }

    void Update()
    {
        if (isSunsetting && sunsetTimer < sunsetDuration)
        {
            // Update timer
            sunsetTimer += Time.deltaTime;
            
            // Calculate progress (0 to 1)
            float progress = sunsetTimer / sunsetDuration;
            
            // Update sun rotation (moving downward)
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
            
            // Update light color and intensity
            sunLight.color = Color.Lerp(startColor, endColor, progress);
            sunLight.intensity = Mathf.Lerp(startIntensity, endIntensity, progress);
            
            // Optional: Make shadows softer during sunset
            sunLight.shadowStrength = Mathf.Lerp(1f, 0.5f, progress);
        }
    }
    
    // Public method to start the sunset
    public void StartSunset()
    {
        if (sunLight != null)
        {
            isSunsetting = true;
            sunsetTimer = 0f;
        }
    }
    
    // Public method to reset the sunset
    public void ResetSunset()
    {
        isSunsetting = false;
        sunsetTimer = 0f;
        transform.rotation = startRotation;
        sunLight.color = startColor;
        sunLight.intensity = startIntensity;
        sunLight.shadowStrength = 1f;
    }
    
    // Public method to instantly set to full sunset
    public void SetToFullSunset()
    {
        transform.rotation = endRotation;
        sunLight.color = endColor;
        sunLight.intensity = endIntensity;
        sunLight.shadowStrength = 0.5f;
        isSunsetting = false;
    }
}
