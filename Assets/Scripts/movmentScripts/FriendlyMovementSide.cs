using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyMovementSide : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidbody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    private bool hasWalkZone;

    public Collider2D walkZone;

    // Start is called before the first frame update
    public void OnObjectSpawn()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
            {
                case 0:

                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        Debug.Log("sidePassed");
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);

                    break;

                case 1:
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)

                    {
                        Debug.Log("sidePassed");

                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    break;
                
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }

        else
        {
            waitCounter -= Time.deltaTime;
            if (waitCounter < 0)
                myRigidbody.velocity = Vector2.zero;
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 2);
        isWalking = true;
        walkCounter = walkTime;
    }


    public void StopForConvo()
    {
        moveSpeed = 0;
        //isWalking = false;
    }

    public void LeaveConvo()
    {
        moveSpeed = 0.5f;
    }
}
