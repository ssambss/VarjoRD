using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class SliderControl : MonoBehaviour
{
    [SerializeField] private InteractionSlider slider2D;
    [SerializeField] private InteractionSlider horizontalSlider;

    public void Horizontal2DSlide()
    {
        transform.position = new Vector3(slider2D.HorizontalSliderValue, transform.position.y, transform.position.z);

    }

    public void Vertical2DSlide()
    {
        transform.position = new Vector3(transform.position.x, slider2D.VerticalSliderValue, transform.position.z);
    }

    public void HorizontalSlide()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, horizontalSlider.HorizontalSliderValue);
    }
            

    private void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, slider);
    }
}
