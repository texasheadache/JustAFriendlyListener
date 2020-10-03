using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyMovement : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint; 

    private Rigidbody2D myRigidbody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    [SerializeField] private float waitCounter;

    private int WalkDirection;

    private bool hasWalkZone; 

    public Collider2D walkZone;

    public bool isStationary = false;

    public bool hasPath = false;

    public List<Transform> wayPoints = new List<Transform>();

    private Transform destination; 


    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        if(destination == null)
        {
            SetDestination(); 
        }

        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true; 
        }
    }

    void SetDestination()
    {
        //destination = wayPoints[Random.Range(0,wayPoints.Count)];
        destination = wayPoints[0];
        wayPoints.Add(destination);
        wayPoints.RemoveAt(0);
    }


    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            if (hasPath == true)
            {
                float distance = Vector2.Distance(transform.position, destination.position);
                if (distance <= 0.5f)
                {
                    SetDestination();
                }
                else
                {
                    Vector2 move = (destination.position - transform.position);
                    move.Normalize();
                    myRigidbody.velocity = move * moveSpeed;
                }
            }


            else
            {


                walkCounter -= Time.deltaTime;

                switch (WalkDirection)
                {
                    case 0:

                        if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                        {
                            Debug.Log("passed");
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        myRigidbody.velocity = new Vector2(0, moveSpeed);

                        break;

                    case 1:
                        if (hasWalkZone && transform.position.x > maxWalkPoint.x)

                        {
                            Debug.Log("passed");

                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        myRigidbody.velocity = new Vector2(moveSpeed, 0);
                        break;

                    case 2:
                        if (hasWalkZone && transform.position.y < minWalkPoint.y)
                        {
                            Debug.Log("passed");

                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        myRigidbody.velocity = new Vector2(0, -moveSpeed);
                        break;

                    case 3:
                        if (hasWalkZone && transform.position.x < minWalkPoint.x)
                        {
                            Debug.Log("passed");

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
        WalkDirection = Random.Range(0, 4);
        if (isStationary)
        {
            isWalking = !isStationary;
            StopForConvo(); 
        }
        else
        {
            isWalking = true; 
        }

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
