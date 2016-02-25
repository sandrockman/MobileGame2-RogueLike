using UnityEngine;
using System.Collections;

public class ZoomGesture : MonoBehaviour {


    public GameObject gameObjectToRotate;

    private Vector2 v2Current;
    private Vector2 v2Previous;
    private float fTouchDelta;

    public float fComfortZone;

    public Camera myCamera;
    public float zoom = 5f;
    public float minZoom = 10f;
    public float maxZoom = 70f;

    private float angle;
	
	// Update is called once per frame
	void Update () {
	    if(Input.touchCount == 2 && 
            Input.GetTouch(0).phase == TouchPhase.Moved && 
            Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            v2Current = Input.GetTouch(0).position - Input.GetTouch(1).position;
            v2Previous =
                (Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) -
                (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);
            fTouchDelta = v2Current.magnitude - v2Previous.magnitude;
            angle = Vector2.Angle(v2Previous, v2Current);

            if(angle > 0.1)
            {
                //Debug.Log("Rotation.");
                //Debug.Log(Vector3.Cross(v2Current, v2Previous));

                if(Vector3.Cross(v2Current, v2Previous).z < 0)
                {
                    //Debug.Log("Counter Clockwise.");
                    gameObjectToRotate.transform.Rotate(Vector3.up, angle * -1);
                }
                else
                {
                    //Debug.Log("Clockwise.");
                    gameObjectToRotate.transform.Rotate(Vector3.up, angle);
                }
            }
            if(Mathf.Abs(fTouchDelta) > fComfortZone)
            {
                //Debug.Log("zoom detected");
                if(fTouchDelta > 0)//Zoom In
                {
                    Debug.Log("Zoom In.");
                    myCamera.fieldOfView = 
                        Mathf.Clamp(
                            Mathf.Lerp(myCamera.fieldOfView, myCamera.fieldOfView - Mathf.Abs(fTouchDelta)*zoom, Time.deltaTime*zoom),
                            minZoom, maxZoom);
                }
                else //Zoom Out
                {
                    Debug.Log("Zoom Out.");
                    myCamera.fieldOfView =
                        Mathf.Clamp(
                            Mathf.Lerp(myCamera.fieldOfView, myCamera.fieldOfView + Mathf.Abs(fTouchDelta) * zoom, Time.deltaTime * zoom),
                            minZoom, maxZoom);
                }
            }

        }


    }
}
