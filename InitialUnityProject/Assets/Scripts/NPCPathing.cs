using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NPCPathing : MonoBehaviour {

    NavMeshAgent agent;

    public Transform[] destinations;

    private int i = 0;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinations[0].position);
        i = (i + 1) % destinations.Length;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(i);
        Debug.Log(agent.remainingDistance + ", " + agent.stoppingDistance);
		if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(destinations[i++].position);
            i = i % destinations.Length;
        }
	}
}
