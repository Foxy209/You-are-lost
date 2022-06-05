using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLS : MonoBehaviour
{

	public bool URL1 = false;
	public bool URL2 = false;
	public bool URL3 = false;
	public bool URL4 = false;
	public bool GP = false;



	public void Open() {


		if(URL1 == true) {
			Application.OpenURL("https://vk.com/foxy0");
		}
		if(URL2 == true) {
			Application.OpenURL("https://gamejolt.com/@Kordon545");
		}
		if (URL3 == true) {
			Application.OpenURL("https://vk.com/forestbloodjack");
		}
		if (URL4 == true) {
			Application.OpenURL("https://vk.com/kordi_shrams");
		}
		if (GP == true) {
			Application.OpenURL("https://play.google.com/store/apps/details?id=com.Sin2.fin3");
		}

	}

}