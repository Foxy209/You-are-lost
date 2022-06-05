using UnityEngine;
using System.Collections;

public class ScreamerFalse : MonoBehaviour {
	public GameObject monstr;


	void  OnTriggerStay ( Collider other  ){
		if(other.tag == "Player");
		monstr.active = false; 

	}
}
