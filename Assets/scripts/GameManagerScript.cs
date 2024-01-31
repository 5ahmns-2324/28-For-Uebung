using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


// TURORIAL (PART 1): https://www.youtube.com/watch?v=G9QDFB2RQGA
// TURORIAL (PART 2): https://www.youtube.com/watch?v=POUemIGCyr0

public class GameManagerScript : MonoBehaviour
{
    public List<QuestionAndAnswerScript> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject PlayerScreen;
    public GameObject FinishScreen;

    private float currentTime = 0f;

    public Text timerText;

    public Button restartButton;



    public Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
        FinishScreen.SetActive(false);
        PlayerScreen.SetActive(true);
        StartCoroutine(CountUpTimer());
        restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    IEnumerator CountUpTimer()
    {
        while (true)
        {
            currentTime += Time.deltaTime;

            UpdateTimerText();

            yield return null;
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Zeit: " + Mathf.RoundToInt(currentTime).ToString() + "s";
        }
    }



    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++) 
        {
            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent <AnswersScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count != 0) { 
        Random.InitState(42);
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
        }
        else
        {
            finish();
            PlayerScreen.SetActive(false);
            FinishScreen.SetActive(true);

        }

    }


    void finish()
    {
        Debug.Log("FINIIISHHHHHHHHH");
        
    }



}



