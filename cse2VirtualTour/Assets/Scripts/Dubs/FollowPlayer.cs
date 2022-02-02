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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx = mTarget.position.x - transform.position.x;
        float dz = mTarget.position.z - transform.position.z;
        mLookDirection.x = dx;
        mLookDirection.z = dz;
        //mLookDirection.y = mTarget.position.y - transform.position.y
        if (mLookDirection.magnitude > EPSILON)
        {
            transform.Translate(mLookDirection  * Time.deltaTime * mSpeed);
        }
        
        if (mLookDirection.magnitude < EPSILON2)
        {
            transform.Translate(-mLookDirection * Time.deltaTime * mSpeed);
        }
        //transform.Translate(Vector3.up * ((mTarget.position.y - 2.5f)- transform.position.y) * Time.deltaTime * mSpeed);
    }
}
