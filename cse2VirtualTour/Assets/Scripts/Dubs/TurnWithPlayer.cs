using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWithPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform mTarget;

    float mSpeed = 3f;
    Vector3 TargetRotation;
    Animator mAnimator;
    const float EPSILON = 2.5f;
    const float EPSILON2 = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(0, mTarget.localEulerAngles.y, 0);
        if (mTarget.localEulerAngles.y - transform.localEulerAngles.y > 0)
        {
            mAnimator.SetBool("TurnRight", true);
            Debug.Log("positive");
        } else if (mTarget.localEulerAngles.y - transform.localEulerAngles.y < 0)
        {
            mAnimator.SetBool("TurnLeft", true);
            Debug.Log("negative");
        } else
        {
            mAnimator.SetBool("TurnRight", false);
            mAnimator.SetBool("TurnLeft", false);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, target, 1f);
        


    }
}
