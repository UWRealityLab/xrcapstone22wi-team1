using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWithPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform mTarget;

    float mSpeed = 1.5f;
    Vector3 TargetRotation;

    const float EPSILON = 2.5f;
    const float EPSILON2 = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TargetRotation = mTarget.localEulerAngles;
        TargetRotation.x = 0;
        TargetRotation.z = 0;
        //TargetRotation.y = -5;
        
        //Debug.Log(TargetRotation);
        Debug.Log(transform.localEulerAngles.y - mTarget.localEulerAngles.y);
        if (Mathf.Abs(transform.localEulerAngles.y - mTarget.localEulerAngles.y) > 3f)
        {
            if (transform.localEulerAngles.y - mTarget.localEulerAngles.y > 0f)
            {
                //TargetRotation.y -= 360f;
                //Debug.Log(TargetRotation);
                transform.Rotate(-TargetRotation, 3f);
            }
            else
            {
                //TargetRotation.y -= 360f;
               // Debug.Log(TargetRotation);
                transform.Rotate(TargetRotation, 3f);
            }
            
        }

    }
}
