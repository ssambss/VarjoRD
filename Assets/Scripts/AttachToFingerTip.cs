using Leap.Unity.Attachments;
using UnityEngine;

public class AttachToFingerTip : MonoBehaviour
{
    //The Attachment Hand you want to attach the Cube to
    [SerializeField] AttachmentHand attachmentHand;

    //The Attachment Point you want to attach the Cube to
    [SerializeField] AttachmentPointFlags attachmentPoint = AttachmentPointFlags.IndexTip;

    //The Cube that we make
    private GameObject cube;

    private void Start()
    {
        //Make a basic cube
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Adjust the scale of the cube
        cube.transform.localScale *= 0.0032f;
    }

    private void Update()
    {
        //Get the attachment point behaviour of the desired finger and bone
        AttachmentPointBehaviour attachmentPointBehaviour = attachmentHand.GetBehaviourForPoint(attachmentPoint);

        //If the attachment point exists, make it the parent of the cube and ensure the cube is transformed correctly below it
        if (attachmentPointBehaviour != null)
        {
            cube.transform.parent = attachmentPointBehaviour.transform;
            cube.transform.localPosition = Vector3.zero;
            cube.transform.localRotation = Quaternion.identity;
            
        }
    }
}
