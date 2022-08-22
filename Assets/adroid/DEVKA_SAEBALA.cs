using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DEVKA_SAEBALA : MonoBehaviour
{
    public PlayerInput playerInput;
    public Transform cameraTransform;
    public CharacterController controller;
    public int playerSpeed = 10;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 input = playerInput.actions["move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
    
    
    public void OnMove(InputAction.CallbackContext context)
    {
        // Read value from control. The type depends on what type of controls.
        // the action is bound to.
        var value = context.ReadValue<Vector2>();
  

        Debug.Log(value);
        // IMPORTANT: The given InputValue is only valid for the duration of the callback.
        //            Storing the InputValue references somewhere and calling Get<T>()
        //            later does not work correctly.
    }
}
