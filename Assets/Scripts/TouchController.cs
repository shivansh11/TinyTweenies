using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    private bool tap, swipeUp, swipeDown;
    private bool isSwiped = false;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    void Update () {
        tap = swipeUp = swipeDown = false;

        if (Input.touches.Length > 0) {
            if (Input.touches[0].phase == TouchPhase.Began) {
                isDragging = true;
                startTouch = Input.touches[0].position;
            } else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                if (!isSwiped)
                    tap = true;

                isSwiped = false;
                Reset();
            }
        }

        swipeDelta = Vector2.zero;

        if (isDragging)
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;

        if (Mathf.Abs(swipeDelta.y) > 10)
        {
            isSwiped = true;

            if (swipeDelta.y < 0)
                swipeDown = true;
            else
                swipeUp = true;
            Reset();
        }
	}

    private void Reset() {
        isDragging = false;
        startTouch = swipeDelta = Vector2.zero;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool Tap { get { return tap; } }
}
