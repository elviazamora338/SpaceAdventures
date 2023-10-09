using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath1 : MonoBehaviour
{
    Vector2 _StartPosition;
    Vector2 _CurrentPosition;
    Rigidbody2D _rb;
    public float speed;
    public float distance;
    SpriteRenderer _sr;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _StartPosition = transform.position;
        _rb.velocity = new Vector2(-speed, 0);

    }

    // Update is called once per frame
    void Update()
    {
        _CurrentPosition = transform.position;

        if(Vector2.Distance(_CurrentPosition, _StartPosition) >= distance && _CurrentPosition.x < _StartPosition.x)
        {
            _rb.velocity = new Vector2(speed,0);
            _sr.flipX = true; // Flip the sprite horizontally
        }
        if(Vector2.Distance(_CurrentPosition, _StartPosition) >= distance && _CurrentPosition.x >_StartPosition.x)
        {
            _rb.velocity = new Vector2(-speed,0);
            _sr.flipX = false; // Reset sprite flip
        }
        
     }

}

