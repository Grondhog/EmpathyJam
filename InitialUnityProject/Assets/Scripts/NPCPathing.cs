using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NPCPathing : MonoBehaviour {

    NavMeshAgent agent;

    public Transform[] destinations;

    private int i = 0;
    private float prevRemainingDistance;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinations[0].position);
        i = (i + 1) % destinations.Length;
        prevRemainingDistance = agent.remainingDistance;
	}
	
	// Update is called once per frame
	void Update () {
        // Debug.Log(agent.remainingDistance + ", " + agent.stoppingDistance);
        Debug.Log(agent.remainingDistance + ", " + prevRemainingDistance);
		if(agent.remainingDistance <= agent.stoppingDistance )
        {
            agent.SetDestination(destinations[i++].position);
            i = i % (destinations.Length );
            
        }
        else if(agent.remainingDistance > prevRemainingDistance && prevRemainingDistance > 0 && agent.remainingDistance - prevRemainingDistance < 1)
        {
            agent.SetDestination(destinations[i++].position);
            i = i % (destinations.Length );
            
        }
        Debug.Log(i);
        prevRemainingDistance = agent.remainingDistance;

    }
}
