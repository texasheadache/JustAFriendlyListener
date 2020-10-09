using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class papers1 : MonoBehaviour
{
    public bool playerInRange;
    public bool isImageOn;
    public Image paper;
    public Image paper2;
    public Image paper3;
    public Image paper4; 
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        paper.enabled = false;
        paper2.enabled = false;
        paper3.enabled = false;
        paper4.enabled = false; 
        isImageOn = false;
        player = GameObject.Find("Player1Player");
        playerInRange = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (isImageOn == false)
            {
                paper.enabled = true;
                paper2.enabled = true;
                isImageOn = true;
                paused();
            }
            else
            {
                paper.enabled = false;
                paper2.enabled = false;
                paper3.enabled = false;
                paper4.enabled = false; 
                isImageOn = false;
                unPaused();
            }
        }

        if(isImageOn == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                paper.enabled = false; 
                paper2.enabled = false;
                paper3.enabled = true;
                paper4.enabled = true; 
            }
        }

        if (isImageOn == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                paper.enabled = true;
                paper2.enabled = true;
                paper3.enabled = false;
                paper4.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public void paused()
    {
        player.GetComponent<PlayerMovement>().Freeze();
    }

    public void unPaused()
    {
        player.GetComponent<PlayerMovement>().UnFreeze();
    }

}
