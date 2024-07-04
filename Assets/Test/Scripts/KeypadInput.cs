using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class KeypadInput : MonoBehaviour
{
    public ActionBasedController targetCont;

    private InputActionReference activateRef; // 검지 트리거 버튼

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        activateRef = targetCont.activateAction.reference;

        activateRef.action.performed += delegate (InputAction.CallbackContext context)
        {
            //contAnim.TriggerActivate(context.performed);
        };

    }
}
