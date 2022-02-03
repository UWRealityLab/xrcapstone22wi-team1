using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform mTarget;

    float mSpeed = 1.5f;
    Vector3 mLookDirection;

    const float EPSILON = 2.5f;
    const float EPSILON2 = 1.5f;
    Animator mAnimator;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = mTarget.position.x;
        float dz = mTarget.position.z;
        mLookDirection.x = dx + 2;
        mLookDirection.z = dz + 2;
        mLookDirection.y = transform.position.y;
        //mLookDirection.y = mTarget.position.y - transform.position.y
        //transform.position = Vector3.Lerp(transform.position, mLookDirection, Time.time);
        if (transform.position != mLookDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, mLookDirection, 0.1f);
            mAnimator.SetBool("IsMoving", true);
            //Debug.Log("Moving");
        }
        else
        {
            //Debug.Log("Not Moving");
            mAnimator.SetBool("IsMoving", false);
        }
        if (mLookDirection.magnitude < EPSILON2)
        {

            //transform.position = Vector3.MoveTowards(transform.position, mLookDirection, 0.1f);
        }
        //transform.Translate(Vector3.up * ((mTarget.position.y - 2.5f)- transform.position.y) * Time.deltaTime * mSpeed);
    }
}
