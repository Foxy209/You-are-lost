using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class r : MonoBehaviour
{
    void FixedUpdate()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            gamepad.SetMotorSpeeds(100f, 100f);
        }

        //Vector2 move = gamepad.leftStick.ReadValue();
        // 'Move' code here
    }
}
