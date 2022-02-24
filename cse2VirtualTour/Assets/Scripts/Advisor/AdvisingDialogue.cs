using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdvisingDialogue : MonoBehaviour
{
    
   private static float speed = 0.05f;

    public TextMeshProUGUI dialogue;
    public GameObject optionsWrapper;
    public GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ShowRoleOptions();
    }

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
        optionsWrapper.AddComponent<HorizontalLayoutGroup>();
        optionsWrapper.GetComponent<HorizontalLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
        optionsWrapper.GetComponent<HorizontalLayoutGroup>().childControlHeight = false;
        optionsWrapper.GetComponent<HorizontalLayoutGroup>().childControlWidth = false;
        //optionsWrapper.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        GameObject highSchoolButton = CreateButton("High School");
        GameObject transferButton = CreateButton("Transfer");

    }

    private GameObject CreateButton(string text)
    {
        GameObject button2 = DefaultControls.CreateButton(new DefaultControls.Resources());
        button2.transform.SetParent(optionsWrapper.transform, false);
        button2.transform.GetChild(0).GetComponent<Text>().text = text;
        button2.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 30);
        return button2;
        GameObject button = Instantiate(buttonPrefab, optionsWrapper.transform, false);
        //button.transform.SetParent(content.transform);
        //button.transform.position = new Vector3(0, 0, 0);
        //button.transform.rotation = Quaternion.Euler(0, 0, 0);
        //button.transform.localScale = new Vector3(1, 1, 1);
        Debug.Log(button.transform.position);
        Transform textObj = button.transform.GetChild(0).GetChild(0).GetChild(0);
        textObj.GetComponent<Text>().text = text;
        return button;
    }

    private Transform getActualButton(GameObject buttonPrefab)
    {
        return buttonPrefab.transform.GetChild(0).GetChild(0);
    }

    private IEnumerator PrintMessage(string message)
    {
        dialogue.text = "";
        foreach (char letter in message.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(1);
    }
}
