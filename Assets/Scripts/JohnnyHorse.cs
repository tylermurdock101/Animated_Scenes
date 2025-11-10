using UnityEngine;

public class JohnnyHorse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator anim;

    // Update is called once per frame

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(transform.position.z >= 12))
        {
            anim.SetTrigger("StopPoint");
        }
    }
}

