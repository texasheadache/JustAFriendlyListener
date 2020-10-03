using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyMovementSideways : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
   // public float moveSpeed;
    public float randomSpeed;
    private Animator anim;
  //  public GameObject[] friends; 


    // Start is called before the first frame update
    void Start()
    {
        defineRandomSpeed();
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.velocity = new Vector2(-randomSpeed, 0);
        anim = GetComponent<Animator>();
      //  friends = GameObject.FindGameObjectsWithTag("friendly");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void defineRandomSpeed()
    {
        randomSpeed = Random.Range(0.3f, 1f);
    }

    public void StopForConvo()
    {
       myRigidbody.velocity = new Vector2(0, 0);
       myRigidbody.velocity = Vector2.zero;

    }

    public void LeaveConvo()
    {
        myRigidbody.velocity = new Vector2(-randomSpeed, 0);
    }

    public void stopAnimation()
    {
         anim.enabled = false;
    }

    public void startAnimation()
    {
         anim.enabled = true;
    }

}
