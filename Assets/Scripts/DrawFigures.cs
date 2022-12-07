using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrawFigures : MonoBehaviour
{

    [SerializeField] private GameObject activatorPrefab;
    [SerializeField] private GameObject guidePrefab;
    [SerializeField] private GameObject circleParent;
    [SerializeField] private GameObject[] triangleGuides;
    [SerializeField] private GameObject[] squareGuides;
    [SerializeField] List<GameObject> circleGuides = new List<GameObject>();
    [SerializeField] private Transform[] triangle;
    [SerializeField] private Transform[] square;
    [SerializeField] private CalculateAreas calc;
    [SerializeField] private HandDraw hd;
    [SerializeField] private int steps;
    [SerializeField] private float radius;
    [SerializeField] private Vector3 offset;
    public static Vector3[] trianglePointsInLine;
    public static Vector3[] squarePointsInLine;
    public static Vector3[] circlePointsInLine;
    public Vector3 positionToMoveTo;
    public Vector3 originalPos;
    [SerializeField] GameObject obj;

    private int index = 0;

    //private float n = 5;
    public LineRenderer lr;

    public enum Figure { Triangle, Square, Circle }

    public static Figure currentFigure;

    void Start()
    {

        originalPos = circleGuides[index].transform.position;
        positionToMoveTo = circleGuides[index].transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) DrawTriangle();

        if (Input.GetMouseButtonDown(1)) DrawSquare();

        if (Input.GetMouseButtonDown(2)) DrawCircle2();

            

        /*if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LerpPosition(circleGuides.Count + 1, positionToMoveTo, 1, obj));
        }*/


    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
    }
    
    public void SetUpCircle(List<GameObject> points)
    {
        lr.positionCount = points.Count;
    }


    public void DrawTriangle()
    {
        hd.ClearDrawing();
        DeactivateGuides();
        currentFigure = Figure.Triangle;
        ActivateGuides();
        SetUpLine(triangle);
        for (int i = 0; i < lr.positionCount; i++)
        {
            lr.SetPosition(i, triangle[i].position);
        }

        trianglePointsInLine = new Vector3[lr.positionCount];

        lr.GetPositions(trianglePointsInLine);

        calc.CalculateTriangleArea(trianglePointsInLine);
    }

    public void DrawSquare()
    {
        hd.ClearDrawing();
        DeactivateGuides();
        currentFigure = Figure.Square;
        ActivateGuides();
        SetUpLine(square);
        for (int i = 0; i < lr.positionCount; i++)
        {
            lr.SetPosition(i, square[i].position);
        }

        squarePointsInLine = new Vector3[lr.positionCount];

        lr.GetPositions(squarePointsInLine);

        calc.CalculateSquareArea(squarePointsInLine);
    }

    public void DrawCircle(int steps, float radius)
    {
        hd.ClearDrawing();
        DeactivateGuides();
        currentFigure = Figure.Circle;
        if (circleGuides != null)ActivateGuides();
        lr.positionCount = steps;

        for (int i = 0; i < steps; i++)
        {
            float circumferenceProgress = (float)i / (steps - 1);

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);
            float x = xScaled * radius;
            Debug.Log(x);
            float y = yScaled * radius;
            Vector3 currentPos = new Vector3(x, y, 0);

            lr.SetPosition(i, currentPos + offset);

            //if (i == 0)  InstantiateCircleActivator(currentPos);

            //if (i % n == 0) InstantiateCircleGuides(currentPos);
        }

        //circlePointsInLine = new Vector3[lr.positionCount];

        //lr.GetPositions(circlePointsInLine);
    }

    public void DrawCircle2()
    {
        hd.ClearDrawing();
        DeactivateGuides();
        currentFigure = Figure.Circle;
        if (circleGuides != null) ActivateGuides();
        SetUpCircle(circleGuides);

        for (int i = 0; i < lr.positionCount; i++)
        {
            lr.SetPosition(i, circleGuides[i].transform.position);
        }

        circlePointsInLine = new Vector3[lr.positionCount];

        lr.GetPositions(circlePointsInLine);
    }

    /*public void InstantiateCircleGuides(Vector3 spawnPos)
    {
        if (circleGuides.Count < steps / n) circleGuides.Add(Instantiate(guidePrefab, spawnPos + offset, Quaternion.identity));
    }

    public void InstantiateCircleActivator(Vector3 spawnPos)
    {
        if (circleGuides.Count < 1) circleGuides.Add(Instantiate(activatorPrefab, spawnPos + offset, Quaternion.identity));
    }*/

    public void ActivateGuides()
    {
        switch (currentFigure)
        {
            case Figure.Triangle:
                foreach (GameObject guide in triangleGuides) guide.SetActive(true);
                break;

            case Figure.Square:
                foreach (GameObject guide in squareGuides) guide.SetActive(true);
                break;

            case Figure.Circle:
                foreach (GameObject guide in circleGuides) guide.SetActive(true);
                break;
        }
    }

    public void DeactivateGuides()
    {
        switch (currentFigure)
        {
            case Figure.Triangle:
                foreach (GameObject guide in triangleGuides) guide.SetActive(false);
                break;

            case Figure.Square:
                foreach (GameObject guide in squareGuides) guide.SetActive(false);
                break;

            case Figure.Circle:
                foreach (GameObject guide in circleGuides) guide.SetActive(false);
                break;
        }
    }

    //Can be used to draw benchmark figures
    IEnumerator LerpPosition(int n, Vector3 targetPosition, float duration, GameObject obj)
    {
        if (n == 0) yield break;
        float time = 0;
        Vector3 startPosition = obj.transform.position;
        while (time <= duration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = targetPosition;
        index += 1; 
        if (index < circleGuides.Count)
        {
            positionToMoveTo = circleGuides[index].transform.position;           
        }
        else
        {
            positionToMoveTo = originalPos;
        }
        StartCoroutine(LerpPosition(n - 1, positionToMoveTo, duration, obj));
    }
}
