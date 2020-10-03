using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam2D : MonoBehaviour
{

   // [SerializeField] GameObject player;

    private GameObject player; 

    [SerializeField] float timeOffset;

    [SerializeField] Vector2 posOffset;

    private Vector3 velocity;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

    private static bool cameraExists; 


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player1Player");

        /*
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        //camera start position
        Vector3 startPos = transform.position;

        //players current position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        //set camera transform to a combination of startPos & endPos using LERP which uh combines the two?
        //this is how you LERP
        //transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        //this is how you use Smooth Dampening
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);



        //creates boundaries for camera
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );

    }

    
    private void OnDrawGizmos()
    {
        //draw a box around our cambera boundary
        Gizmos.color = Color.red;
        //top boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        //right boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        //bottom boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        //left boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));

    }

    
}
