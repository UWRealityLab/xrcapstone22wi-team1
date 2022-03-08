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

    private IEnumerator IntroAdvCenterMessage()
    {
        yield return StartCoroutine(PrintMessage(Message.VIRTUAL_ADIVISING_CENTER, false));
        yield return StartCoroutine(PrintMessage(Message.VIRTUAL_ADIVISING_CENTER_TWO, true));
    }


    private IEnumerator IntroInteracWallMessage()
    {
        yield return StartCoroutine(PrintMessage(Message.INTERACTIVE_WALL, false));
        yield return StartCoroutine(PrintMessage(Message.INTERACTIVE_WALL_TWO, true));
    }
    private IEnumerator IntroInterviewRoomMessage()
    {
        yield return StartCoroutine(PrintMessage(Message.INTERVIEW_ROOM, false));
    }
    private IEnumerator IntroWelcomeMessage()
    {
        yield return StartCoroutine(PrintMessage(Message.GAME_START, false));
        yield return StartCoroutine(PrintMessage(Message.GAME_START_TWO, true));
    }

    public IEnumerator PrintMessage(string message, bool part2)
    {
        dubs.GetComponent<DubsNavMesh>().messagePopUp = true;
        yield return new WaitForSeconds(2);
        float begin_time = Time.time;
 

        dubsDialogueBubble.SetActive(true);
        if (!part2)
        {
            dubs.GetComponent<Animator>().SetBool("DisplayingMessage", true);
            audioSource.Play();
        }
        dialogue.text = "";
        foreach (string str in message.Split(' '))
        {
            dialogue.text += str + " ";
            yield return new WaitForSeconds(speed);
            
            if (Time.time - begin_time > 2f)
            {
                dubs.GetComponent<Animator>().SetBool("DisplayingMessage", false);
            }
            
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
        
        IntroAdvCenter();
        yield return new WaitForSeconds(16);
        dubsDialogueBubble.SetActive(false);
        dubs.GetComponent<DubsNavMesh>().messagePopUp = false;
       
    }
    private IEnumerator InteracWall()
    {
        IntroInteracWall();
        yield return new WaitForSeconds(22);
        dubsDialogueBubble.SetActive(false);
        dubs.GetComponent<DubsNavMesh>().messagePopUp = false;
       
    }
    private IEnumerator IntervRoom()
    {
        IntroInterviewRoom();
        yield return new WaitForSeconds(12);
        dubsDialogueBubble.SetActive(false);
        dubs.GetComponent<DubsNavMesh>().messagePopUp = false;
       
    }
    private IEnumerator GameStart()
    {
        
        IntroWelcome();
        yield return new WaitForSeconds(22);
        dubsDialogueBubble.SetActive(false);
        
        dubs.GetComponent<DubsNavMesh>().messagePopUp = false;
        dubs.GetComponent<Animator>().SetBool("DisplayingMessage", false);
    }

    private void Start()
    {
        StartCoroutine(GameStart());
    }
}
