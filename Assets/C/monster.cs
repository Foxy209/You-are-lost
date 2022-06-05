using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class monster : MonoBehaviour {

	public GameObject player;
	public AudioClip[] footsounds;
	public Transform eyes;
	public AudioSource growl;
	public GameObject deathCam;
	public Transform camPos;

	private UnityEngine.AI.NavMeshAgent nav;
	private AudioSource sound;
	private Animator anim;
	private string state = "idle";
	private bool alive = true;
	private float wait = 0f;
	private bool highAlert = false;
	private float alertness = 20f;

	// Use this for initialization
	void Start () 
	{
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
		sound = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		nav.speed = 1.1f;
		anim.speed = 1.2f;
	}

	public void footstep(int _num)
	{
		sound.clip = footsounds[_num];
		sound.Play();
	}

	//check if we can see the player//
	public void checkSight()
	{
		if(alive)
		{
			RaycastHit rayHit;
			if(Physics.Linecast(eyes.position,player.transform.position, out rayHit))
			{
				//print("hit "+rayHit.collider.gameObject.name);
				if(rayHit.collider.gameObject.name == "player")
				{
					if(state != "kill")
					{
						state = "chase";
						nav.speed = 2.2f;
						anim.speed = 2.5f;
						growl.pitch = 1.2f;
						growl.Play();
					}
				}
			}
		}
	}

	
	// Update is called once per frame
	void Update () 
	{
		//Debug.DrawLine(eyes.position,player.transform.position,Color.green);

		if(alive)
		{
			anim.SetFloat("velocity",nav.velocity.magnitude);

			//Idle//
			if(state == "idle")
			{
				//pick a random place to walk to//
				Vector3 randomPos = Random.insideUnitSphere*alertness;
				UnityEngine.AI.NavMeshHit navHit;
				UnityEngine.AI.NavMesh.SamplePosition(transform.position + randomPos, out navHit,20f,UnityEngine.AI.NavMesh.AllAreas);

				//go near the player//
				if(highAlert)
				{
					UnityEngine.AI.NavMesh.SamplePosition(player.transform.position + randomPos, out navHit,20f,UnityEngine.AI.NavMesh.AllAreas);
					//each time, lose awareness of player general position//
					alertness += 5f;

					if(alertness > 20f)
					{
						highAlert = false;
						nav.speed = 2.1f;
						anim.speed = 1.5f;
					}
				}


				nav.SetDestination(navHit.position);
				state = "walk";
			}
			//Walk//
			if(state == "walk")
			{
				if(nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
				{
					state = "search";
					wait = 0.5f;
				}
			}
			//Search//
			if(state == "search")
			{
				if(wait > 0f)
				{
					wait -= Time.deltaTime;
					transform.Rotate(0f,30f*Time.deltaTime,0f);
				}
				else
				{
					state = "idle";
				}
			}
            //Chase//
            if (state == "chase")
            {
                nav.destination = player.transform.position;

                if (player == false) ;
                state = "hunt";

                //lose sight of player//
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance > 20f)
                    




                {
                        
                        state = "hunt";
				}
				//kill the player//
				else if(nav.remainingDistance <= nav.stoppingDistance + 1f && !nav.pathPending)
				{
					if(player.GetComponent<player>().alive)
					{
						state = "kill";
						player.GetComponent<player>().alive = false;
						player.GetComponent<FirstPersonController>().enabled = false;
						deathCam.SetActive(true);
						deathCam.transform.position = Camera.main.transform.position;
						deathCam.transform.rotation = Camera.main.transform.rotation;
						Camera.main.gameObject.SetActive(false);
						growl.pitch = 0.7f;
						growl.Play();
						Invoke("reset",1f);
					}


				}
			}
			//Hunt//
			if(state == "hunt")
			{
				if(nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
				{
					state = "search";
					wait = 1f;
					highAlert = true;
					alertness = 3f;
					checkSight();
				}
			}
			//Kill//
			if(state == "kill")
			{
				deathCam.transform.position = Vector3.Slerp(deathCam.transform.position,camPos.position,10f*Time.deltaTime);
				deathCam.transform.rotation = Quaternion.Slerp(deathCam.transform.rotation,camPos.rotation,10f*Time.deltaTime);
				anim.speed = 1f;
				nav.SetDestination(deathCam.transform.position);
			}

			//nav.SetDestination(player.transform.position);
		}
	}

	//reset//
	void reset()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//die//
	public void death()
	{
		anim.SetTrigger("dead");
		anim.speed = 1f;
		alive = false;
		nav.Stop();
	}

}
