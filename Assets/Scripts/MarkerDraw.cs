using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerDraw : MonoBehaviour
{
    public Vector3 positionToMoveTo;
    private Vector3 previousPos;
    public GameObject drawObject;
    private List<Vector3> points = new List<Vector3>();

    private int index = 0;

    public LineRenderer lr;

    private void Update()
    {

        if (GetHandData2.trackingActive) Draw();
    }

    public void Draw()
    {
        points.Add(drawObject.transform.position);
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
