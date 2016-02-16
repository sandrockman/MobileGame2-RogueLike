using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    GameObject heroObj;
    bool enemyRight, enemyLeft, enemyUp, enemyDown;
    float enemySpeed;
    Animator enemyAnimator;

    // Use this for initialization
    void Start()
    {

        enemyDown = enemyRight = enemyUp = enemyLeft = false;
        enemyAnimator = GetComponent<Animator>();
        heroObj = GameObject.Find("Hero");
        enemySpeed = 1.0f;
        InvokeRepeating("Accelerate", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void OnCollisionEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "orb(Clone)")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Accelerate()
    {
        enemySpeed++;
    }

    void EnemyMove()
    {
        if (heroObj != null)
        {
            if (transform.position.y > heroObj.transform.position.y) //is enemy above player
            {
                enemyAnimator.SetBool("EnemyDown", true);
                enemyAnimator.SetBool("EnemyUp", false);
                enemyAnimator.SetBool("EnemyLeft", false);
                enemyAnimator.SetBool("EnemyRight", false);

                enemyDown = true;
                enemyUp = enemyLeft = enemyRight = false;

                transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
            }
            else //enemy is below player
            {
                enemyAnimator.SetBool("EnemyDown", false);
                enemyAnimator.SetBool("EnemyUp", true);
                enemyAnimator.SetBool("EnemyLeft", false);
                enemyAnimator.SetBool("EnemyRight", false);

                enemyUp = true;
                enemyDown = enemyLeft = enemyRight = false;

                transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
            }

            if (transform.position.x < heroObj.transform.position.x) //is enemy left of player
            {
                enemyAnimator.SetBool("EnemyDown", false);
                enemyAnimator.SetBool("EnemyUp", false);
                enemyAnimator.SetBool("EnemyLeft", false);
                enemyAnimator.SetBool("EnemyRight", true);

                enemyRight = true;
                enemyUp = enemyLeft = enemyDown = false;

                transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
            }
            else
            {
                enemyAnimator.SetBool("EnemyDown", false);
                enemyAnimator.SetBool("EnemyUp", false);
                enemyAnimator.SetBool("EnemyLeft", true);
                enemyAnimator.SetBool("EnemyRight", false);

                enemyLeft = true;
                enemyDown = enemyLeft = enemyUp = false;

                transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
            }


        }
    }
}