using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenCollider : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject dialogueHandler;
    public GameObject contentCanvas;
    public GameObject advisor;
    public bool doorOpened;
    
    // Start is called before the first frame update
    void Start()
    {
        doorOpened = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "XR Origin Collider" && !doorOpened)
        {
            StartCoroutine(OpenAdvisingDoor());
        }
    }
    
    IEnumerator OpenAdvisingDoor()
    {
        Vector3 move = Vector3.right * 0.05f;
        float totalMovement = 2; // distance to open the door
        float frames = totalMovement / 0.05f;
        int count = 0;
        for (int i = 0; i < frames; i++)
        {
            leftDoor.transform.Translate(move);
            rightDoor.transform.Translate(move);
            count++;
            yield return 0;
            
        }
        doorOpened = true;
        ShowAdvisorWelcomeMessage();
    }

    private void ShowAdvisorWelcomeMessage()
    {
        contentCanvas.SetActive(true);
        advisor.GetComponent<Advisor>().Wave();
        dialogueHandler.GetComponent<AdvisingDialogue>().ShowWelcomeMessage();
    }

}
