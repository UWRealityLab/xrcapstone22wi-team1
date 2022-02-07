using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform mTarget;

    const float mSpeed = 2f;
    const float circleRadiusCenterAtPlayer = 2f;
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
        // Use sin and cos to get the x z coordinate and multiply by circle radius. The product would
        // be the points of the circle that center at player's coordinate.
        mLookDirection.x = mTarget.position.x + Mathf.Sin(angle * Mathf.Deg2Rad) * circleRadiusCenterAtPlayer;
        mLookDirection.z = mTarget.position.z + Mathf.Cos(angle * Mathf.Deg2Rad) * circleRadiusCenterAtPlayer;
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
