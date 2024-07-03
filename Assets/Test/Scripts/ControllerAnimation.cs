using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAnimation : MonoBehaviour
{
    public Transform trigger;
    public Transform bumper;
    public Transform joyStick;

    public void TriggerActivate(bool isPush)
    {
        trigger.transform.Rotate(isPush ? -10 : 10, 0, 0);
    }

    public void BumperActivate(InputAction.CallbackContext context)
    {
        bumper.transform.Translate(context.performed ? 0.02f : -0.02f, 0, 0);
    }

    public void JoyStickActivate(bool isPush, int dir)
    {
        print(dir);
    }
}

