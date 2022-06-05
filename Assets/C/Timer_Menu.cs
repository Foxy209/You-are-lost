using UnityEngine;
using System.Collections;

public class Timer_Menu : MonoBehaviour {


	bool loadingStarted = false;
	float secondsLeft = 3;

	void Start()
	{
		StartCoroutine(DelayLoadLevel(3));
	}

	IEnumerator DelayLoadLevel(float seconds)
	{
		secondsLeft = seconds;
		loadingStarted = true;
		do
		{
			yield return new WaitForSeconds(1);
		} while (--secondsLeft > 0);

		Application.LoadLevel("Forest");
	}


}