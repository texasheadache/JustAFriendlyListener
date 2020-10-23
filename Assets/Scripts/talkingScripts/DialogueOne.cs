using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOne : MonoBehaviour
{

    public GameObject talkBox;
    public bool playerInRange;
    private GameObject[] friends;
    // public float delay; 
    // public FriendlyMovement movingFriends;

    void Start()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");

    }


    void Update()
    {
        // if (Time.time > delay)
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
            {
                // delay = Time.time + 0.5f; 
                if (talkBox.activeInHierarchy)
                {
                    //isTalk = true;
                    if (this.GetComponent<FriendlyMovement>() != null)
                    {
                        GameObject.FindObjectOfType<FriendlyMovement>().StopForConvo();
                    }
                    StopFriendsSideways();
                    StopFriendsSideways2();
                    talkBox.SetActive(true);
                    talkBox.GetComponent<InkScript>().ShowPanels();
                    Debug.Log("PanelShown");
                    talkBox.GetComponent<InkScript>().refreshUI();
                    Debug.Log("RefreshedUI");
                    StopFriends();
                    //   this.GetComponent<MusicPlayerFirst>().ChangeMusicToSong();
                    StopFriendsAnim();
                    StopFriendsAnim2();
                }
                else
                {
                    GameObject.FindObjectOfType<FriendlyMovement>().LeaveConvo();
                    Debug.Log("leftConvo at weird part");
                    StartFriendsSideways();
                    StartFriendsSideways2();
                    talkBox.SetActive(false);
                    talkBox.GetComponent<InkScript>().HidePanels();
                    Debug.Log("PanelHidden");
                    StartFriends();
                    // this.GetComponent<MusicPlayerFirst>().ChangeMusicToMain();
                    StartFriendsAnim();
                    StartFriendsAnim2();
                }
            }
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
        Debug.Log("friends");
        foreach (GameObject friends in friends)
        {
            if (friends.GetComponent<FriendlyMovement>() != null)
            {
                friends.GetComponent<FriendlyMovement>().LeaveConvo();
            }
        }
    }


    private void StopFriendsAnim()
    {
        friends = GameObject.FindGameObjectsWithTag("friendly");
        Debug.Log("friends");
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
        Debug.Log("friends");
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
        Debug.Log("friends");
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
        Debug.Log("friends");
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
            if (this.GetComponent<FriendlyMovement>() != null)
            {
                GameObject.FindObjectOfType<FriendlyMovement>().LeaveConvo();
            }
            Debug.Log("leftConvo");
            StartFriends();
            StartFriendsSideways();
            StartFriendsSideways2();
            //  this.GetComponent<MusicPlayerFirst>().ChangeMusicToMain();
            StartFriendsAnim();
            StartFriendsAnim2();
        }
    }



    ///method to be used in "Fade" script
    public void Off()
    {
        talkBox.SetActive(false);
    }


}