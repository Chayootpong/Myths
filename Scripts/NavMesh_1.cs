using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh_1 : MonoBehaviour
{

    public Transform[] pads;
    public static int numPad;
    NavMeshAgent agent;
    public static float speed;
    float distance;

    // Use this for initialization
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        numPad = 0;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(transform.position, pads[99].position);

        agent.speed = 5;

        if (numPad > 99)
        {
            numPad = 99 - (numPad - 99);
            agent.SetDestination(pads[99].position);
        }

        else
        {
            agent.SetDestination(pads[numPad].position);
        }

        if (distance < 1)
        {
            StartCoroutine(WaitForReverse());
        }

    }

    IEnumerator WaitForReverse()
    {
        yield return new WaitForSeconds(1);
        agent.SetDestination(pads[numPad].position);
    }

}