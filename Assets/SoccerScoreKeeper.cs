using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SoccerScoreKeeper : MonoBehaviour
{
    public int Score;
    public int VictoryScore;
    public Text ScoreVisual;
    public Text VictoryDisplay;
    public GameObject ball;

    public UnityEvent after_goal_response;

	
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Score++;
            ScoreVisual.text = "Score: " + Score;
            if (Score >= VictoryScore)
            {
                VictoryDisplay.gameObject.SetActive(true);
            }
            ball.gameObject.SetActive(false);
            after_goal_response.Invoke();
        }
    }
}
