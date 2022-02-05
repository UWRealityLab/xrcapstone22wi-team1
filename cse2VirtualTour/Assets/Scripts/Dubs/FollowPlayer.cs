using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform mTarget;

    float mSpeed = 2f;
    Vector3 mLookDirection;

    Animator mAnimator;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = transform.localEulerAngles.y;
        mLookDirection.x = mTarget.position.x + Mathf.Sin(angle * Mathf.Deg2Rad) * 1.5f;
        mLookDirection.z = mTarget.position.z + Mathf.Cos(angle * Mathf.Deg2Rad) * 1.5f;
        mLookDirection.y = transform.position.y;
 
        if (transform.position != mLookDirection)
        {
            //Debug.Log("Moving");
            transform.position = Vector3.MoveTowards(transform.position, mLookDirection, Time.deltaTime * mSpeed);
            mAnimator.SetBool("IsMoving", true);
        }
        else
        {
            //Debug.Log("Not Moving");
            mAnimator.SetBool("IsMoving", false);
        }
    }
}
