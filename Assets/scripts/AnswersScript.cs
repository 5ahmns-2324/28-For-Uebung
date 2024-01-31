using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswersScript : MonoBehaviour
{
    public bool isCorrect = false;
    public GameManagerScript quizmanager;
    int Score = 0;
    public Text scoreText;


    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizmanager.correct();
            Score++;
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizmanager.correct();
        }

    }

    private void Update()
    {
        scoreText.text = Score + " Punkte";
    }
}
