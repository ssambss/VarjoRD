using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDraw : MonoBehaviour
{
    public Vector3 positionToMoveTo;
    private Vector3 originalPos;
    private List<Vector3> points = new List<Vector3>();
    [SerializeField] private CalculateAreas calc;

    private int index = 0;

    public LineRenderer lr;

    public void SetUpLine(List<Vector3> points)
    {
        lr.positionCount = points.Count;
    }

    void Start()
    {
        originalPos = transform.position;
        positionToMoveTo = points[index];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetUpLine(points);
            for (int i = 0; i < lr.positionCount; i++)
            {
                lr.SetPosition(i, points[i]);
            }

            Vector3[] trianglePointsInLine;
            trianglePointsInLine = new Vector3[lr.positionCount];

            lr.GetPositions(trianglePointsInLine);

            calc.CalculateTriangleArea(trianglePointsInLine);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SetUpLine(points);
            for (int i = 0; i < lr.positionCount; i++)
            {
                lr.SetPosition(i, points[i]);
            }

            Vector3[] squarePointsInLine;
            squarePointsInLine = new Vector3[lr.positionCount];

            lr.GetPositions(squarePointsInLine);

            calc.CalculateSquareArea(squarePointsInLine);
        }
    }
}
