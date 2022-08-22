using UnityEngine;

public class FPG : MonoBehaviour
{
    public float speedMove;
	public float jumpPower;

	private float graviryForce;
	private Vector3 moveVector;

	private CharacterController ch_controller;

	public Joystick joy;

	public Transform cameraTransform;

	public float camerasENSA;
	public float moveInputDeadZone;

	private int rightFinger;
	private float halfScreenWight;
	
	private Vector2 lookInput;
	private float cameraPitch;

	public Transform player;

	private void Start()
	{
		ch_controller = GetComponent<CharacterController>();
		rightFinger = -1;
		halfScreenWight = Screen.width / 2;
		moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);
		
	}

	private void GetTouchInput()
	{
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch t = Input.GetTouch(i);
			switch(t.phase)
			{
				case TouchPhase.Began :
					if (t.position.x > halfScreenWight && rightFinger == -1)
					{
						rightFinger = t.fingerId;
					}
					break;
				case TouchPhase.Ended:
				case TouchPhase.Canceled:
					if(t.fingerId == rightFinger)
					{
						rightFinger = -1;
					}
					break;
				case TouchPhase.Moved:
					if (t.fingerId == rightFinger)
					{
						lookInput = t.deltaPosition * camerasENSA * Time.deltaTime;
					}
					break;
				case TouchPhase.Stationary:
					if (t.fingerId == rightFinger)
					{
						lookInput = Vector2.zero;
						
					}
					break;
			}
		}
	}

	private void LookAround()
	{
		cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
		cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
		transform.Rotate(transform.up, lookInput.x);
	}

	private void MovePlayer()
	{
		moveVector = Vector3.zero;
		moveVector.x = joy.Horizontal;
		moveVector.z = joy.Vertical;
		moveVector.y = graviryForce;
		moveVector = transform.right * moveVector.x + transform.forward * moveVector.z + transform.up * moveVector.y;
		ch_controller.Move(moveVector * speedMove * Time.deltaTime);
	}

	private void GamingGravity()
	{
		if (!ch_controller.isGrounded)
		{
			graviryForce -= 10f * Time.deltaTime;
		}
		else
		{
			graviryForce = -1f;
		}
	}

	private void OnClickJump()
	{
		if (ch_controller.isGrounded)
			graviryForce = jumpPower;
	}
}

