using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    private void Update()
    {

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _moveFactorX = 0f;
            }
        }
    }
}
