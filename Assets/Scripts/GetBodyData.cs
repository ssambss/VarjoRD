using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GetBodyData : MonoBehaviour
{
    public Transform userPos;

    public float trackingFrequency;
    private float lastCheck = 0.0F;

    private int logNumber;
    public bool trackingActive = false;

    public string folderName;

    // Start is called before the first frame update
    void Start()
    {
        logNumber = 0;
        folderName = "Inside_out";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            logNumber++;
            trackingActive = true;
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            trackingActive = false;
        }

        if (trackingActive && (Time.time - lastCheck) >= trackingFrequency)
        {
            GetPosition();
            lastCheck = Time.time;
        }

        if (Input.GetKey(KeyCode.F1))
        {
            folderName = "1_Beacon";
        }

        if (Input.GetKey(KeyCode.F2))
        {
            folderName = "2_Beacon";
        }

        if (Input.GetKey(KeyCode.F3))
        {
            folderName = "3_Beacon";
        }

        if (Input.GetKey(KeyCode.F4))
        {
            folderName = "Inside_out";
        }
    }

    void GetPosition()
    {
        string path = Application.dataPath + "/" + "Data" + "/" + folderName + "/" + folderName + "_log" + logNumber + ".csv";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "X" + "," + "Y" + "," + "Z" + "\n");
        }

        Debug.Log("X= " + userPos.position.x + "Y= " + userPos.position.y + "Z= " + userPos.position.z);
        string posData = userPos.position.x.ToString() + "," + userPos.position.y.ToString() + "," + userPos.position.z.ToString() + "\n";
        File.AppendAllText(path, posData);
    }
}