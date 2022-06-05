using UnityEngine;
using System.Collections;

public class AI_Ray : MonoBehaviour {

    private Transform Player;
    private UnityEngine.AI.NavMeshAgent NMA;



	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        NMA = (UnityEngine.AI.NavMeshAgent)this.GetComponent("NavMeshAgent");
	}
	
	
	void Update () {
        NMA.SetDestination(Player.position);

    

	}
}
