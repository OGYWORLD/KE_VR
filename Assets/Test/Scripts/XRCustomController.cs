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

    public DynamicMoveProvider dy;

    private ControllerAnimation contAnim;

    public Transform curTrans;

    private Vector3 prePos = new Vector3(0f, 0f, 0f);


    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        contAnim = GetComponentInChildren<ControllerAnimation>();

        activateRef = targetCont.activateAction.reference;
        selectRef = targetCont.selectAction.reference;
        joyStickRef = dy.leftHandMoveAction.reference;


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

            // JoyStick
            joyStickRef.action.performed += delegate (InputAction.CallbackContext context)
            {
                print(curTrans.position);
                if(transform.position.x > prePos.x)
                {
                    // ���� �̵�
                    contAnim.JoyStickActivate(context.performed, 3);
                }
                else
                {
                    // ������ �̵�
                    contAnim.JoyStickActivate(context.performed, 2);
                }

                if(transform.position.z > prePos.z)
                {
                    // ��
                    contAnim.JoyStickActivate(context.performed, 0);
                }
                else
                {
                    // ��
                    contAnim.JoyStickActivate(context.performed, 1);
                }
                
                prePos = transform.position;
            };
        }
    }
}
