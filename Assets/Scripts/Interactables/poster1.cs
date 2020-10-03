using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poster1 : MonoBehaviour
{
    public bool playerInRange;
    public bool isImageOn; 
    public Image poster;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        poster.enabled = false;
        isImageOn = false;
        player = GameObject.Find("Player1Player");
        playerInRange = false; 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(isImageOn == false)
            {
                poster.enabled = true;
                isImageOn = true;
                paused();
            }
            else
            {
                poster.enabled = false;
                isImageOn = false;
                unPaused();
                 
                
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
