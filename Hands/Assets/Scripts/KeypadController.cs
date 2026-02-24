using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    public string code = "860"; //correct code for our lock
    private string enterCode = "";

    public TMP_Text displayText;
    public DoorOpener door;

    public void AddDigit(string digit)
    {
        if (enterCode.Length < code.Length) 
        {
            enterCode += digit;
            Debug.Log("Current code: " + enterCode);
            displayText.text = enterCode;
        }
    }

    public void EnterCode()
    {
        if (enterCode == code)
        {
            Debug.Log("Correct code entered!");
            door.OpenDoor();
        }
        else
        {
            Debug.Log("Wrong code!");
        }

        enterCode = "";
        displayText.text = "";
    }
}
