using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator _animate;
    private Rigidbody2D _rb;
   

    public int maxHealth = 60;
    public int enemyDamage = 20;
    public int SpikeDamage = 60;

    private int currentHealth;
    private Slider HealthBarSlider;

    Hearts heartManager;

    private bool isDead;
    //public GameManagerScript gameManager;

    private Vector3 initialPosition; // Store the initial position of the player
    
    void Start()
    {
        _animate = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        // HealthBar code
        currentHealth = maxHealth;
        HealthBarSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        HealthBarSlider.maxValue = maxHealth;
        HealthBarSlider.value = currentHealth;

        // Get a reference to the Hearts script
        heartManager = GetComponent<Hearts>();
        // Store the initial position of the player
        initialPosition = transform.position;
        Globals.myHearts = 2;
        Globals.coins = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathTrap"))
        {   
            PlayerDamage(enemyDamage);
        }
        else if (collision.gameObject.CompareTag("Spike"))
            PlayerDamage(SpikeDamage);
    }
    


    void Die()
    {
       
        if(Globals.myHearts == 0)
        {
            _rb.bodyType = RigidbodyType2D.Static;
            _animate.SetTrigger("Death");
        }
       
    }

    public void RestartLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PlayerDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        HealthBarSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            if (Globals.myHearts <= 0 && !isDead)
            {   
                isDead = true;
                Die();
                
            }
            else
            {
                ResetPlayer();
            }

            Die();
            heartManager.loseLife();
        }
    }

    void restoreHealth()
    {
        currentHealth = maxHealth;
        HealthBarSlider.maxValue = maxHealth;
        HealthBarSlider.value = currentHealth;
    }

    // Call this method to reset the player's position and variables
    void ResetPlayer()
    {   restoreHealth();
        //_animate.SetTrigger("Respawn");
        transform.position = initialPosition;
        currentHealth = maxHealth;
        HealthBarSlider.value = currentHealth;
    }
}

