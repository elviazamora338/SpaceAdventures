using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class FallingSpike : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _Landed;
    private Vector2 _StartPosition;
    public float speed;

    [SerializeField] private Transform _player; 
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _StartPosition = transform.position;
        _Landed = false;
    }
    
    
    
    void Update()
    {
        if (_player.position.x > transform.position.x - 1.5 && _player.position.x < transform.position.x + 1.5)
        {
            Falling();
        }

        if (_Landed)
        {
            GoBack();
        }
    }


    void Falling()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void GoBack()
    {
        if (transform.position.y < _StartPosition.y)
        {
            _rb.bodyType = RigidbodyType2D.Kinematic;
            _rb.velocity = new Vector2(0f, speed);
        }
        else
        {
            _rb.velocity = new Vector2(0f, speed);
            _rb.bodyType = RigidbodyType2D.Static;
            _Landed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _Landed = true;
        }
    }
}
