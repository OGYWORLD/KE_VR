using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ShootLancher : MonoBehaviour
{
    public ActionBasedController targetCont;
    private InputActionReference activateRef; // 검지 트리거 버튼

    public GameObject bullet;
    public Transform shootTrans;

    public List<GameObject> pool = new List<GameObject>();
    private int bulletNum = 10;
    private int index = 0;

    IEnumerator Start()
    {
        for(int i = 0; i < bulletNum; i++)
        {
            GameObject obj = Instantiate(bullet, shootTrans.position, Quaternion.identity);
            obj.SetActive(false);
            pool.Add(obj);
        }

        yield return new WaitForEndOfFrame();

        activateRef = targetCont.activateAction.reference;

        // Trigger
        activateRef.action.performed += delegate (InputAction.CallbackContext context)
        {
            pool[index].transform.position = shootTrans.position;
            pool[index].SetActive(true);
            index++;

            if(index >= bulletNum)
            {
                index = 0;
            }

        };

    }
}
