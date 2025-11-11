using UnityEngine;

public class Sunset : MonoBehaviour
{
    public float sunsetDuration = 10f; 
    public bool startSunsetOnPlay = true;
    
    public Color startColor = Color.white;
    public Color endColor = new Color(1f, 0.4f, 0.2f); 
    
    public float startIntensity = 1f;
    public float endIntensity = 0.3f;
    
    private Light sunLight;
    private float sunsetTimer = 0f;
    private bool isSunsetting = false;
    private Quaternion startRotation;
    private Quaternion endRotation;

    void Start()
    {
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
            sunsetTimer += Time.deltaTime;
            
            float progress = sunsetTimer / sunsetDuration;
            
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
            
            // Update light color and intensity
            sunLight.color = Color.Lerp(startColor, endColor, progress);
            sunLight.intensity = Mathf.Lerp(startIntensity, endIntensity, progress);
            
            sunLight.shadowStrength = Mathf.Lerp(1f, 0.5f, progress);
        }
    }
    
    public void StartSunset()
    {
        if (sunLight != null)
        {
            isSunsetting = true;
            sunsetTimer = 0f;
        }
    }
    
    public void ResetSunset()
    {
        isSunsetting = false;
        sunsetTimer = 0f;
        transform.rotation = startRotation;
        sunLight.color = startColor;
        sunLight.intensity = startIntensity;
        sunLight.shadowStrength = 1f;
    }
    
    public void SetToFullSunset()
    {
        transform.rotation = endRotation;
        sunLight.color = endColor;
        sunLight.intensity = endIntensity;
        sunLight.shadowStrength = 0.5f;
        isSunsetting = false;
    }
}
