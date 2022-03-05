using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DubsDialogueInterviewRoom : MonoBehaviour
{
    public GameObject dubsDialogueHandler;
    public GameObject dubsDialogueBubble;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "XR Origin Collider")
        { 
            StartCoroutine(DubsPopUpDialog());
        }
    }
    private IEnumerator DubsPopUpDialog()
    {
        dubsDialogueBubble.SetActive(true);
        dubsDialogueHandler.GetComponent<DubsDialogue>().IntroInteracWall();
        yield return new WaitForSeconds(5);
        dubsDialogueBubble.SetActive(false);
    }
// Update is called once per frame
}
