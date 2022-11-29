using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetHandData2.trackingActive = !GetHandData2.trackingActive; Debug.Log("Activated");
    }
}
