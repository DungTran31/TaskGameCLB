using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    private float _speed = 5f;
    private Vector2 _diretion;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        
        Vector2 mousePosi = _player.GetComponent<PlayerController>().GetMousePosition();
        
        Debug.Log(mousePosi);
        
        // _diretion = mousePosi - (Vector2)Camera.main.ScreenToWorldPoint(_player.transform.position);
        _diretion = mousePosi - (Vector2)_player.transform.position;
        
        _diretion.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_diretion * Time.deltaTime*_speed);
    }
}
