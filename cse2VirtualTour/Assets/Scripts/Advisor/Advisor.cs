using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advisor : MonoBehaviour
{
    private Dictionary<Transform, Vector3> originalPositions;
    private Dictionary<Transform, Vector3> originalRotations;

    // Start is called before the first frame update
    void Start()
    {
        originalPositions = new Dictionary<Transform, Vector3>();
        originalRotations = new Dictionary<Transform, Vector3>();
        Transform pelvis = transform.GetChild(1);
        originalPositions.Add(transform, transform.position);
        originalRotations.Add(transform, GetVectorWithNegativeValue(transform.localEulerAngles));
        originalPositions.Add(pelvis, pelvis.position);
        originalRotations.Add(pelvis, GetVectorWithNegativeValue(pelvis.localEulerAngles));
        getAllChildOriginalTransform(pelvis);
    }

    private void getAllChildOriginalTransform(Transform current)
    {
        if (current.childCount > 0)
        {
            foreach (Transform child in current)
            {
                originalPositions.Add(child, child.position);
                originalRotations.Add(child, GetVectorWithNegativeValue(child.localEulerAngles));
                getAllChildOriginalTransform(child);
            }
        }
    }

    }

    public void Wave()
    {
        StartCoroutine(Wave2());
    }

    private IEnumerator Wave2()
    {
        Transform upperLeftArm = GetUpperLeftArm();
        Transform lowerLeftArm = GetLowerLeftArm();
        Transform spine1 = GetSpine1();

        Vector3 spineAngle = new Vector3(-5.254f, 0, -14.135f);
        Vector3 upperArmAngle = new Vector3(-2, 86.9f, -34.8f);
        Vector3 lowerArmAngle = new Vector3(-4.785f, 0, -34.2f);
        
        Dictionary<Transform, Vector3> rotating = new Dictionary<Transform, Vector3>();
        rotating[upperLeftArm] = upperArmAngle;
        rotating[lowerLeftArm] = lowerArmAngle;
        rotating[spine1] = spineAngle;
        Debug.Log(upperArmAngle);
        StartCoroutine(Rotate(rotating, 5));
        
        int frame = 30;
        for (int i = 0; i < frame; i++)
        {
            GetLowerLeftArm().localEulerAngles = new Vector3(-4.785f, 0, Mathf.PingPong(Time.time * 60, 20.8f) - 55);
            yield return 0;
        }
        yield return new WaitForSeconds(0.5f);

        Reset(8);
        yield return 0;
    }

    public void Reset(int frame)
    {
        Queue<Transform> queue = new Queue<Transform>();
        Dictionary<Transform, Vector3> differecePosition = new Dictionary<Transform, Vector3>();
        Dictionary<Transform, Vector3> differeceRotation = new Dictionary<Transform, Vector3>();
        Transform pelvis = transform.GetChild(1);
        queue.Enqueue(pelvis);
        while (queue.Count != 0)
        {
            Transform current = queue.Dequeue();
            if (current.position != originalPositions[current])
            {
                Debug.Log(current.name + " different position");
                Debug.Log(current.position);
                Debug.Log(originalPositions[current]);
                differecePosition[current] = originalPositions[current];
            }

            if (current.localEulerAngles != originalRotations[current])
            {
                Debug.Log(current.name + " different rotation");
                Debug.Log(current.localEulerAngles);
                Debug.Log(originalRotations[current]);
                differeceRotation[current] = originalRotations[current];
            }

            foreach (Transform child in current)
            {
                queue.Enqueue(child);
            }
        }

        // check if need to reset whole object
        if (transform.position != originalPositions[transform])
        {
            Debug.Log(transform.name + " different position");
            Debug.Log(transform.position);
            Debug.Log(originalPositions[transform]);
            differecePosition[transform] = originalPositions[transform];
        }

        if (transform.localEulerAngles != originalRotations[transform])
        {
            Debug.Log(transform.name + " different rotation");
            Debug.Log(transform.localEulerAngles);
            Debug.Log(originalRotations[transform]);
            differeceRotation[transform] = originalRotations[transform];
        }
        //StartCoroutine(Move(differecePosition, 5));
        StartCoroutine(Rotate(differeceRotation, frame));
    }

    private IEnumerator Move(Dictionary<Transform, Vector3> transformsToFinalVectors, int frame)
    {
        List<Vector3> originalPosition = new List<Vector3>();

        // finalVectors will actually be the vectors difference
        int i = 0;
        foreach (Transform t in new List<Transform>(transformsToFinalVectors.Keys))
        {
            originalPosition.Add(GetVectorWithNegativeValue(t.position));
            transformsToFinalVectors[t] = transformsToFinalVectors[t] - originalPosition[i++];
        }

        for (i = 1; i <= frame; i++)
        {
            int j = 0;
            foreach (Transform t in new List<Transform>(transformsToFinalVectors.Keys))
            {
                t.position = originalPosition[j++] + transformsToFinalVectors[t] * i / frame;
            }
            yield return 0;
        }
    }

    private IEnumerator Rotate(Dictionary<Transform, Vector3> transformsToFinalVectors, int frame)
    {
        List<Vector3> originalAngles = new List<Vector3>();

        // finalVectors will actually be the vectors difference
        int i = 0;
        foreach (Transform t in new List<Transform>(transformsToFinalVectors.Keys))
        {
            originalAngles.Add(GetVectorWithNegativeValue(t.localEulerAngles));
            transformsToFinalVectors[t] = transformsToFinalVectors[t] - originalAngles[i++];
        }

        for (i = 1; i <= frame; i++)
        {
            int j = 0;
            foreach (Transform t in new List<Transform>(transformsToFinalVectors.Keys))
            {
                t.localEulerAngles = originalAngles[j++] + transformsToFinalVectors[t] * i / frame;
            }
            yield return 0;
        }
    }

    private Transform GetSpine1()
    {
        return transform.Find("Pelvis/Spine_01");
    }

    private Transform GetUpperLeftArm()
    {
        return GetSpine1().Find("Spine_02/Spine_03/Clavicle_L/Upperarm_L");
    }

    private Transform GetUpperRightArm()
    {
        return GetSpine1().Find("Spine_02/Spine_03/Clavicle_R/Upperarm_R");
    }

    private Transform GetLowerLeftArm()
    {
        return GetUpperLeftArm().Find("Lowerarm_L");
    }

    private Transform GetLowerRightArm()
    {
        return GetUpperRightArm().Find("Lowerarm_R");
    }

    private Transform GetLeftHand()
    {
        return GetLowerLeftArm().Find("Hand_L");
    }

    private Transform GetRightHand()
    {
        return GetLowerRightArm().Find("Hand_R");
    }

    private Vector3 GetVectorWithNegativeValue(Vector3 vector)
    {
        vector.x = (vector.x > 180) ? vector.x - 360 : vector.x;
        vector.y = (vector.y > 180) ? vector.y - 360 : vector.y;
        vector.z = (vector.z > 180) ? vector.z - 360 : vector.z;

        return vector;
    }
}
