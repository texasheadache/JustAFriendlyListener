using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clampCam : MonoBehaviour
{
    [SerializeField] Transform followTransform;


  //  Transform t;

    private void Awake()
    {
     //   t = transform; 
    }


    private void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(followTransform.position.x, -4f, 5f),
            Mathf.Clamp(followTransform.position.y, 1f, -6f),
            transform.position.z);
    }

    /*
    private void LateUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x,
                  followTransform.position.y, this.transform.position.z);
    }
    */
}
