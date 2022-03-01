using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advisor : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Wave();
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
        Debug.Log(GetUpperLeftArm().eulerAngles);
        Debug.Log(GetUpperLeftArm().localEulerAngles);
        Debug.Log(GetUpperLeftArm().rotation);
        Debug.Log(GetUpperLeftArm().position);
        Debug.Log(GetUpperLeftArm().localPosition);
        Debug.Log(GetUpperLeftArm().GetComponent<Transform>().position);
        Debug.Log(GetUpperLeftArm().GetComponent<Transform>().rotation);

        Vector3 originalUpperArmAngle = GetVectorWithNegativeValue(GetUpperLeftArm().localEulerAngles);
        Vector3 originalLowerArmAngle = GetVectorWithNegativeValue(GetLowerLeftArm().localEulerAngles);
        Vector3 spinePosition = new Vector3(0.008f, 0.062f, -0.006f);
        Vector3 spineRotation = new Vector3(-5.254f, 0, -14.135f);
        Vector3 upperArmAngle = new Vector3(-2, 86.9f, -34.8f) - originalUpperArmAngle;
        Vector3 lowerArmAngle = new Vector3(-4.785f, 0, -34.2f) - originalLowerArmAngle;

        int frame = 5;

        for (int i = 1; i <= frame; i++)
        {
            GetUpperLeftArm().localEulerAngles = originalUpperArmAngle + upperArmAngle * i / frame;
            GetLowerLeftArm().localEulerAngles = originalLowerArmAngle + lowerArmAngle / frame * i;

            yield return 0;
        }
        frame = 40;
        for (int i = 0; i < frame; i++)
        {
            GetLowerLeftArm().localEulerAngles = new Vector3(-4.785f, 0, Mathf.PingPong(Time.time * 60, 20.8f) - 55);
            yield return 0;
        }
        yield return 0;
    }

    public void Reset()
    {

    }

    private Transform GetSpine1()
    {
        return transform.Find("Pelvis/Spine_01");
    }

    private Transform GetUpperLeftArm()
    {
        return GetSpine1().Find("Spine_02/Spine_03/Clavicle_L/Upperarm_L");
    }

    private Transform GetUpperRightArm()
    {
        return GetSpine1().Find("Spine_02/Spine_03/Clavicle_R/Upperarm_R");
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

    private Vector3 GetVectorWithNegativeValue(Vector3 vector)
    {
        vector.x = (vector.x > 180) ? vector.x - 360 : vector.x;
        vector.y = (vector.y > 180) ? vector.y - 360 : vector.y;
        vector.z = (vector.z > 180) ? vector.z - 360 : vector.z;

        return vector;
    }
}
