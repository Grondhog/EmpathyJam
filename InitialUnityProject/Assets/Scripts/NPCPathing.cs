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

  

    public NPCManager manager;//EWWWWW
	
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinations[0].position);
        i = (i + 1) % destinations.Length;
        prevRemainingDistance = agent.remainingDistance;

        agent.speed = Random.Range(7, 10);
	}
	
	
	void Update () {
        
		if(agent.remainingDistance <= agent.stoppingDistance )
        {
            if(destinations.Length > 0)
            {
                agent.SetDestination(destinations[i++].position);
                i = i % (destinations.Length);
            }
            
            
        }
        else if(agent.remainingDistance > prevRemainingDistance && prevRemainingDistance > 0 && agent.remainingDistance - prevRemainingDistance < 1)
        {//moves to next node if the current node is entirely blocked by the player. Gross Duplicated code
            agent.SetDestination(destinations[i++].position);
            i = i % (destinations.Length );
            
        }
        prevRemainingDistance = agent.remainingDistance;
        



        
    }
}
