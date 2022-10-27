using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TrackPosition : MonoBehaviour
{
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
        InvokeRepeating(nameof(GetPosition), 0.1f, 0.25f);
    }

    void Update()
    {

    }

    void GetPosition()
    {
        string path = Application.dataPath + "/Log.txt";
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
