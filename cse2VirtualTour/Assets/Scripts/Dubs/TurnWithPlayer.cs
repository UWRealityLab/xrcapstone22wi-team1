using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWithPlayer : MonoBehaviour
{
    public Transform mCamera;
    public Transform mTarget;

    Animator mAnimator;
    const float EPSILON = 2f;
    const float rSpeed = 0.5f;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(0, mTarget.localEulerAngles.y + mCamera.localEulerAngles.y, 0);
        var cameraAndPlayerRotation = mTarget.localEulerAngles.y + mCamera.localEulerAngles.y;

        // Use EPSILON to prevent the sensitive movement 
        if (cameraAndPlayerRotation % 360 - transform.localEulerAngles.y > EPSILON)
        {
            mAnimator.SetBool("TurnRight", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, rSpeed);
        }
        else if (cameraAndPlayerRotation % 360 - transform.localEulerAngles.y < -EPSILON)
        {
            mAnimator.SetBool("TurnLeft", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, rSpeed);
        }
        else
        {
            mAnimator.SetBool("TurnRight", false);
            mAnimator.SetBool("TurnLeft", false);
        }
    }
}
