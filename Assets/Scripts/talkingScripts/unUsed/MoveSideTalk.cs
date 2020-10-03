using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class MoveSideTalk : MonoBehaviour
{

    public GameObject talkBox;
    public bool playerInRange;
    [SerializeField] AudioSource playMusic;
    [SerializeField] AudioSource playCompSong1;
    public bool talkOn = false;
    public InkScript inkScript;
    private GameObject[] friends;


    void Start()
    {
        friends = GameObject.FindGameObjectsWithTag("friendlySideways");

    }

    // WORKING VERSION OF THIS SCRIPT WITH FINAL FUNCTIONALITY
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)

        {
            if (talkOn == false)
            {
                talkBox.GetComponent<InkScript>().ShowPanels();

               // this.GetComponent<FriendlyMovement>().StopForConvo();
                this.GetComponent<FriendlyMovementSideways>().StopForConvo();
                Debug.Log("talking");
                talkBox.SetActive(true);
                talkBox.GetComponent<InkScript>().ShowPanels();
                talkBox.GetComponent<InkScript>().refreshUI();
                ChangeMusicToSong();
                talkOn = true;
                talkBox.GetComponent<InkScript>().ContinueBool();
              //  StopFriends();
               // StopFriendsSideways();
            }

            else if (Input.GetKeyDown(KeyCode.Space) && inkScript.continuing)

            {
              //  this.GetComponent<FriendlyMovement>().StopForConvo();
                this.GetComponent<FriendlyMovementSideways>().StopForConvo();

                Debug.Log("talkingMore");
                talkBox.GetComponent<InkScript>().refreshUI();
                talkBox.GetComponent<InkScript>().ContinueBool();

            }

            else
            {
              //  this.GetComponent<FriendlyMovement>().LeaveConvo();
                 this.GetComponent<FriendlyMovementSideways>().LeaveConvo();

                Debug.Log("ending");
                talkOn = false;
                talkBox.GetComponent<InkScript>().eraseUI();
                talkBox.GetComponent<InkScript>().refreshStory();
                talkBox.GetComponent<InkScript>().HidePanels();
                ChangeMusicToMain();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().UnFreeze();
               // StartFriends();
                //   StartFriendsSideways();
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
            ChangeMusicToMain();
          //  StartFriends();
            //  StartFriendsSideways();
        }
    }

    public void ChangeMusicToSong()
    {
        playMusic.mute = true;
        playCompSong1.mute = false;
    }

    public void ChangeMusicToMain()
    {
        playMusic.mute = false;
        playCompSong1.mute = true;
    }

    /*
    private void StopFriends()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friends");
        foreach (GameObject friends in friends)
            friends.GetComponent<FriendlyMovement>().StopForConvo();
    }

    private void StartFriends()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friendsagain");
        foreach (GameObject friends in friends)
            friends.GetComponent<FriendlyMovement>().LeaveConvo();

    }
    */

    /*
    private void StopFriendsSideways()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friends");
        foreach (GameObject friends in friends)
            friends.GetComponent<FriendlyMovementSideways>().StopForConvo();
    }

    private void StartFriendsSideways()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friendsagain");
        foreach (GameObject friends in friends)
            friends.GetComponent<FriendlyMovementSideways>().LeaveConvo();
    }
    */


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