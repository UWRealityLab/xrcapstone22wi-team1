using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advisor : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wave()
    {
        StartCoroutine(Wave2());
    }

    public IEnumerator Wave2()
    {
        Vector3 originalUpperArmAngle = GetUpperLeftArm().localEulerAngles;
        Vector3 originalLowerArmAngle = GetLowerLeftArm().localEulerAngles;
        Vector3 upperArmAngle = new Vector3(-2, 86.9f, -34.8f);
        Vector3 lowerArmAngle = new Vector3(-4.785f, 0, -34.2f);
        int frame = 5;
        for (int i = 0; i < frame; i++)
        {
            GetUpperLeftArm().localEulerAngles = upperArmAngle / frame * i;
            GetLowerLeftArm().localEulerAngles = lowerArmAngle / frame * i;
            yield return 0;
        }
        frame = 40;
        for (int i = 0; i < frame; i++)
        {
            GetLowerLeftArm().localEulerAngles = new Vector3(-4.785f, 0, Mathf.PingPong(Time.time * 60, 20.8f) - 55);
            yield return 0;
        }

    }

    public void Reset()
    {

    }

    private Transform GetUpperLeftArm()
    {
        return transform.Find("Pelvis/Spine_01/Spine_02/Spine_03/Clavicle_L/Upperarm_L");
    }

    private Transform GetUpperRightArm()
    {
        return transform.Find("Pelvis/Spine_01/Spine_02/Spine_03/Clavicle_R/Upperarm_R");
    }

    private Transform GetLowerLeftArm()
    {
        return GetUpperLeftArm().Find("Lowerarm_L");
    }

    private Transform GetLowerRightArm()
    {
        return GetUpperRightArm().Find("Lowerarm_R");
    }

    private Transform GetLeftHand()
    {
        return GetLowerLeftArm().Find("Hand_L");
    }

    private Transform GetRightHand()
    {
        return GetLowerRightArm().Find("Hand_R");
    }

    private void SaveOriginalTransform()
    {

    }
}
