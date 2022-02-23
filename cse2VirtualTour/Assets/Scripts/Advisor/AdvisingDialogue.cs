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
        StartCoroutine(showWelcomeDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator showWelcomeDialogue()
    {
        foreach (char letter in WELCOME_MESSAGE.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }
}
