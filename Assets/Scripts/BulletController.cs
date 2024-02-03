using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private float damage;

    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;

    private Rigidbody2D rb;
    private DissolveEnemy dissolveEnemy;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ReturnToPoolAfterDelay());
    }

    private IEnumerator ReturnToPoolAfterDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy hit");
            //Destroy(gameObject);
          
            this.gameObject.SetActive(false);
        }
    }
}
