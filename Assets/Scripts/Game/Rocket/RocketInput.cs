using System;
using UnityEngine;
using TouchPhase = UnityEngine.TouchPhase;

public class RocketInput : MonoBehaviour
{
    public RocketController rocketController; 
    public InputMethod inputMethod = InputMethod.KEYBOARD; // The input detection method 
    public int minSwipeDistance = 100; // Minimum distance to detect swipe
    
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    
    private void Update()
    {
        switch (inputMethod)
        {
            case InputMethod.SWIPE:
                DetectSwipe();
                break;
            case InputMethod.KEYBOARD:
                DetectKeyboard();
                break;
        }
    }

    private void DetectSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (Math.Abs(startTouchPosition.x - endTouchPosition.x) < minSwipeDistance) return;

            if (endTouchPosition.x < startTouchPosition.x)
            {
                rocketController.Move(RocketController.Direction.Left);
            }
            else if (endTouchPosition.x > startTouchPosition.x)
            {
                rocketController.Move(RocketController.Direction.Right);
            }
        }
    }

    private void DetectKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) rocketController.Move(RocketController.Direction.Left); 
        if (Input.GetKeyDown(KeyCode.RightArrow)) rocketController.Move(RocketController.Direction.Right); 
    }
    
    public enum InputMethod
    {
        KEYBOARD,
        SWIPE
    }
}
