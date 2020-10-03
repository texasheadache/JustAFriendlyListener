using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavingFriend : MonoBehaviour
{
    //public AnimationClip clipName;
    public float reachDistance;
    private GameObject Player;
    public GameObject Target;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player1Player");

    }

    // Update is called once per frame
    void Update()
    {
        reachDistance = Vector3.Distance(Player.transform.position, Target.transform.position);
        if (reachDistance < 1.0f && CompSongPlayer.talkOn == false)
        {
            animator.SetBool("closeEnough", true);
            animator.SetBool("startedWaving", true);
        }
        else if (reachDistance < 1.0f && CompSongPlayer.talkOn == true)
        { 
            animator.SetBool("closeEnough", false);
            animator.SetBool("startedWaving", false);
        }
        else
        {
            animator.SetBool("closeEnough", false);
            animator.SetBool("startedWaving", false);
        }
      
    }
}