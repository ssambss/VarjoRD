using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Gradient gr, originalgr;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetHandData2.trackingActive = !GetHandData2.trackingActive; Debug.Log(other.gameObject.name);
            if (GetHandData2.trackingActive) AssignNewGradient(lr, gr);
            if (!GetHandData2.trackingActive) AssignOriginalGradient(lr, originalgr);

        }

        
    }

    public void AssignNewGradient(LineRenderer lr, Gradient gr)
    {
        lr.colorGradient = gr;
    }

    public void AssignOriginalGradient(LineRenderer lr , Gradient originalgr)
    {
        lr.colorGradient = originalgr;
    }

}
