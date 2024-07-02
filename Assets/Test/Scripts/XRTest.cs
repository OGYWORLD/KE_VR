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
            $"�� first selected by {args.interactableObject.transform.parent.name} ���� ���� ���õ�."
            );
    }
    public void LastSelectExitedEvent(SelectExitEventArgs args)
    {
        print($"{args.interactableObject.transform.name}" +
            $"�� first selected by {args.interactableObject.transform.parent.name} ���� ���������� ���õ�."
            );
    }

    public void SelectEnterEvent(SelectEnterEventArgs args)
    {
        print($"{args.interactableObject.transform.name}" +
            $"�� first selected by {args.interactableObject.transform.parent.name} ���� ���õ�"
            );
    }

    public void SelectExitedEvent(SelectExitEventArgs args)
    {
        print($"{args.interactableObject.transform.name}" +
            $"�� first selected by {args.interactableObject.transform.parent.name} ���� ���� ������."
            );
    }

    public void ActivateEvent(BaseInteractionEventArgs args)
    {
        if(args.GetType() == typeof(ActivateEventArgs))
        {
            print("��");
        }
        else if(args.GetType() == typeof(DeactivateEventArgs))
        {
            print("��Ĭ");
        }
        else
        {
            print("");
        }
    }
}
