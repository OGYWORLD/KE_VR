using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

// 컨트롤러 입력에 추가 액션을 하도록 만드는 컴포넌트
//[RequireComponent(typeof(ActionBasedController)]
public class XRCustomController : MonoBehaviour
{
    public ActionBasedController targetCont;
    private InputActionReference activateRef; // 검지 트리거 버튼
    private InputActionReference selectRef; // 중지 범퍼 버튼
    private InputActionReference joyStickRef; // 조이스틱

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
                    // 왼쪽 이동
                    contAnim.JoyStickActivate(context.performed, 3);
                }
                else
                {
                    // 오른쪽 이동
                    contAnim.JoyStickActivate(context.performed, 2);
                }

                if(transform.position.z > prePos.z)
                {
                    // 앞
                    contAnim.JoyStickActivate(context.performed, 0);
                }
                else
                {
                    // 뒤
                    contAnim.JoyStickActivate(context.performed, 1);
                }
                
                prePos = transform.position;
            };
        }
    }
}
