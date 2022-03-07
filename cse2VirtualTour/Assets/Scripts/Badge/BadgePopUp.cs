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
    public GameObject TaskCompleteCanvas;
    public TextMeshProUGUI TaskCompleteDialogue;
    public GameObject OKButton;

    bool advisingTaskCompleted;
    bool quizTaskCoompleted;
    bool alreadyShowDialogue;

    private const string TASK_COMPLETE_DIALOGUE = "Congratulation! You've completed all the tasks for this virtual tour! Now you are given a Husky card as a badge to unlock the entry to the undergrad commons to explore more!";
    // Start is called before the first frame update
    void Start()
    {
        advisingTaskCompleted = false;
        quizTaskCoompleted = false;
        alreadyShowDialogue = false;
        TaskCompleteCanvas.SetActive(false);
        OKButton.SetActive(false);
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
        TaskCompleteCanvas.SetActive(true);
        StartCoroutine(ShowDialogue());
        alreadyShowDialogue = true;
    }

    IEnumerator ShowDialogue()
    {
        yield return StartCoroutine(PrintMessage(TASK_COMPLETE_DIALOGUE));
        OKButton.SetActive(true);
    }
    IEnumerator PrintMessage(string message)
    {
        TaskCompleteDialogue.text = "";
        foreach (string str in message.Split(' '))
        {
            TaskCompleteDialogue.text += str + " ";
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1);
    }
}
