using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DubsNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    [SerializeField] private Transform CameraPositionTransform;
    [SerializeField] private float EPSILON;
    Animator mAnimator;
    private NavMeshAgent navMeshAgent;
    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

   
    private void Update()
    {
  
        float angle = movePositionTransform.localEulerAngles.y + CameraPositionTransform.localEulerAngles.y;
        Vector3 mLookDirection;
        mLookDirection.x = movePositionTransform.position.x + Mathf.Sin(angle * Mathf.Deg2Rad) * 2.5f;
        mLookDirection.z = movePositionTransform.position.z + Mathf.Cos(angle * Mathf.Deg2Rad) * 2.5f;
        mLookDirection.y = transform.position.y;
      

        if ((transform.position - mLookDirection).magnitude > EPSILON )
        {
            mAnimator.SetBool("IsMoving", true);

            navMeshAgent.destination = mLookDirection;
        }
        else
        {
            mAnimator.SetBool("IsMoving", false);
          
        }
        
    }
}
