using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine;

public class GetHandData : MonoBehaviour
{
    public HandModelBase HandModelBase;
    public LeapServiceProvider LeapServiceProvider;

    public void Update()
    {
        Hand _hand = HandModelBase.GetLeapHand();
        OnUpdateHand(_hand);
        Vector3 fingerPos = _hand.GetMiddle().TipPosition;
        //Debug.Log(fingerPos);
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

    
}
