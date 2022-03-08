using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject dubs;
    public Transform target;
    public bool needBadge;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        if (!needBadge || collider.name.Equals("HuskyCard"))
        {
            Debug.Log("Collide with husky card");
            player.GetComponent<NavMeshAgent>().Warp(target.position);
            dubs.GetComponent<NavMeshAgent>().Warp(target.position);
        }
    }
}
