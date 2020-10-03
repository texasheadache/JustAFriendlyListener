using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class WallObject1 : MonoBehaviour
{

    public GameObject talkBox;
    public bool playerInRange;
    public static bool talkOn = false;
    public InkScript inkScript;
    private GameObject[] friends;



    void Start()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
    }

    // WORKING VERSION OF THIS SCRIPT WITH FINAL FUNCTIONALITY
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)

        {
            if (talkOn == false)
            {
                talkBox.GetComponent<InkScript>().ShowPanels();
                talkBox.SetActive(true);
                talkBox.GetComponent<InkScript>().ShowPanels();
                talkBox.GetComponent<InkScript>().refreshUI();
                talkOn = true;
                talkBox.GetComponent<InkScript>().ContinueBool();
                //StopFriends();
                //StopFriendsSideways();
                //StopFriendsSideways2();
            }

            else if (Input.GetKeyDown(KeyCode.Space) && inkScript.continuing)

            {
                Debug.Log("talkingMore");
                talkBox.GetComponent<InkScript>().refreshUI();
                talkBox.GetComponent<InkScript>().ContinueBool();
                //StopFriendsSideways();
                //StopFriendsSideways2();
            }

            else 
            {
                Debug.Log("ending");
                talkOn = false;
                talkBox.GetComponent<InkScript>().eraseUI();
                talkBox.GetComponent<InkScript>().refreshStory();
                talkBox.GetComponent<InkScript>().HidePanels();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().UnFreeze();
                //StartFriends();
                //StartFriendsSideways();
                //StartFriendsSideways2();
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
            talkBox.GetComponent<InkScript>().eraseUI();
            talkBox.GetComponent<InkScript>().refreshStory();
            talkBox.GetComponent<InkScript>().HidePanels();
            //StartFriends();
            //StartFriendsSideways();
            //StartFriendsSideways2();
        }
    }

    private void StopFriends()
    {
       friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friends");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovement>() != null)
            {
                friends.GetComponent<FriendlyMovement>().StopForConvo();
            }
        }
    }

    private void StartFriends()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friendsagain");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovement>() != null)
            {
                friends.GetComponent<FriendlyMovement>().LeaveConvo();
            }
        }
    }

    
    private void StopFriendsSideways()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friends");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovementSideways>() != null)
            {
               friends.GetComponent<FriendlyMovementSideways>().StopForConvo();
            }
        }
    }

    private void StartFriendsSideways()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friendsagain");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovementSideways>() != null)
            {
                friends.GetComponent<FriendlyMovementSideways>().LeaveConvo();
            }
        }
    }

    private void StopFriendsSideways2()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friends");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovementSideways2>() != null)
            {
                friends.GetComponent<FriendlyMovementSideways2>().StopForConvo();
            }
        }
    }

    private void StartFriendsSideways2()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friendsagain");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovementSideways2>() != null)
            {
               friends.GetComponent<FriendlyMovementSideways2>().LeaveConvo();
            }
        }
    }


    /*
    ///method to be used in "Fade" script
    public void Off()
    {
        talkBox.SetActive(false);
    }
    */

    /*BASIC STSART OF PREVIOUS 'TALKINGFRIEND' SCRIPT
     * void Update()
     {
         if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
         {
             if (talkBox.activeInHierarchy)
             {
                 talkBox.SetActive(true);
                 talkBox.GetComponent<InkScript>().ShowPanels();
                 talkBox.GetComponent<InkScript>().refreshUI();
                 ChangeMusicToSong();
             }
             else
             {
                 talkBox.SetActive(false);
                 talkBox.GetComponent<InkScript>().HidePanels();
                 ChangeMusicToMain();
             }
         }
     }
     */


    /*WORKING VERSION OF FIRST VERSION OF THIS SCRIPT
     * 
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange)

            {
                if (talkOn == false)
                {
                    Debug.Log("talking");
                    talkBox.SetActive(true);
                    talkBox.GetComponent<InkScript>().ShowPanels();
                    talkBox.GetComponent<InkScript>().refreshUI();
                    ChangeMusicToSong();
                    talkOn = true;
                }

             else

            {
                Debug.Log("test");
                     talkOn = false;
                     talkBox.GetComponent<InkScript>().eraseUI();
                      talkBox.GetComponent<InkScript>().refreshStory();
                    talkBox.GetComponent<InkScript>().HidePanels();
                     ChangeMusicToMain();
                     GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().UnFreeze();
                }
            }
    }
    */
}