using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Gradient gr, originalgr;
    private float timer = 2;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && timer > 2)
        {
            GetHandData2.trackingActive = !GetHandData2.trackingActive;
            if (GetHandData2.trackingActive)
            {
                AssignNewGradient(lr, gr);
                GetHandData2.logNumber++; 
                Debug.Log(GetHandData2.logNumber);
            } 
            if (!GetHandData2.trackingActive) AssignOriginalGradient(lr, originalgr); 
            timer = 0;

        }      
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void AssignNewGradient(LineRenderer lr, Gradient gr)
    {
        lr.colorGradient = gr;
    }

    public void AssignOriginalGradient(LineRenderer lr , Gradient originalgr)
    {
        lr.colorGradient = originalgr;
    }

    IEnumerator Wait()
    {
       yield return new WaitForSeconds(1);
    }
}
