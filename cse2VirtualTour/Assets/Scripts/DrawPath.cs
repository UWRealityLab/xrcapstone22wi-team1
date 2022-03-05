//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class DrawPath : MonoBehaviour
//{
//    // Start is called before the first frame update
//    private LineRenderer lineRenderer;
//    NavMeshPath path;
//    public void calculatePath(Vector3 target)
//    {

//        Vector3 src = new Vector3(transform.position.x, 0, transform.position.z);
//        target.y = 0;
//        NavMesh.CalculatePath(src, target, NavMesh.AllAreas, path); //Saves the path in the path variable.
//        Vector3[] corners = path.corners;
//        Debug.Log("Length: " + corners.Length);
//        Debug.Log("Target: " + target);
//        Debug.Log("Player: " + transform.position);
//        for (int i = 0; i < corners.Length; i++)
//        {
//            Debug.Log(corners[i]);
//        }
//        if (corners.Length < 2)
//        {
//            return;
//        }
//        for (int i = 1; i < corners.Length; i++)
//        {
//            Vector3 pointPosition = new Vector3(corners[i].x, corners[i].y, corners[i].z);
//            lineRenderer.SetPosition(i, pointPosition);
//        }

//    }
//    private void Start()
//    { 
//        path = new NavMeshPath();
//        lineRenderer = GetComponent<LineRenderer>();
//        lineRenderer.startWidth = 0.15f;
//        lineRenderer.endWidth = 0.15f;
//        lineRenderer.positionCount = 0;
//    }
//}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class DrawPath : MonoBehaviour
{
  
    [SerializeField]
    private LineRenderer Path;
    [SerializeField]
    private float PathHeightOffset = 1.25f;
    [SerializeField]
    private float SpawnHeightOffset = 1.5f;
    [SerializeField]
    private float PathUpdateSpeed = 0.25f;

    private NavMeshTriangulation Triangulation;
    private Coroutine DrawPathCoroutine;

    private void Awake()
    {
        Triangulation = NavMesh.CalculateTriangulation();
        Path.startWidth = 0.05f;
        Path.endWidth = 0.05f;
    }

    public void calculatePath(Vector3 target)
    {
        DrawPathCoroutine = StartCoroutine(DrawPathToCollectable(target));
    }

    private IEnumerator DrawPathToCollectable(Vector3 target)
    {
        WaitForSeconds Wait = new WaitForSeconds(PathUpdateSpeed);
        NavMeshPath path = new NavMeshPath();

       
        if (NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path))
        {
            Path.positionCount = path.corners.Length;

            for (int i = 0; i < path.corners.Length; i++)
            {
                Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffset);
            }
        }

        yield return Wait;
        
    }

    internal void disablePath()
    {
        Path.positionCount = 0;
    }
}