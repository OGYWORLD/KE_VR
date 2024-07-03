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

    public void JoyStickActivate(bool isPush, float x, float y)
    {
        if(y == -1f)
        {
            joyStick.transform.rotation = Quaternion.Euler(-20f, 0f, 0f);
        }
        if(y == 1f)
        {
            joyStick.transform.rotation = Quaternion.Euler(20f, 0f, 0f);
        }
        if(x == -1f)
        {
            joyStick.transform.rotation = Quaternion.Euler(0f, 0f, 20f);
        }
        if(x == 1f)
        {
            joyStick.transform.rotation = Quaternion.Euler(0f, 0f, -20f);
        }
    }

    public void JoyStickInActive(InputAction.CallbackContext context)
    {
        joyStick.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}

