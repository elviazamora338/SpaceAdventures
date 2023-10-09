using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Animator _animate;
     void Start()
    {
        _animate = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KillSpot"))
        {
            _animate.SetTrigger("Death");
            Destroy(gameObject, 0.7f);
        }
    }
}
