using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class KeyPadLock : MonoBehaviour
{
    public string code = "860"; //correct code for our lock
    private string enterCode = "";

    // Start is called before the first frame update
    public void AddDigit(string digit)
    {
        if (enterCode.Length < code.Length) 
        {
            enterCode += digit;
            Debug.Log("Current code" + enterCode);
        }
    }

    public void CheckCode()
    {
        if (enterCode == code)
        {
            Debug.Log("Correct code entered!");
        }
        else
        {
            Debug.Log("Wrong code!");
            ClearCode();
        }
    }

    public void ClearCode()
    {
        enterCode = "";
        Debug.Log("Screen is cleared.");
    }
}
