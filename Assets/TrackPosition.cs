using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TrackPosition : MonoBehaviour
{
    private Vector3 previousPosition;
    public float trackingFrequency;
    private float lastCheck = 0.0F;
    public string figure;
    private int logNumber;
    public bool trackingActive = false;

    void Start()
    {
        previousPosition = transform.position;
        figure = "Test";
        logNumber = 0;
        //InvokeRepeating(nameof(GetPosition), 0.1f, trackingFrequency);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            previousPosition = transform.position;
            logNumber++;
            trackingActive = true;

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            trackingActive = false;
        }

        if (trackingActive && (Time.time - lastCheck) >= trackingFrequency)
        {
            GetPosition();
            lastCheck = Time.time;
        }
    }

    void GetPosition()
    {
        string path = Application.dataPath + "/" + figure + "_log" + logNumber + ".csv";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }

        Vector3 deltaPosition = transform.position - previousPosition;
        Debug.Log("X= " + deltaPosition.x + "Y= " + deltaPosition.y + "Z= " + deltaPosition.z);
        string posData = deltaPosition.x.ToString() + "," + deltaPosition.y.ToString() + "," + deltaPosition.z.ToString() + "\n";
        File.AppendAllText(path, posData);
        previousPosition = transform.position;
    }

}
