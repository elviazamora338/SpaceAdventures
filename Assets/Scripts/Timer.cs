using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public GameObject textDisplay;
    public int secondsLeft = 30;
    public bool takingAway = false;

    public GameManagerScript gameManager;

    private void Start()
    {
        textDisplay.GetComponent<Text>().text = "Timer: " + secondsLeft;
    }

    private void Update()
    {
        if(takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = "Timer:" + secondsLeft;
        takingAway = false;
        if(secondsLeft <= 0)
        {
             gameManager.gameOver();
            Debug.Log("YOU LOST");
        }
    }


}