using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public QuizManager quizManager;
    public void TriggerRestart()
    {
        quizManager.Restart();
    }
}
