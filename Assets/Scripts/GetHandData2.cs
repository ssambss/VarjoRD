using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine;
using System.IO;

public class GetHandData2 : MonoBehaviour
{
    public HandModelBase HandModelBase;
    public LeapServiceProvider LeapServiceProvider;

    public float trackingFrequency;
    private float lastCheck = 0.0F;
    public string figure;
    public string folderName;
    public static string drawType;
    public static int logNumber;
    public static bool trackingActive = false;
    public static Vector3 fingerPos;
    public GameObject testobj;


    void Start()
    {
        logNumber = 24;
    }


    public void Update()
    {
        figure = DrawFigures.currentFigure.ToString();
        folderName = DrawFigures.currentFigure.ToString() + "_Data";
        Hand _hand = HandModelBase.GetLeapHand();
        if (_hand != null)
        {
            OnUpdateHand(_hand);
            fingerPos = _hand.GetIndex().TipPosition;
        }
        //Debug.Log(fingerPos);

        /*if (Input.GetKeyDown(KeyCode.Space))
        {

            logNumber++;
            trackingActive = true;

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            trackingActive = false;
        }*/

        if (trackingActive && (Time.time - lastCheck) >= trackingFrequency)
        {
            switch (drawType)
            {
                case "hand":
                    GetPosition();
                    break;
                
                case "marker":
                    GetPositionMarker();
                    break;
            }
            //GetPos();
            lastCheck = Time.time;
        }
    }

    void OnUpdateHand(Hand _hand)
    {
        //Use _hand to Explicitly get the specified fingers from it
        Finger _thumb = _hand.GetThumb();
        Finger _index = _hand.GetIndex();
        Finger _middle = _hand.GetMiddle();
        Finger _ring = _hand.GetRing();
        Finger _pinky = _hand.GetPinky();

        //Explicitly get the fingers associated with the hand
        _thumb = Hands.GetThumb(_hand);
        _index = Hands.GetIndex(_hand);
        _middle = Hands.GetMiddle(_hand);
        _ring = Hands.GetRing(_hand);
        _pinky = Hands.GetPinky(_hand);

        //Use the FingerType Enum cast to an int to select a finger from the hand
        _thumb = _hand.Finger((int)Finger.FingerType.TYPE_THUMB);
        _index = _hand.Finger((int)Finger.FingerType.TYPE_INDEX);
        _middle = _hand.Finger((int)Finger.FingerType.TYPE_MIDDLE);
        _ring = _hand.Finger((int)Finger.FingerType.TYPE_RING);
        _pinky = _hand.Finger((int)Finger.FingerType.TYPE_PINKY);

        //Use an index to define what finger you want.
        _thumb = _hand.Fingers[0];
        _index = _hand.Fingers[1];
        _middle = _hand.Fingers[2];
        _ring = _hand.Fingers[3];
        _pinky = _hand.Fingers[4];
    }

    void GetPosition()
    {
        string path = Application.dataPath + "/" + "Data" + "/" + folderName + "/" + figure + "_log" + logNumber + ".csv";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "X" + "," + "Y" + "," + "Z" + "\n");
        }
     
        Debug.Log("X= " + fingerPos.x + "Y= " + fingerPos.y + "Z= " + fingerPos.z);
        string posData = fingerPos.x.ToString() + "," + fingerPos.y.ToString() + "," + fingerPos.z.ToString() + "\n";
        File.AppendAllText(path, posData);
    }

    void GetPositionMarker()
    {
        string path = Application.dataPath + "/" + "DataMarker" + "/" + folderName + "/" + figure + "_log" + logNumber + ".csv";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "X" + "," + "Y" + "," + "Z" + "\n");
        }

        Debug.Log("X= " + testobj.transform.position.x + "Y= " + testobj.transform.position.y + "Z= " + testobj.transform.position.z);
        string posData = testobj.transform.position.x.ToString() + "," + testobj.transform.position.y.ToString() + "," + testobj.transform.position.z.ToString() + "\n";
        File.AppendAllText(path, posData);
    }

    public void RecButton()
    {
        if (!trackingActive)
        {
            logNumber++;
            trackingActive = true;
        }

        else
        {
            trackingActive = false;
        }
    }
}
