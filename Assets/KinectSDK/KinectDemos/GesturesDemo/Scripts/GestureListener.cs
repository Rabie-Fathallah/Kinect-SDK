using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	public Text GestureInfo;
	
	private bool swipeLeft;
	private bool swipeRight;

	private bool riseRightHand;
	private bool tPose;
	private bool jump;

	
	public bool IsSwipeLeft()
	{
		if(swipeLeft)
		{
			swipeLeft = false;
			return true;
		}
		
		return false;
	}
	
	public bool IsSwipeRight()
	{
		if(swipeRight)
		{
			swipeRight = false;
			return true;
		}
		
		return false;
	}

    public bool IsTPose()
    {
        if (tPose)
        {
            tPose = false;
            return true;
        }

        return false;
    }

    public bool IsRiseRightHand()
    {
        if (riseRightHand)
        {
            riseRightHand = false;
            return true;
        }

        return false;
    }

    public bool IsJump()
    {
        if (jump)
        {
            jump = false;
            return true;
        }

        return false;
    }

    public void UserDetected(uint userId, int userIndex)
	{
		// detect these user specific gestures
		KinectManager manager = KinectManager.Instance;
		
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);

		if(GestureInfo != null)
		{
			GestureInfo.text = "Swipe left or right to change the slides. Tpose to Callibrate and Rise right hand to confirm.";
		}
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		if(GestureInfo != null)
		{
			GestureInfo.text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		// don't do anything here
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";
		if(GestureInfo != null)
		{
			GestureInfo.text = sGestureText;
		}
		
		if(gesture == KinectGestures.Gestures.SwipeLeft)
			swipeLeft = true;

		else if(gesture == KinectGestures.Gestures.SwipeRight)
			swipeRight = true;

        else if (gesture == KinectGestures.Gestures.RaiseRightHand)
            riseRightHand = true;

        else if (gesture == KinectGestures.Gestures.Tpose)
            tPose = true;

        else if (gesture == KinectGestures.Gestures.Jump)
            jump = true;

        return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		// don't do anything here, just reset the gesture state
		return true;
	}
	
}
