using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdvisingDialogue : MonoBehaviour
{

    private const float DIALOGUE_SLOW = 0.35f;
    private const float DIALOGUE_MIDDLE = 0.28f;
    private const float DIALOGUE_FAST = 0.2f;
    public TextMeshProUGUI dialogue;
    public GameObject optionsWrapper;
    public GameObject advisorObject;
    private Advisor advisor;
    private AudioSource audioSource;

    private void Start()
    {
        advisor = advisorObject.GetComponent<Advisor>();
        audioSource = advisor.GetComponent<AudioSource>();
    }

    public void ShowWelcomeMessage()
    {
        StartCoroutine(ShowWelcomeDialogue());
    }

    private IEnumerator ShowWelcomeDialogue()
    {
        yield return StartCoroutine(PrintMessage(Message.WELCOME_MESSAGE, "WELCOME_MESSAGE", DIALOGUE_SLOW));
        StartCoroutine(AskUserRole());
    }

    private IEnumerator AskUserRole()
    {
        ClearOptionWrapper();
        yield return StartCoroutine(PrintMessage(Message.ASK_ROLE, "ASK_ROLE", DIALOGUE_FAST));
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
        advisor.Bow();

        yield return StartCoroutine(PrintMessage(Message.HIGH_SCHOOL_INTRO, "HIGH_SCHOOL_INTRO", DIALOGUE_MIDDLE));

        Dictionary<string, UnityEngine.Events.UnityAction> questions = getHighSchoolQuestionList();
        SetOptionWrapperLayout(true, TextAnchor.MiddleCenter);
        CreateButton("Back", () => { StartCoroutine(AskUserRole()); });
        CreateButton("Next", () => { AskTopic(questions); });
    }

    private void ShowHighSchoolAnswer(string answer, string audioName)
    {
        StartCoroutine(ShowHighSchoolAnswer2(answer, audioName));
    }

    private IEnumerator ShowHighSchoolAnswer2(string answer, string audioName)
    {
        ClearOptionWrapper();
        yield return StartCoroutine(PrintMessage(answer, audioName, DIALOGUE_SLOW));
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
        advisor.Bow();
        yield return StartCoroutine(PrintMessage(Message.TRANSFER_INTRO, "TRANSFER_INTRO", DIALOGUE_MIDDLE));
        Dictionary<string, UnityEngine.Events.UnityAction> questions = getTransferQuestionList();
        SetOptionWrapperLayout(true, TextAnchor.MiddleCenter);
        CreateButton("Back", () => { StartCoroutine(AskUserRole()); });
        CreateButton("Next", () => { AskTopic(questions); });
    }

    private void ShowTransferAnswer(string answer, string audioName)
    {
        StartCoroutine(ShowTransferAnswer2(answer, audioName));
    }

    private IEnumerator ShowTransferAnswer2(string answer, string audioName)
    {
        ClearOptionWrapper();
        yield return StartCoroutine(PrintMessage(answer, audioName, DIALOGUE_SLOW));
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
        yield return StartCoroutine(PrintMessage(Message.ASK_TOPIC, "ASK_TOPIC", DIALOGUE_FAST));
        SetOptionWrapperLayout(false, TextAnchor.MiddleCenter, 10);
        foreach (KeyValuePair<string, UnityEngine.Events.UnityAction> entry in questions)
        {
            CreateButton(entry.Key, entry.Value, 450);
        }
        CreateButton("Back", () => { StartCoroutine(AskUserRole()); });
    }

    private Dictionary<string, UnityEngine.Events.UnityAction> getHighSchoolQuestionList()
    {
        Dictionary<string, UnityEngine.Events.UnityAction> questions = new Dictionary<string, UnityEngine.Events.UnityAction>();
        questions.Add(Message.HS_Q_ADMIN_RATE, () => { ShowHighSchoolAnswer(Message.HS_A_ADMIN_RATE, "HS_A_ADMIN_RATE"); });
        questions.Add(Message.HS_Q_PROGRAM_EXP, () => { ShowHighSchoolAnswer(Message.HS_A_PROGRAM_EXP, "HS_A_PROGRAM_EXP"); });
        questions.Add(Message.HS_Q_GPA, () => { ShowHighSchoolAnswer(Message.HS_A_GPA, "HS_A_GPA"); });
        questions.Add(Message.HS_Q_NOT_ADMIT, () => { ShowHighSchoolAnswer(Message.HS_A_NOT_ADMIT, "HS_A_NOT_ADMIT"); });
        questions.Add(Message.HS_Q_CHANGE_MAJOR, () => { ShowHighSchoolAnswer(Message.HS_A_CHANGE_MAJOR, "HS_A_CHANGE_MAJOR"); });

        return questions;
    }


    private Dictionary<string, UnityEngine.Events.UnityAction> getTransferQuestionList()
    {
        Dictionary<string, UnityEngine.Events.UnityAction> questions = new Dictionary<string, UnityEngine.Events.UnityAction>();
        questions.Add(Message.TF_Q_TIMELINE, () => { ShowTransferAnswer(Message.TF_A_TIMELINE, "TF_A_TIMELINE"); });
        questions.Add(Message.TF_Q_GPA, () => { ShowTransferAnswer(Message.TF_A_GPA, "TF_A_GPA"); });
        questions.Add(Message.TF_Q_APPLY, () => { ShowTransferAnswer(Message.TF_A_APPLY, "TF_A_APPLY"); });
        questions.Add(Message.TF_Q_REAPPLY, () => { ShowTransferAnswer(Message.TF_A_REAPPLY, "TF_A_REAPPLY"); });
        questions.Add(Message.TF_Q_REVIEW, () => { ShowTransferAnswer(Message.TF_A_REVIEW, "TF_A_REVIEW"); });
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
        Transform textTransform = button.transform.GetChild(0);
        RectTransform textRT = textTransform.GetComponent<RectTransform>();
        button.transform.SetParent(optionsWrapper.transform, false);
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 45);
        button.GetComponent<Button>().onClick.AddListener(onClick);
        textTransform.GetComponent<Text>().text = text;
        textRT.offsetMin = new Vector2(5, textRT.offsetMin.y);
        textRT.offsetMax = new Vector2(-5, textRT.offsetMax.y);

        return button;
    }

    private IEnumerator PrintMessage(string message, string audioName, float speed)
    {
        PlayAudio(audioName);
        dialogue.text = "";
        foreach (string str in message.Split(' '))
        {
            dialogue.text += str + " ";
            yield return new WaitForSeconds(speed);
        }
        while (audioSource.isPlaying)
        {
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);

    }

    private void PlayAudio(string filename)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/Advisor/" + filename);
        audioSource.clip = clip;
        audioSource.Play();
    }
}
