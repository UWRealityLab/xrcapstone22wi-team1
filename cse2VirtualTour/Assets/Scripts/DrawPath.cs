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