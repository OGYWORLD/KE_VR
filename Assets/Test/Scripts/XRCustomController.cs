using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

// ��Ʈ�ѷ� �Է¿� �߰� �׼��� �ϵ��� ����� ������Ʈ
//[RequireComponent(typeof(ActionBasedController)]
public class XRCustomController : MonoBehaviour
{
    public ActionBasedController targetCont;
    private InputActionReference activateRef; // ���� Ʈ���� ��ư
    private InputActionReference selectRef; // ���� ���� ��ư
    private InputActionReference joyStickRef; // ���̽�ƽ

    public DynamicMoveProvider move;

    private ControllerAnimation contAnim;


    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        contAnim = GetComponentInChildren<ControllerAnimation>();

        activateRef = targetCont.activateAction.reference;
        selectRef = targetCont.selectAction.reference;
        joyStickRef = move.leftHandMoveAction.reference;


        if(contAnim != null)
        {
            // Trigger
            activateRef.action.performed += delegate (InputAction.CallbackContext context)
            {
                contAnim.TriggerActivate(context.performed);
            };

            activateRef.action.canceled += delegate (InputAction.CallbackContext context)
            {
                contAnim.TriggerActivate(context.performed);
            };

            // Bumper
            selectRef.action.performed += contAnim.BumperActivate;
            selectRef.action.canceled += contAnim.BumperActivate;

            // JoyStick using
            joyStickRef.action.performed += delegate (InputAction.CallbackContext context)
            {
                contAnim.JoyStickActivate(context.performed, move.leftHandMoveAction.action.ReadValue<Vector2>().x, move.leftHandMoveAction.action.ReadValue<Vector2>().y);
            };

            // JoyStick Not using
            joyStickRef.action.canceled += contAnim.JoyStickInActive;
        }
    }
}
