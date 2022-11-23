using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TrackPosition : MonoBehaviour
{
    public float trackingFrequency;
    private float lastCheck = 0.0F;
    public string figure;
    private int logNumber;
    public bool trackingActive = false;

    void Start()
    {
        figure = "Test";
        logNumber = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

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


        Debug.Log("X= " + transform.position.x + "Y= " + transform.position.y + "Z= " + transform.position.z);
        string posData = transform.position.x.ToString() + "," + transform.position.y.ToString() + "," + transform.position.z.ToString() + "\n";
        File.AppendAllText(path, posData);

    }

}
