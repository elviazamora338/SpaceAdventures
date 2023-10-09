using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{   
    public Image[] lives;

    public GameManagerScript gameManager;
    void Start()
   {
    //int TheCoins = GetComponent<Coins>();
   }
    public void loseLife()
    {
        if (Globals.myHearts > 0)
       {
            //Globals.myHearts--;
            // lives[Globals.myHearts].gameObject.SetActive(false);
            UpdateHearts();
       }
       
        if (Globals.myHearts == 0)
        {
            gameManager.gameOver();
            Debug.Log("YOU LOST");

        }
        
    }
    void UpdateHearts()
    {
        Globals.myHearts--;
        lives[Globals.myHearts].gameObject.SetActive(false);
    }
}

