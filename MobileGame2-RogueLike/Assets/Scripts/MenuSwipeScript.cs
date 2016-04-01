using UnityEngine;
using System.Collections;

public class MenuSwipeScript : MonoBehaviour {

    enum SwipeMove { LEFT, RIGHT };
    enum MenuList { MENU, OPTIONS, CREDITS };

    public Canvas menuCanvas;
    public Canvas optionsCanvas;
    public Canvas creditsCanvas;

    public float scrollSpeed = 5;
    float screenWidth;
    bool canSwapMenus;
    MenuList currentMenu;

    private Vector2 v2Current;
    private Vector2 v2Previous;

    private float fTouchDelta;
    private bool menuUp;

    public float fComfortZone = 5f;

    // Use this for initialization
    void Start () {
        optionsCanvas.enabled = false;
        creditsCanvas.enabled = false;
        menuCanvas.enabled = true;
        currentMenu = MenuList.MENU;
        menuCanvas.sortingOrder = 1;
        screenWidth = Screen.width / 2;
        canSwapMenus = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                v2Previous = Input.GetTouch(0).position;
            }//end initial touch
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                v2Current = Input.GetTouch(0).position;
                Vector2 tempVector = v2Current - v2Previous;
                fTouchDelta = tempVector.magnitude;

                if (canSwapMenus &&
                    ((fTouchDelta > 0 && fTouchDelta > fComfortZone) ||
                    (fTouchDelta < 0 && -fTouchDelta > fComfortZone)))
                {
                    Debug.Log("Swipe");

                    if (tempVector.y >= tempVector.x)
                    {
                        //Debug.Log("From Right or Bottom.");
                        if (tempVector.y > -(tempVector.x))
                        {
                            Debug.Log("From Bottom.");
                        }
                        else
                        {
                            Debug.Log("From Right.");
                            ScrollScreen(SwipeMove.LEFT);
                        }
                    }
                    else
                    {
                        //Debug.Log("From Left or Top.");
                        if (tempVector.y > -(tempVector.x))
                        {
                            Debug.Log("From Left.");
                            ScrollScreen(SwipeMove.RIGHT);
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

    void ScrollScreen(SwipeMove dir)
    {
        switch(dir)
        {
            case SwipeMove.LEFT:
                switch(currentMenu)
                {
                    case MenuList.MENU:
                        break;
                    case MenuList.CREDITS:
                        break;
                    case MenuList.OPTIONS:
                        break;
                    default:
                        break;
                }
                break;
            case SwipeMove.RIGHT:
                switch (currentMenu)
                {
                    case MenuList.MENU:
                        break;
                    case MenuList.CREDITS:
                        break;
                    case MenuList.OPTIONS:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
}
