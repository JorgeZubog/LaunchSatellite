using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingInteraction : MonoBehaviour
{
    public Vector3 delta;
    private Vector3 startPos, endPos;

    LaunchingForce launchingForce;

    public Orbitters orbitters;


    // Start is called before the first frame update
    void Start()
    {
        launchingForce = GetComponent<LaunchingForce>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(!launchingForce.isLaunched)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPos = Camera.main.ScreenToViewportPoint(touch.position);

                switch(touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = touchPos;
                        delta = startPos;
                        DrawDirection();
                        break;
                    case TouchPhase.Moved:
                        SetDelta(touchPos);
                        break;
                    case TouchPhase.Ended:
                        SetDelta(touchPos);
                        if(launchingForce.isLaunched == false)
                        {
                            launchingForce.Launch();
                            orbitters.ActiveGravity();
                        }else
                        {
                            launchingForce.Scan(delta);
                        }
                        DeleteDirection();
                        break;
                }
            }

            if(Input.GetMouseButtonDown(0))
            {
                Vector3 touchPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                startPos = touchPos;
                delta = startPos;
                Debug.Log("startPos"+startPos);
                DrawDirection();
            }else if(Input.GetMouseButton(0))
            {
                Vector3 touchPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                SetDelta(touchPos);
            }else if(Input.GetMouseButtonUp(0))
            {
                Vector3 touchPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                SetDelta(touchPos);
                if(launchingForce.isLaunched == false)
                {
                    launchingForce.Launch();
                    orbitters.ActiveGravity();
                }else
                {
                    launchingForce.Scan(delta);
                }
                DeleteDirection();
            }

        }
    }

    private void DrawDirection()
    {
        launchingForce.ActiveDirection(true);
    }

    private void DeleteDirection()
    {
        launchingForce.ActiveDirection(false);
    }

    private void SetDelta(Vector3 touchPos)
    {
        float cap = 0.5f;
        endPos = touchPos;
        delta = startPos - endPos;
        if(delta.magnitude > cap)
        {
            delta.Normalize();
            delta = delta * 0.5f; 
        }
        Debug.Log("delta" + delta);
    }
}
