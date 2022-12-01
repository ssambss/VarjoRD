using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDraw : MonoBehaviour
{
    public Vector3 positionToMoveTo;
    private Vector3 previousPos;
    public GameObject drawObject;
    private List<Vector3> points = new List<Vector3>();

    private int index = 0;

    public LineRenderer lr;

    private void Update()
    {
        
        //if (GetHandData2.trackingActive) Draw();

        if (Input.GetKey(KeyCode.A) && GetHandData2.trackingActive)
        {
            drawObject.transform.Translate(-1 * Time.deltaTime, 0, 0);
            points.Add(drawObject.transform.position);
            lr.positionCount = points.Count;
            lr.SetPosition(index, points[index]);
            index++;
            Debug.Log(points.Count);
            
        }

        if (Input.GetKey(KeyCode.S) && GetHandData2.trackingActive)
        {
            drawObject.transform.Translate(0, -1 * Time.deltaTime, 0);
            points.Add(drawObject.transform.position);
            lr.positionCount = points.Count;
            lr.SetPosition(index, points[index]);
            index++;
            Debug.Log(points.Count);
            
        }
        if (Input.GetKey(KeyCode.D) && GetHandData2.trackingActive)
        {
            drawObject.transform.Translate(1 * Time.deltaTime, 0, 0);
            points.Add(drawObject.transform.position);
            lr.positionCount = points.Count;
            lr.SetPosition(index, points[index]);
            index++;
            Debug.Log(points.Count);
            
        }
        if (Input.GetKey(KeyCode.W) && GetHandData2.trackingActive)
        {
            drawObject.transform.Translate(0, 1 * Time.deltaTime, 0);
            points.Add(drawObject.transform.position);
            lr.positionCount = points.Count;
            lr.SetPosition(index, points[index]);
            index++;
            Debug.Log(points.Count);          
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ClearDrawing();
        }
        //Debug.Log(points.Count);
    }

    public void Draw()
    {
        points.Add(GetHandData2.fingerPos);
        lr.positionCount = points.Count;
        lr.SetPosition(index, points[index]);
        index++;
    }

    public void ClearDrawing()
    {
        points.Clear(); 
        index = 0;
        lr.positionCount = points.Count;
    }
}
