using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRTest : MonoBehaviour
{
    public void Print(string message) => print(message);

    public void FirstSelectEnterEvent(SelectEnterEventArgs args)
    {
        print($"{args.interactableObject.transform.name}" +
            $"는 first selected by {args.interactableObject.transform.parent.name} 에게 먼저 선택됨."
            );
    }
    public void LastSelectExitedEvent(SelectExitEventArgs args)
    {
        print($"{args.interactableObject.transform.name}" +
            $"는 first selected by {args.interactableObject.transform.parent.name} 에게 마지막으로 선택됨."
            );
    }

    public void SelectEnterEvent(SelectEnterEventArgs args)
    {
        print($"{args.interactableObject.transform.name}" +
            $"는 first selected by {args.interactableObject.transform.parent.name} 에게 선택됨"
            );
    }

    public void SelectExitedEvent(SelectExitEventArgs args)
    {
        print($"{args.interactableObject.transform.name}" +
            $"는 first selected by {args.interactableObject.transform.parent.name} 에게 선택 해제됨."
            );
    }

    public void ActivateEvent(BaseInteractionEventArgs args)
    {
        if(args.GetType() == typeof(ActivateEventArgs))
        {
            print("빵");
        }
        else if(args.GetType() == typeof(DeactivateEventArgs))
        {
            print("찰칵");
        }
        else
        {
            print("");
        }
    }
}
