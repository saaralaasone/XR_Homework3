using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // Start is called before the first frame update
    public float openAngle = 90f;
    public float openSpeed = 2f;
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    void Start()
    {
        closedRotation = transform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            StartCoroutine(Open());
        }
    }

    private IEnumerator Open()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            transform.localRotation = Quaternion.Slerp(closedRotation, openRotation, t);
            yield return null;
        }
    }
}
