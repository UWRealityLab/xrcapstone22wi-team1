using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DubsDialogueInteractiveWall : MonoBehaviour
{
    // Start is called before the first frame update
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
}
