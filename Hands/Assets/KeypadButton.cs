using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeypadButton : MonoBehaviour
{
    public string digit;
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
        controller.AddDigit(digit);
    }
    // Update is called once per frame
    // Update()
}
