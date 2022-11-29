using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateAreas : MonoBehaviour
{
    private float triangleA;
    private float triangleBase;
    private float triangleHeight;
    private float squareA;
    private float squareSide;

    public void CalculateTriangleArea(Vector3[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            float current = points[i].y;
            if (triangleHeight < current) triangleHeight = current;
        }

        for (int i = 0; i < points.Length; i++)
        {
            float current = points[i].x;
            if (triangleBase < current) triangleBase = current;
        }

        triangleA = 0.5f * ( triangleBase + triangleBase) * triangleHeight;
        //Debug.Log(triangleA);
    }

    public void CalculateSquareArea(Vector3[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            float current = points[i].y;
            if (current > 0) squareSide = current;            
        }

        squareA = Mathf.Pow(squareSide, 2);
        //Debug.Log(squareA);
    }
}
