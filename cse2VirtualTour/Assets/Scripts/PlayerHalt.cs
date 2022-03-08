using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHalt : MonoBehaviour
{
    // Start is called before the first frame update
    private bool enterAdvCenter;
    private bool enterInteracWall;
    private bool enterInterRoom;
    private bool quizTaskCompleted;
    public GameObject locomotion;

    public Transform advCenter;
    public Transform interacWall;
    public Transform intervRoom;
    void OnTriggerEnter(Collider collider)
    {

        switch (collider.name)
        {
            case "DoorOpenCollider":
                if (!enterAdvCenter)
                {

                    Debug.Log("Player Enter Adv Center");
                    enterAdvCenter = true;
                    StartCoroutine(HaltPlayer(16));
                }

                break;
            case "Interactive Section":
                if (!enterInteracWall)
                {
                    enterInteracWall = true;
                    StartCoroutine(HaltPlayer(22));
                }
                break;
            case "InterviewRoom":
                if (!enterInterRoom)
                {
                    enterInterRoom = true;
                    StartCoroutine(HaltPlayer(12));
                }
                break;
            default:
                break;
        }
    }
    public IEnumerator HaltPlayer(int sec)
    {
        locomotion.SetActive(false);
        yield return new WaitForSeconds(sec);
        locomotion.SetActive(true);
    }
    private void Start()
    {
        StartCoroutine(HaltPlayer(22));
    }

    private void Update()
    {
        if (!quizTaskCompleted && GetComponent<DubsDialogue>().getQuizTaskComplete())
        {
            quizTaskCompleted = true;
            StartCoroutine(HaltPlayer(12));
        }
        if (!enterInteracWall)
        {
            //Debug.Log("Draw path to interactive wall");
            GetComponent<DrawPath>().calculatePath(interacWall.position);
        }
        else if (!enterAdvCenter)
        {
            //Debug.Log("Draw path to advising center");
            GetComponent<DrawPath>().calculatePath(advCenter.position);
        }
        else if (!enterInterRoom)
        {
            //Debug.Log("Draw path to interview room");
            GetComponent<DrawPath>().calculatePath(intervRoom.position);
        } else
        {
            GetComponent<DrawPath>().disablePath();
        }
    }
}
