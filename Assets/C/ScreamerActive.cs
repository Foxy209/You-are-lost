using UnityEngine;
using System.Collections;

public class ScreamerActive : MonoBehaviour {
	public GameObject monstr;


	void  OnTriggerStay ( Collider other  ){
		if(other.tag == "Player");
		monstr.active = true;
	}
}