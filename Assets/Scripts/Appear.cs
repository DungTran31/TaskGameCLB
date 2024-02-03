using UnityEngine;

public class Appear : MonoBehaviour
{
    Material material;

    bool isAppearing = true; // Start with dissolve effect active
    float fade = 0f;

    void Start()
    {
        // Get a reference to the material
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (isAppearing)
        {
            fade += Time.deltaTime;

            if (fade >= 1f)
            {
                fade = 1f;
                isAppearing = false;
            }

            // Set the property
            material.SetFloat("_Fade", fade);
        }
    }

    // Called when a 2D collider enters another collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Trigger dissolve effect
            isAppearing = true;
        }
    }
}
