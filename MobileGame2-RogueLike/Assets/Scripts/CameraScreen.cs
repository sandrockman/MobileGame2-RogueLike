using UnityEngine;
using System.Collections;
/// <summary>
/// Goal for this script is to allow the camera to pan over the level, controlled via swiping.
/// </summary>
public class CameraScreen : MonoBehaviour {

    public float perspectiveZoomSpeed = 0.5f; //how fast to zoom a perspective camera
    public float orthographicZoomSpeed = 0.5f; // how fast to zoom an orthographic camera

    float hMovement = 0f;
    float vMovement = 0f;
    float cameraMoveSpeed = 0.01f;
    float cameraMove = 0.01f;
    Camera myCamera;

    bool isOrthographic = false;

	// Use this for initialization
	void Start () {
        myCamera = GetComponent<Camera>();

        if (myCamera.orthographic)
        {
            cameraMoveSpeed = cameraMove * GetComponent<Camera>().orthographicSize;
            isOrthographic = true;
        }
        else//perspective camera
        {
            cameraMoveSpeed = cameraMove * GetComponent<Camera>().fieldOfView;
        }

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(hMovement, vMovement, 0);
        /*
        //if there are two touches on the device
        if(Input.touchCount == 2)
        {
            //store both touches
            Touch begin = Input.GetTouch(0);
            Touch end = Input.GetTouch(1);

            //find the position in the previous frame for each touch
            Vector2 beginPreviousPosition = begin.position - begin.deltaPosition;
            Vector2 endPreviousPosition = end.position - end.deltaPosition;

            //find the magnitude of the vector between touches in each frame
            float prevTouchDeltaMag = (beginPreviousPosition - endPreviousPosition).magnitude;
            float TouchDeltaMag = (begin.position - end.position).magnitude;

            //find the difference in the distances between each frame
            float deltaMagnitudeDifference = prevTouchDeltaMag - TouchDeltaMag;

            //if the camera is orthographic
            if(isOrthographic)
            {
                //change the orthographic size based on the distance between the touches
                myCamera.orthographicSize += deltaMagnitudeDifference * cameraMoveSpeed;

                //make sure the orthographic size never drops below zero
                myCamera.orthographicSize = Mathf.Max(myCamera.orthographicSize, 0.1f);

                //Update our speed
                cameraMoveSpeed = cameraMove * myCamera.orthographicSize;
            }
            else
            {
                //Change the field of view (FOV) based change distance
                myCamera.fieldOfView += deltaMagnitudeDifference * perspectiveZoomSpeed;

                myCamera.fieldOfView = Mathf.Clamp(myCamera.fieldOfView, 0.1f, 179.9f);

                cameraMoveSpeed = cameraMove * myCamera.fieldOfView;
            }
        }//*/

        //Move the camera via acceleration
        float tempX = (float)System.Math.Round(Input.acceleration.x, 2);
        float tempY = (float)System.Math.Round(Input.acceleration.y, 2);

        if((tempX > 0.02f || tempX < -0.02f) || (tempY > 0.02f || tempY < -0.02f))
        {
            transform.Translate(tempX * cameraMoveSpeed, tempY * cameraMoveSpeed, 0f);
            Debug.Log("MOVING: hMove " + (tempX * cameraMoveSpeed)
                + ", vMove " + (tempY > 0.02f || tempY < -0.02f)
                + "\nCAMERA MOVE SPEED " + cameraMoveSpeed
                + "\nAccelX " + Input.acceleration.x + " AccelY " + Input.acceleration.y);
        }
    }
}
