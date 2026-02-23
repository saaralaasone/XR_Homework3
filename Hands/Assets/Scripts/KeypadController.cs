using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    public string code = "860"; //correct code for our lock
    private string enterCode = "";

    public DoorOpener door;
    // Start is called before the first frame update
    public void AddDigit(string digit)
    {
        if (enterCode.Length < code.Length) 
        {
            enterCode += digit;
            Debug.Log("Current code" + enterCode);
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
    }
}
