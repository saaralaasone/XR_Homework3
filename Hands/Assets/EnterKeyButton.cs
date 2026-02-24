using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnterKeyButton : MonoBehaviour
{
    public KeypadController controller;
    private XRBaseInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnPressed);
    }

    private void OnPressed(BaseInteractionEventArgs args)
    {
        controller.EnterCode();
    }
}
