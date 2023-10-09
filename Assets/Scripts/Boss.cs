using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
   
   
    public int maxHealth = 80;
    public int Damage = 20;
    private int currentHealth;
    Animator _animate;

    void Start()
    {
         // HealthBar code
        currentHealth = maxHealth;
        _animate = GetComponent<Animator>();
    }

    void PlayerDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            _animate.SetTrigger("Death");
            Destroy(gameObject, 1.0f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KillSpot"))
        {
            PlayerDamage(Damage);
        }

    }
}