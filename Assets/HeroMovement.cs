using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

    public float moveSpeed = 2.0f;

    bool left, right, up, down;
    Animator animator;

	// Use this for initialization
	void Start () {

        left = right = up = down = false;
        animator = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
        MoveCharacter();	
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
}
