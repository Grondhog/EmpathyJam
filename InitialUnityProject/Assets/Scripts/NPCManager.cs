using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    public List<List<Transform>> routes;

    public List<Transform> a;

    public List<Transform> b;
    
    public List<Transform> c;

    public GameObject[] NPCs;

    public int maxNPCs = 5;
    public int currentNPCCount = 0;

    public float timeBetweenSpawns = 2.0f;
    private float timeSinceLastSpawn = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;
		if(currentNPCCount < maxNPCs && timeSinceLastSpawn >= timeBetweenSpawns)
        {
            //Debug.Log("Spawn");
            SpawnNPC();
        }
    }

    private void SpawnNPC()
    {
        timeSinceLastSpawn = 0.0f;
        
        NPCPathing path = Instantiate(NPCs[Random.Range(0,3)], a[Random.Range(0, a.Count)].position, Quaternion.identity).GetComponent<NPCPathing>();
        int rand = Random.Range(1, 3);
        if(rand == 1)
        {
            path.destinations = a.ToArray();
        }
        else if(rand == 2)
        {
            path.destinations = b.ToArray();
        }
        else
        {
            path.destinations = c.ToArray();
        }
        currentNPCCount++;
        

    }

    public void KillNPC(GameObject _npc)
    {
        Debug.Log("Kill");
        currentNPCCount = currentNPCCount - 1;
        Debug.Log(this.currentNPCCount);
        Destroy(_npc);
        
        
    }
}
