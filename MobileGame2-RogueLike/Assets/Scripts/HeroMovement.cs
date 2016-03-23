using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

    public enum SwipeMove {LEFT, RIGHT, UP, DOWN};

    public float moveSpeed = 2.0f;

    public GameObject orb;
    float orbSpeed = 20f;

    bool left, right, up, down;
    Animator animator;

    private Vector2 vectorStart;
    private Vector2 vectorEnd;
    private float swipeMag;
    public float swipeComfortZone = 5f;

	// Use this for initialization
	void Start () {

        left = right = up = down = false;
        animator = GetComponent<Animator>();
        orb = Resources.Load("Orb") as GameObject;
	}
	
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            FireAway();
        }

        if (Input.touchCount <= 0)
            return;

        foreach(Touch next in Input.touches)
        {
            if(next.phase == TouchPhase.Began)
            {
                FireAway();
            }

            
        }//end foreach touch input

    }

	void FixedUpdate () {
        MoveCharacter();
        TouchMove();
	}

    void MoveCharacter()
    {
        //if right is true
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);

            left = up = down = false;
            right = true;

            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        //if left is true
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);

            right = up = down = false;
            left = true;

            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        //if up is true
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);

            left = right = down = false;
            up = true;

            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        //if down is true
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);

            left = up = right = false;
            down = true;

            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        }

    }

    void TouchMove()
    {
        if (Input.touchCount == 1)
        {
            //FireAway();
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                vectorStart = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                vectorEnd = Input.GetTouch(0).position;
                Vector2 tempVector = vectorEnd - vectorStart;
                swipeMag = tempVector.magnitude;

                if ((swipeMag > 0 && swipeMag > swipeComfortZone) ||
                    (swipeMag < 0 && -swipeMag > swipeComfortZone))
                {
                    //Debug.Log("movement swipe");
                    if (tempVector.y >= tempVector.x)
                    {
                        Debug.Log("From Right or Bottom.");
                        if (tempVector.y > -(tempVector.x))
                        {
                            Debug.Log("From Bottom.");
                            RunInSwipe(SwipeMove.UP);
                        }
                        else
                        {
                            Debug.Log("From Right.");
                            RunInSwipe(SwipeMove.LEFT);
                        }
                    }
                    else
                    {
                        Debug.Log("From Left or Top.");
                        if (tempVector.y > -(tempVector.x))
                        {
                            Debug.Log("From Left.");
                            RunInSwipe(SwipeMove.RIGHT);
                        }
                        else
                        {
                            Debug.Log("From Top.");
                            RunInSwipe(SwipeMove.DOWN);
                        }
                    }//end direction check 
                }//end move swipe check
            }//end swipe check
        }//end individual touch check
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
    }
    void FireAway()
    {
        GameObject orbInstance = Instantiate(orb, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D orbRigidbody = orbInstance.GetComponent<Rigidbody2D>();
        if (right)
        {
            orbRigidbody.velocity = new Vector2(orbSpeed, 0f);
        }
        if (left)
        {
            orbRigidbody.velocity = new Vector2(-orbSpeed, 0f);
        }
        if (up)
        {
            orbRigidbody.velocity = new Vector2(0f, orbSpeed);
        }
        if (down)
        {
            orbRigidbody.velocity = new Vector2(0f, -orbSpeed);
        }

        if (!left && !right && !up && !down)
        {
            orbRigidbody.velocity = new Vector2(0f, -orbSpeed);

        }
    }

    void RunInSwipe(SwipeMove moveDir)
    {
        switch(moveDir)
        {
            case SwipeMove.DOWN:
                animator.SetBool("Left", false);
                animator.SetBool("Right", false);
                animator.SetBool("Up", false);
                animator.SetBool("Down", true);

                left = up = right = false;
                down = true;

                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
                break;
            case SwipeMove.LEFT:
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);

                right = up = down = false;
                left = true;

                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                break;
            case SwipeMove.RIGHT:
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);

                left = up = down = false;
                right = true;

                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                break;
            case SwipeMove.UP:
                animator.SetBool("Left", false);
                animator.SetBool("Right", false);
                animator.SetBool("Up", true);
                animator.SetBool("Down", false);

                left = right = down = false;
                up = true;

                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                break;
            default:
                Debug.Log("Error in Swipe Run.");
                break;
        }
    }
    IEnumerator JesseOwens(SwipeMove moveDir)
    {
        
    }
}
