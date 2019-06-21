using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int Score;
    public int VictoryScore;
    public Text ScoreVisual;
    public Text VictoryDisplay;

	// Use this for initialization
	void Start ()
    {
        VictoryScore = FindObjectsOfType<PickUpBehaviour>().Length;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ScoreVisual.text = "Score: " + Score;

	    if(Score >= VictoryScore)
        {
            VictoryDisplay.gameObject.SetActive(true);
        }
	}
}
