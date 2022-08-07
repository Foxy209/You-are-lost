using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_sound : MonoBehaviour
{
	public GameObject monstr;
	public GameObject monstrw;



	void OnTriggerStay(Collider other)
	{
		if (other.tag == "restart") ;
		monstr.active = true;
		Destroy(monstrw);

	}
	}
	