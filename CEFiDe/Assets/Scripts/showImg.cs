using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showImg : MonoBehaviour
{
    Vector3 touchStart;
    private float zoomMin, zoomMax;
    float f = 1.0f;
    private void OnEnable()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = -(touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = -(touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;
            zoom(difference * 0.01f);

        }else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position -=  direction * 3;
        }
    }
    void zoom(float increment)
    {
        f = Mathf.Clamp(f - increment, 1.0f, 4.0f);
        transform.localScale = new Vector3(f, f, 0);
    }
}
