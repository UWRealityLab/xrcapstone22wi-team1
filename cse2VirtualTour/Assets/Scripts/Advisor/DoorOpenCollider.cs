using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenCollider : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;
    private bool doorOpened;
    
    // Start is called before the first frame update
    void Start()
    {
        doorOpened = false;
        Debug.Log(Time.deltaTime);
        OpenAdvisingDoor();
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        if(collider.name == "XR Origin Collider" && !doorOpened)
        {
            StartCoroutine(OpenAdvisingDoor());
        }
    }
    
    IEnumerator OpenAdvisingDoor()
    {
        Debug.Log("open advising door");
        Vector3 move = Vector3.right * 0.1f;
        float totalMovement = 2; // distance to open the door
        float frames = totalMovement / 0.1f;
        Debug.Log(leftDoor.transform.position);
        Debug.Log(frames);
        int count = 0;
        for (int i = 0; i < frames; i++)
        {
            leftDoor.transform.Translate(move);
            rightDoor.transform.Translate(move);
            Debug.Log(move * Time.deltaTime);
            count++;
            yield return 0;
            
        }
        Debug.Log(leftDoor.transform.position);
        Debug.Log(count);
        doorOpened = true;
    }


}
