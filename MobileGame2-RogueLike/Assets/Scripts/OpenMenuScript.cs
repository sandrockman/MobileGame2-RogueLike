using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenMenuScript : MonoBehaviour {

    public Canvas menu;

    private Vector2 v2Current;
    private Vector2 v2Previous;

    private float fTouchDelta;
    private bool menuUp;

    public float fComfortZone = 5f;

	void Start()
    {
        menuUp = false;
        menu.enabled = false;
    }

	// Update is called once per frame
	void Update () {
	    if(Input.touchCount == 1)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                v2Previous = Input.GetTouch(0).position;
            }//end initial touch
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                v2Current = Input.GetTouch(0).position;
                Vector2 tempVector = v2Current - v2Previous;
                fTouchDelta = tempVector.magnitude;

                if((fTouchDelta > 0 && fTouchDelta > fComfortZone)||
                    (fTouchDelta < 0 && -fTouchDelta > fComfortZone))
                {
                    Debug.Log("Swipe");

                    if (tempVector.y >= tempVector.x)
                    {
                        //Debug.Log("From Right or Bottom.");
                        if(tempVector.y > -(tempVector.x))
                        {
                            Debug.Log("From Bottom.");
                        }
                        else
                        {
                            Debug.Log("From Right.");
                            if(menuUp == false)
                            {
                                EnableMenu();
                            }
                            else
                            {
                                DisableMenu();
                            }
                        }
                    }
                    else
                    {
                        //Debug.Log("From Left or Top.");
                        if (tempVector.y > -(tempVector.x))
                        {
                            Debug.Log("From Left.");
                            if (menuUp == false)
                            {
                                EnableMenu();
                            }
                            else
                            {
                                DisableMenu();
                            }
                        }
                        else
                        {
                            Debug.Log("From Top.");
                        }
                    }

                }//end abs magnitude check
            }//end finish touch
        }//end touchCount == 1
	}//end Update()

    void EnableMenu()
    {
        menu.enabled = true;
        menuUp = true;
    }
    void DisableMenu()
    {
        menu.enabled = false;
        menuUp = false;
    }
}
