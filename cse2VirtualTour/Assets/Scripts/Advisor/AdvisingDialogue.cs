using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdvisingDialogue : MonoBehaviour
{
    
    private static float speed = 0.15f;

    public TextMeshProUGUI dialogue;
    public GameObject optionsWrapper;

    public void ShowWelcomeMessage()
    {
        StartCoroutine(ShowWelcomeDialogue());
    }

    private IEnumerator ShowWelcomeDialogue()
    {
        yield return StartCoroutine(PrintMessage(Message.WELCOME_MESSAGE));
        StartCoroutine(AskUserRole());
    }

    private IEnumerator AskUserRole()
    {
        yield return StartCoroutine(PrintMessage(Message.ASK_ROLE));
        ShowRoleOptions();
    }

    private void ShowRoleOptions()
    {
        SetOptionWrapperLayout(true, TextAnchor.MiddleCenter);
        GameObject highSchoolButton = CreateButton("High School", ShowHighSchoolIntro);
        GameObject transferButton = CreateButton("Transfer", ShowTransferIntro);

    }

    // HIGH SCHOOL SECTION

    void ShowHighSchoolIntro()
    {
        ClearOptionWrapper();
        StartCoroutine(ShowHighSchoolIntro2());
    }

    private IEnumerator ShowHighSchoolIntro2()
    {
        yield return StartCoroutine(PrintMessage(Message.HIGH_SCHOOL_INTRO));

        Dictionary<string, UnityEngine.Events.UnityAction> questions = getHighSchoolQuestionList();
        ShowNextButton(() => { AskTopic(questions); });
    }

    private void ShowHighSchoolAnswer(string answer)
    {
        StartCoroutine(ShowHighSchoolAnswer2(answer));
    }

    private IEnumerator ShowHighSchoolAnswer2(string answer)
    {
        ClearOptionWrapper();
        yield return StartCoroutine(PrintMessage(answer));
        SetOptionWrapperLayout(true, TextAnchor.MiddleRight);
        Dictionary<string, UnityEngine.Events.UnityAction> questions = getHighSchoolQuestionList();

        CreateButton("Back", () => { AskTopic(questions); });
    }

    // TRANSFER SECTION

    void ShowTransferIntro()
    {
        ClearOptionWrapper();
        StartCoroutine(ShowTransferIntro2());
    }

    private IEnumerator ShowTransferIntro2()
    {
        yield return StartCoroutine(PrintMessage(Message.TRANSFER_INTRO));
        Dictionary<string, UnityEngine.Events.UnityAction> questions = getTransferQuestionList();
        ShowNextButton(() => { AskTopic(questions); });
    }

    private void ShowTransferAnswer(string answer)
    {
        StartCoroutine(ShowTransferAnswer2(answer));
    }

    private IEnumerator ShowTransferAnswer2(string answer)
    {
        ClearOptionWrapper();
        yield return StartCoroutine(PrintMessage(answer));
        SetOptionWrapperLayout(true, TextAnchor.MiddleRight);
        Dictionary<string, UnityEngine.Events.UnityAction> questions = getTransferQuestionList();

        CreateButton("Back", () => { AskTopic(questions); });
    }

    // HELPER FUNCTIONS

    private void AskTopic(Dictionary<string, UnityEngine.Events.UnityAction> questions)
    {
        ClearOptionWrapper();
        StartCoroutine(AskTopic2(questions));
    }

    private IEnumerator AskTopic2(Dictionary<string, UnityEngine.Events.UnityAction> questions)
    {
        yield return StartCoroutine(PrintMessage(Message.ASK_TOPIC));
        SetOptionWrapperLayout(false, TextAnchor.MiddleCenter, 10);
        foreach (KeyValuePair<string, UnityEngine.Events.UnityAction> entry in questions)
        {
            CreateButton(entry.Key, entry.Value, 450);
        }
    }

    private Dictionary<string, UnityEngine.Events.UnityAction> getHighSchoolQuestionList()
    {
        Dictionary<string, UnityEngine.Events.UnityAction> questions = new Dictionary<string, UnityEngine.Events.UnityAction>();
        questions.Add(Message.HS_Q_ADMIN_RATE, () => { ShowHighSchoolAnswer(Message.HS_A_ADMIN_RATE); });
        questions.Add(Message.HS_Q_PROGRAM_EXP, () => { ShowHighSchoolAnswer(Message.HS_A_PROGRAM_EXP); });
        questions.Add(Message.HS_Q_GPA, () => { ShowHighSchoolAnswer(Message.HS_A_GPA); });
        return questions;
    }


    private Dictionary<string, UnityEngine.Events.UnityAction> getTransferQuestionList()
    {
        Dictionary<string, UnityEngine.Events.UnityAction> questions = new Dictionary<string, UnityEngine.Events.UnityAction>();
        questions.Add(Message.TF_Q_GPA, () => { ShowTransferAnswer(Message.TF_A_GPA); });
        questions.Add(Message.TF_Q_APPLY, () => { ShowTransferAnswer(Message.TF_A_APPLY); });
        questions.Add(Message.TF_Q_REAPPLY, () => { ShowTransferAnswer(Message.TF_A_REAPPLY); });
        return questions;
    }

    private void ClearOptionWrapper()
    {
        foreach (Transform child in optionsWrapper.transform)
        {
            Destroy(child.gameObject);
        }
        Destroy(optionsWrapper.GetComponent<HorizontalLayoutGroup>());
        Destroy(optionsWrapper.GetComponent<VerticalLayoutGroup>());
    }

    private void ShowNextButton(UnityEngine.Events.UnityAction callback)
    {
        SetOptionWrapperLayout(true, TextAnchor.LowerRight);
        CreateButton("Next", callback);
    }

    private void SetOptionWrapperLayout(bool horizontal, TextAnchor textAnchor, int spacing = 0)
    {
        if (horizontal)
        {
            optionsWrapper.AddComponent<HorizontalLayoutGroup>();
            optionsWrapper.GetComponent<HorizontalLayoutGroup>().childAlignment = textAnchor;
            optionsWrapper.GetComponent<HorizontalLayoutGroup>().childControlHeight = false;
            optionsWrapper.GetComponent<HorizontalLayoutGroup>().childControlWidth = false;
        } else
        {
            optionsWrapper.AddComponent<VerticalLayoutGroup>();
            optionsWrapper.GetComponent<VerticalLayoutGroup>().childAlignment = textAnchor;
            optionsWrapper.GetComponent<VerticalLayoutGroup>().childControlHeight = false;
            optionsWrapper.GetComponent<VerticalLayoutGroup>().childControlWidth = false;
            optionsWrapper.GetComponent<VerticalLayoutGroup>().spacing = spacing;
        }
    }

    private GameObject CreateButton(string text, UnityEngine.Events.UnityAction onClick, int width = 160)
    {
        GameObject button = DefaultControls.CreateButton(new DefaultControls.Resources());
        button.transform.SetParent(optionsWrapper.transform, false);
        button.transform.GetChild(0).GetComponent<Text>().text = text;
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 45);
        button.GetComponent<Button>().onClick.AddListener(onClick);
        return button;
    }

    private IEnumerator PrintMessage(string message)
    {
        dialogue.text = "";
        foreach (string str in message.Split(' '))
        {
            dialogue.text += str + " ";
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(1);
    }
}
