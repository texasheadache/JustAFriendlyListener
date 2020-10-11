using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class papers1 : MonoBehaviour
{
    public bool playerInRange;
    public bool isImageOn;
    private GameObject player;
    int papersPages; 

    [SerializeField] Image[] papers;

    // Start is called before the first frame update
    void Start()
    {
        papersPages = 0; 
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
                papers[0].enabled = true;
                isImageOn = true;
                paused();
            }
            else
            {
                papers[papersPages].enabled = false;
                isImageOn = false;
                unPaused();
                papersPages = 0; 
            }
        }

        if (isImageOn == true)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (papersPages < papers.Length - 1)
                    {
                        papersPages++;
                        papers[papersPages].enabled = true;
                        papers[papersPages - 1].enabled = false; 
                    }
                }
            }

        if (isImageOn == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (papersPages > 0)
                {
                    papersPages--;
                    papers[papersPages].enabled = true;
                    papers[papersPages + 1].enabled = false;
                }
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
