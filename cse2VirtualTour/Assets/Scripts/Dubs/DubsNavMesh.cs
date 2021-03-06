using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DubsNavMesh : MonoBehaviour
{
  
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform CameraPositionTransform;
    [SerializeField] private float circleRadius;
    [SerializeField] private float EPSILON;
    [SerializeField] private float playerNoMovementThreshold;
    [SerializeField] private float dubsNoMovementThreshold;
    [SerializeField] private float rotationSpeed;
    Animator mAnimator;
    private NavMeshAgent navMeshAgent;

    private bool playerIsMoving;
    private bool dubsIsMoving;

    public bool messagePopUp;

    Vector3[] playerPreviousLocations = new Vector3[10];
    Vector3[] dubsPreviousLocations = new Vector3[10];

    private float time;

    private void Awake()
    {
        
        mAnimator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        for (int i = 0; i < playerPreviousLocations.Length; i++)
        {
            playerPreviousLocations[i] = Vector3.zero;
        }

        for (int i = 0; i < dubsPreviousLocations.Length; i++)
        {
            dubsPreviousLocations[i] = Vector3.zero;
        }
    }

    private bool determineMoving(Vector3[] preLocation, Transform transform, float noMovementThreshold)
    {
        for (int i = 0; i < preLocation.Length - 1; i++)
        {
            preLocation[i] = preLocation[i + 1];
        }
        preLocation[preLocation.Length - 1] = transform.position;
        for (int i = 0; i < preLocation.Length - 1; i++)
        {
            if (Vector3.Distance(preLocation[i], preLocation[i + 1]) >= noMovementThreshold)
            {
                //Debug.Log("Distance: " + (Vector3.Distance(preLocation[i], preLocation[i + 1])));
                return true;
            }

        }
        return false;
    }

    private void turnToPlayer()
    {
        Quaternion target = Quaternion.Euler(0, playerTransform.localEulerAngles.y + CameraPositionTransform.localEulerAngles.y + 180, 0);
        if (time < 2.5f) // 2 sec for dubs to turn
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);

        }
    }

   
    private void Update()
    {
        playerIsMoving = determineMoving(playerPreviousLocations, playerTransform, playerNoMovementThreshold);
        dubsIsMoving = determineMoving(dubsPreviousLocations, transform, dubsNoMovementThreshold);


        if (dubsIsMoving)
        {
            mAnimator.SetBool("IsMoving", true);
        }
        else
        {
            mAnimator.SetBool("IsMoving", false);
        }

        if (messagePopUp)
        {
            time += Time.deltaTime;
            turnToPlayer();
            return;
        } else
        {
            time = 0;
        }
        



        float angle = playerTransform.localEulerAngles.y + CameraPositionTransform.localEulerAngles.y;
        Vector3 mLookDirection;
        mLookDirection.x = playerTransform.position.x + Mathf.Sin(angle * Mathf.Deg2Rad) * circleRadius;
        mLookDirection.z = playerTransform.position.z + Mathf.Cos(angle * Mathf.Deg2Rad) * circleRadius;
        mLookDirection.y = transform.position.y;

        
        if ((transform.position - mLookDirection).magnitude > EPSILON && playerIsMoving)
        {
            //Debug.Log("Should Move: " + (transform.position - mLookDirection).magnitude);
            mAnimator.SetBool("IsMoving", true);
            navMeshAgent.destination = mLookDirection;
        }



    }
}
