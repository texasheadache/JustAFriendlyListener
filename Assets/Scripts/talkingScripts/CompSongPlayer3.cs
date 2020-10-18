using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class CompSongPlayer3 : MonoBehaviour
{

    private GameObject talkBox;

    public bool playerInRange;
    private AudioSource playMusic;
    private AudioSource playCompSong1;
    public static bool talkOn = false;
    private InkScript inkScript;
    private GameObject[] friends;
    private Animator animator;

    private int num; 

    void Start()
    {
        talkBox = GameObject.Find("HallFriendTalks");

        playMusic = GameObject.Find("Sounds").GetComponent<AudioSource>();
        playCompSong1 = GameObject.Find("OldSong").GetComponent<AudioSource>();

        inkScript = GameObject.Find("HallFriendTalks").GetComponent<InkScript>();

        friends = GameObject.FindGameObjectsWithTag("friendly");
        animator = GetComponent<Animator>();

    }

    // WORKING VERSION OF THIS SCRIPT WITH FINAL FUNCTIONALITY
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)

        {

            if (talkOn == false)
            {
                talkBox.GetComponent<InkScript>().ShowPanels();
                animator.SetBool("closeEnough", false);
                animator.SetBool("startedWaving", false);

                /*
                if(this.GetComponent<FriendlyMovement>() != null)
                {
                    this.GetComponent<FriendlyMovement>().StopForConvo();
                }
                */

                if(this.GetComponent<FriendlyMovementSideways>() != null)
                {
                    this.GetComponent<FriendlyMovementSideways>().StopForConvo();
                }

                talkBox.SetActive(true);
                talkBox.GetComponent<InkScript>().ShowPanels();
                talkBox.GetComponent<InkScript>().refreshUI();
                this.GetComponent<MusicPlayerSecond>().HallSong1();
                talkOn = true;
                talkBox.GetComponent<InkScript>().ContinueBool();
               // StopFriends();
                StopFriendsSideways();
                StopFriendsSideways2();
                StopFriendsAnim();
                StopFriendsAnim2();
            }

            else if (Input.GetKeyDown(KeyCode.Space) && inkScript.continuing)

            {
                /*
                if(this.GetComponent<FriendlyMovement>() != null)
                {
                    this.GetComponent<FriendlyMovement>().StopForConvo();
                }

                */
                if(this.GetComponent<FriendlyMovementSideways>() != null)
                {
                    this.GetComponent<FriendlyMovementSideways>().StopForConvo();
                }
                animator.SetBool("closeEnough", false);
                animator.SetBool("startedWaving", false);
                talkBox.GetComponent<InkScript>().refreshUI();
                talkBox.GetComponent<InkScript>().ContinueBool();
                StopFriendsSideways();
                StopFriendsSideways2();
                StopFriendsAnim();
                StopFriendsAnim2();
            }

            else 
            {
                if(this.GetComponent<FriendlyMovement>() != null)
                {
                    this.GetComponent<FriendlyMovement>().LeaveConvo();
                }

                if(this.GetComponent<FriendlyMovementSideways>() != null)
                {
                    this.GetComponent<FriendlyMovementSideways>().LeaveConvo();
                }

                talkOn = false;
                talkBox.GetComponent<InkScript>().eraseUI();
                talkBox.GetComponent<InkScript>().refreshStory();
                talkBox.GetComponent<InkScript>().HidePanels();
                this.GetComponent<MusicPlayerSecond>().MainMusic();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().UnFreeze();
              //  StartFriends();
                StartFriendsSideways();
                StartFriendsSideways2();
                StartFriendsAnim();
                StartFriendsAnim2();
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
            this.GetComponent<MusicPlayerSecond>().MainMusic();
            //StartFriends();
            StartFriendsSideways();
            StartFriendsSideways2();
        }
    }
    /*
    private void StopFriends()
    {
       friends = GameObject.FindGameObjectsWithTag("friendly");
        foreach (GameObject friends in friends)
        {
            if(friends.GetComponent<FriendlyMovement>() != null)
            {
                friends.GetComponent<FriendlyMovement>().StopForConvo();
            }
        }
    }

    private void StartFriends()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        foreach (GameObject friends in friends)
        {
            if(friends.GetComponent<FriendlyMovement>() != null)
            {
                friends.GetComponent<FriendlyMovement>().LeaveConvo();
            }
        }
    }
    */

    private void StopFriendsAnim()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovementSideways>() != null)
            {
                friends.GetComponent<Animator>().enabled = false;
            }
        }
    }

    private void StartFriendsAnim()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovementSideways>() != null)
            {
                friends.GetComponent<Animator>().enabled = true; 
            }
        }
    }

    private void StopFriendsAnim2()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovementSideways2>() != null)
            {
                friends.GetComponent<Animator>().enabled = false;
            }
        }
    }



    private void StartFriendsAnim2()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovementSideways2>() != null)
            {
                friends.GetComponent<Animator>().enabled = true;
            }
        }
    }

    private void StopFriendsSideways()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
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