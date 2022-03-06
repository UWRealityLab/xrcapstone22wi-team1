using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DubsDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    private static float speed = 0.2f;

    public TextMeshProUGUI dialogue;
    public GameObject dubsDialogueBubble;
    public GameObject dubs;

    public AudioSource audioSource;
    private bool enterAdvCenter;
    private bool enterInteracWall;
    private bool enterInterRoom;
    public void IntroAdvCenter()
    {
        StartCoroutine(IntroAdvCenterMessage());
    }

    public void IntroInteracWall()
    {
        StartCoroutine(IntroInteracWallMessage());
    }
    public void IntroInterviewRoom()
    {
        StartCoroutine(IntroInterviewRoomMessage());

    }
    public void IntroWelcome()
    {
        StartCoroutine(IntroWelcomeMessage());
    }

    public void IntroPath()
    {
        StartCoroutine(IntroPathMessage());
    }

    private IEnumerator IntroPathMessage()
    {
        yield return StartCoroutine(PrintMessage(Message.FOLLOW_PATH));
    }

    private IEnumerator IntroAdvCenterMessage()
    {
        yield return StartCoroutine(PrintMessage(Message.VIRTUAL_ADIVISING_CENTER));
    }
    private IEnumerator IntroInteracWallMessage()
    {
        yield return StartCoroutine(PrintMessage(Message.INTERACTIVE_WALL));
    }
    private IEnumerator IntroInterviewRoomMessage()
    {
        yield return StartCoroutine(PrintMessage(Message.INTERVIEW_ROOM));
    }
    private IEnumerator IntroWelcomeMessage()
    {
        yield return StartCoroutine(PrintMessage(Message.GAME_START));
    }
    public IEnumerator PrintMessage(string message)
    {

        dialogue.text = "";
        audioSource.Play();
        dubs.GetComponent<DubsNavMesh>().messagePopUp = true;
        foreach (string str in message.Split(' '))
        {
            dialogue.text += str + " ";
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(1);
        
    }

 
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collider name: " + collider.name);
        switch (collider.name)
        {
            case "DoorOpenCollider":
                if (!enterAdvCenter)
                {
                    Debug.Log("Enter Adv Center");
                    enterAdvCenter = true;
                    StartCoroutine(AdvCenter());
                }

                break;
            case "Interactive Section":
                if (!enterInteracWall)
                {
                    Debug.Log("Enter Interactive");
                    enterInteracWall = true;
                    StartCoroutine(InteracWall());
                }                
                break;
            case "InterviewRoom":
                if (!enterInterRoom)
                {
                    enterInterRoom = true;
                    StartCoroutine(IntervRoom());
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator AdvCenter()
    {
        
        dubsDialogueBubble.SetActive(true);
        IntroAdvCenter();
        yield return new WaitForSeconds(8);
        dubsDialogueBubble.SetActive(false);
        dubs.GetComponent<DubsNavMesh>().messagePopUp = false;
       
    }
    private IEnumerator InteracWall()
    {
        dubsDialogueBubble.SetActive(true);
        IntroInteracWall();
        yield return new WaitForSeconds(12);
        dubsDialogueBubble.SetActive(false);
        dubs.GetComponent<DubsNavMesh>().messagePopUp = false;
       
    }
    private IEnumerator IntervRoom()
    {
        dubsDialogueBubble.SetActive(true);
        IntroInterviewRoom();
        yield return new WaitForSeconds(8);
        dubsDialogueBubble.SetActive(false);
        dubs.GetComponent<DubsNavMesh>().messagePopUp = false;
       
    }
    private IEnumerator GameStart()
    {
        dubsDialogueBubble.SetActive(true);
        IntroWelcome();
        yield return new WaitForSeconds(8);
        IntroPath();
        yield return new WaitForSeconds(8);
        dubsDialogueBubble.SetActive(false);
        
        dubs.GetComponent<DubsNavMesh>().messagePopUp = false;
        dubs.GetComponent<Animator>().SetBool("GameStart", true);
      
    }

    private void Start()
    {
        StartCoroutine(GameStart());
    }
}
