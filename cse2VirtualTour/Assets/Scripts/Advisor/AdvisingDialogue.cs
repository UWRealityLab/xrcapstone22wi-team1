using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdvisingDialogue : MonoBehaviour
{
    
    private static string WELCOME_MESSAGE = "Welcome to the CSE advising center. I'm your advisor Anna.";
    private static float speed = 0.05f;

    public TextMeshProUGUI dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowWelcomeMessage()
    {
        StartCoroutine(ShowWelcomeDialogue());
    }

    private IEnumerator ShowWelcomeDialogue()
    {
        foreach (char letter in WELCOME_MESSAGE.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }
}
