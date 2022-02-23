using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalQuiz : MonoBehaviour
{
    public Button correctButton;
    public Button incorrectButton1;
    public Button incorrectButton2;
    public Button incorrectButton3;
    public Button nextButton;
    public Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextButton.enabled = false;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onCorrectClick()
    {
        //nextButton.enabled = true;
        score += 25;
        scoreText.text = "Score: " + score;
    }
}
