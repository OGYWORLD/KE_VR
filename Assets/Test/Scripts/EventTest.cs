using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EventTest : MonoBehaviour
{
    private XRBaseControllerInteractor interactor;
    private int count = 0;

    private void Awake()
    {
        interactor = GetComponent<XRBaseControllerInteractor>();
        interactor.selectEntered.AddListener(
            (args) => {
                XREventCall(args, count++);
            }
            );

    }

    public void XREventCall(BaseInteractionEventArgs args, int count)
    {
        print($"{args.interactorObject.transform.name} called {count} times.");
    }


}
