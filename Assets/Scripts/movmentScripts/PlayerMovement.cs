using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool isFrozen = false;
    public float speed;
    private Rigidbody2D myRigidbody;
    public Vector3 change;
    private Animator animator;
    private static bool playerExists;
    public Vector2 lastMove;

    public string startPoint; 

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        lastMove = new Vector2(Input.GetAxisRaw("Horizontal"),(Input.GetAxisRaw("Vertical")));
        //Debug.Log(lastMove);
        if (isFrozen == false)
        {
            UpdateAnimationAndMove();
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "friendly")
        {
            myRigidbody.isKinematic = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "friendly")
        {
                myRigidbody.isKinematic = false;
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
        transform.position + change.normalized * speed * Time.deltaTime);
    }

    public void Freeze()
    {
        isFrozen = true;
    }

    public void UnFreeze()
    {
        isFrozen = false;
    }
}
