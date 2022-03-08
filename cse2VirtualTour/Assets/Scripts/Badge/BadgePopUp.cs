using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BadgePopUp : MonoBehaviour
{
    public Transform XROrigin;
    public DoorOpenCollider DoorOpenCollider;
    public QuizManager QuizManager;
    public GameObject HuskyCard;

    bool advisingTaskCompleted;
    bool quizTaskCoompleted;
    bool alreadyShowDialogue;

    // Start is called before the first frame update
    void Start()
    {
        advisingTaskCompleted = false;
        quizTaskCoompleted = false;
        alreadyShowDialogue = false;
        HuskyCard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DoorOpenCollider.doorOpened)
        {
            advisingTaskCompleted = true;
        }
        if (QuizManager.QuizCompleted)
        {
            quizTaskCoompleted = true;
        }
        if (quizTaskCoompleted && advisingTaskCompleted && !alreadyShowDialogue)
        {
            TaskCompleteDialoguePopUp();
        }
    }

    

    void TaskCompleteDialoguePopUp()
    { 
        alreadyShowDialogue = true;
        HuskyCard.SetActive(true);
    }
}
