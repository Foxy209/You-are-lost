using UnityEngine;
using System.Collections;

public class ScreamerDestroy : MonoBehaviour {
	public GameObject monstr;

	void  OnTriggerStay ( Collider other  ){
		if(other.tag == "Player");
		monstr.active = false; 
		Destroy(monstr); 
	}
}