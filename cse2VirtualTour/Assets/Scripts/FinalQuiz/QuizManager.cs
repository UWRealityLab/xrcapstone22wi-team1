using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QnA> QnAList;
    public GameObject[] options;
    public int currentQuestionIndex;

    public TMP_Text QuestionText;

    private void Start()
    {
        Debug.Log("Quiz Start");
        print("quiz start");
        generateQuestion();
    }

    public void correct()
    {
        // if correct, generate the next question
        QnAList.RemoveAt(currentQuestionIndex);
        generateQuestion();
    }

    void generateQuestion()
    {
        currentQuestionIndex = Random.Range(0, QnAList.Count);
        QuestionText.text = QnAList[currentQuestionIndex].Question;
        setOptionsText();
    }

    void setOptionsText()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = true;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnAList[currentQuestionIndex].Answers[i];

            // set the correct option
            if (QnAList[currentQuestionIndex].CorrectAnswerIndex == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                Debug.Log("correct option set: index " + (i));
            }
        }
    }
}
