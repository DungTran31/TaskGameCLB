using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{

    private float _horizontalInput, _verticalInput;
    private float _speed = 8f;
    private Vector2 _mousePosi;

    [SerializeField] private Transform _firingPoint; // Thêm một trường Transform để tham chiếu đến firing point


    [SerializeField] private GameObject _bulletPrefab;
    private ObjectPooler _objectPooler; // Thêm một reference tới ObjectPooler
    private Camera _mainCamera; // Thêm một reference tới Camera

    [SerializeField] private float _orbitRadius = 2f;
    private void Start()
    {
        _objectPooler = ObjectPooler.Instance; // Lấy reference của ObjectPooler từ singleton
        _mainCamera = Camera.main; // Lấy reference của main Camera
    }
    // Update is called once per frame
    //Screen Space, World Space

    private void Update()
    {
        // Lấy hướng từ player đến chuột
        _mousePosi = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = _mousePosi - (Vector2)transform.position;
        direction.Normalize();

        // Tính góc giữa player và chuột
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Xoay FiringPoint theo góc tính được
        _firingPoint.rotation = Quaternion.Euler(0, 0, angle);

        // Đặt vị trí của FiringPoint trên đường tròn quanh player
        Vector2 orbitPosition = (Vector2)transform.position + (direction.normalized * _orbitRadius);
        _firingPoint.position = orbitPosition;
        // Kiểm tra khi nhấn chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            // Lấy đạn từ pool
            GameObject bullet = _objectPooler.SpawnFromPool("Bullet", _firingPoint.position, _firingPoint.rotation);
        }
    }

    public Vector2 GetMousePosition()
    {
        return _mousePosi;
    }

    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal"); 
        _verticalInput = Input.GetAxis("Vertical");
        
        Vector2 direction = new Vector2(_horizontalInput, _verticalInput);
        direction.Normalize();
        
        transform.Translate(direction * Time.deltaTime * _speed);
    }
}
