using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEnemy : MonoBehaviour
{
    Material material;

    [SerializeField] private float _fadeRate = 5f;
    public bool isDissolving = false;
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
            fade -= (Time.deltaTime * _fadeRate);

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
                gameObject.SetActive(false);
            }

            // Set the property
            material.SetFloat("_Fade", fade);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isDissolving = true;
        }
    }
}
