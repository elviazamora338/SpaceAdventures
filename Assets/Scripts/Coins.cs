using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coins : MonoBehaviour
{  
    int bronze = 1;
    int silver = 2;
    int gold = 3;
    //from Globals import Globals;
    void Start()
    {
        UpdateCoinsText();
        //myCoins = Globals.coins;
    }

    [SerializeField] private TMP_Text coinsText;
    
   void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.gameObject.CompareTag("GoldCoin"))
        {
            Globals.coins+=gold;
        }

        else if(collision.gameObject.CompareTag("SilverCoin"))
        {
            Globals.coins+=silver;
            }

        else if(collision.gameObject.CompareTag("BronzeCoin"))
        {
            Globals.coins+=bronze;
        }
    
        Destroy(collision.gameObject);
        UpdateCoinsText();
   }
   void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + Globals.coins.ToString();
    }
}

    