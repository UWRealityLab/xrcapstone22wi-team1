using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QnA> QnAList;
    public GameObject[] options;

    public GameObject QuizPanel;
    public GameObject CompletedPanel;
    public GameObject StartPanel;

    public TMP_Text QuestionText;

    int currentQuestionIndex = 0;

    private void Start()
    {
        currentQuestionIndex = 0;
        CompletedPanel.SetActive(false);
        generateQuestion();
    }

    public void Restart()
    {
        currentQuestionIndex = 0;
        CompletedPanel.SetActive(false);
        QuizPanel.SetActive(true);
        generateQuestion();
    }

    void completed()
    {
        QuizPanel.SetActive(false);
        CompletedPanel.SetActive(true);
    }

    public void correct()
    {
        // if correct, generate the next question
        //QnAList.RemoveAt(currentQuestionIndex);
        currentQuestionIndex++;
        StartCoroutine(WaitForNext());
    }

    public void wrong()
    {
        Wait();
    }

    void generateQuestion()
    {
        if (currentQuestionIndex < QnAList.Count)
        {
            QuestionText.text = QnAList[currentQuestionIndex].Question;
            setOptionsText();
        }
        //if (QnAList.Count > 0)
        //{
        //    currentQuestionIndex = Random.Range(0, QnAList.Count);
        //    QuestionText.text = QnAList[currentQuestionIndex].Question;
        //    setOptionsText();
        //}
        else
        {
            completed();
        }
        
    }

    void setOptionsText()
    {
        for (int i = 0; i < options.Length; i++)
        {
            //options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<Image>().color = Color.white;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnAList[currentQuestionIndex].Answers[i];

            // set the correct option
            if (QnAList[currentQuestionIndex].CorrectAnswerIndex == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                Debug.Log("correct option set: index " + (i));
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1.0f);
        generateQuestion();
    }
}
