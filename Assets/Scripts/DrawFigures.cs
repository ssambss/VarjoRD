using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFigures : MonoBehaviour
{
    public Vector3 positionToMoveTo;
    private Vector3 originalPos;
    [SerializeField] private Transform[] triangle;
    [SerializeField] private Transform[] square;
    [SerializeField] private CalculateAreas calc;

    private int index = 0;

    public LineRenderer lr;

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
    }

    void Start()
    {
        originalPos = transform.position;
        positionToMoveTo = triangle[index].transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetUpLine(triangle);
            for (int i = 0; i < lr.positionCount; i++)
            {
                lr.SetPosition(i, triangle[i].position);
            }

            Vector3[] trianglePointsInLine;
            trianglePointsInLine = new Vector3[lr.positionCount];

            lr.GetPositions(trianglePointsInLine);

            calc.CalculateTriangleArea(trianglePointsInLine);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SetUpLine(square);
            for (int i = 0; i < lr.positionCount; i++)
            {
                lr.SetPosition(i, square[i].position);
            }

            Vector3[] squarePointsInLine;
            squarePointsInLine = new Vector3[lr.positionCount];

            lr.GetPositions(squarePointsInLine);

            calc.CalculateSquareArea(squarePointsInLine);
        }


        /*if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LerpPosition(points.Count + 1, positionToMoveTo, 1));
        }*/


    }
    /*
    IEnumerator LerpPosition(int n, Vector3 targetPosition, float duration)
    {
        if (n == 0) yield break;
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time <= duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        index += 1; 
        if (index < points.Count)
        {
            positionToMoveTo = points[index].transform.position;           
        }
        else
        {
            positionToMoveTo = originalPos;
        }
        StartCoroutine(LerpPosition(n - 1, positionToMoveTo, duration));
    }*/

}
