using UnityEngine;
using System.Collections;

public class OneFingerGesture : MonoBehaviour {


    //keeps an eye on current object touched.
    public GameObject objectToMove = null;
    //vectors for swipe
    private Vector2 v2Previous;
    private Vector2 v2Current;
    //magnitude for swipe
    private float fTouchDelta;
    //
    public int iComfort;
	
	// Update is called once per frame
	void Update () {
	    if(Input.touchCount == 1)
        {
            //swipe
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                v2Previous = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                v2Current = Input.GetTouch(0).position;
                fTouchDelta = v2Current.magnitude - v2Previous.magnitude;

                if (Mathf.Abs(fTouchDelta) > iComfort)
                {
                    Debug.Log("Swipe");
                    if(fTouchDelta > 0)
                    {
                        Debug.Log("Left & Bottom.");
                        if (Mathf.Abs(v2Current.x - v2Previous.x) > Mathf.Abs(v2Current.y - v2Previous.y))
                        {
                            Debug.Log("Swipe from the left side.");
                        }
                        else
                        {
                            Debug.Log("Swipe from the bottom side.");
                        }
                    }
                    else
                    {
                        Debug.Log("Right & Top.");
                        if(Mathf.Abs(v2Current.x - v2Previous.x) > Mathf.Abs(v2Current.y - v2Previous.y))
                        {
                            Debug.Log("Swipe from the right side.");
                        }
                        else
                        {
                            Debug.Log("Swipe from the top side.");
                        }
                    }
                }
                else
                {
                    //single tap touch
                    if (Input.GetTouch(0).tapCount == 1)
                    {
                        Debug.Log("Single tap with one finger.");

                        RaycastHit hit;
                        Ray ray;
                        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                        if (Physics.Raycast(ray, out hit))
                        {
                            Debug.Log(hit.transform.name);
                            if (objectToMove != null && hit.transform.name != objectToMove.transform.name)
                            {
                                //stop the particle effect
                                objectToMove.GetComponent<ParticleSystem>().Stop();
                            }

                            objectToMove = GameObject.Find(hit.transform.name);
                            objectToMove.GetComponent<ParticleSystem>().Play();
                        }
                    }
                    //double tap touch
                    else if (Input.GetTouch(0).tapCount == 2)
                    {
                        if (objectToMove != null)
                        {
                            Vector3 pos = new Vector3(0, 0, 0);
                            pos.x = Input.GetTouch(0).position.x;
                            pos.y = Input.GetTouch(0).position.y;
                            pos.z = Mathf.Abs(Camera.main.transform.position.z - objectToMove.transform.position.z);

                            objectToMove.transform.position = Camera.main.ScreenToWorldPoint(pos);
                        }
                    }//end single and double tap touch
                }//end swipe or single/double touch if else
            }//end touch phase began/ended if else
        }//end if touch count ==1
	}//end Update()
}
