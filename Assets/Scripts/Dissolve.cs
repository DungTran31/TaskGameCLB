using System;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;

    bool isDissolving = false;
    float fade = 1f;

    void Start()
    {
        // Get a reference to the material
        material = GetComponent<SpriteRenderer>().material;

    }

    void Update()
    {

        if (isDissolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
                Destroy(gameObject);
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
            isDissolving = true;
        }
    }
}