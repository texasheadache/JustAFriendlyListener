using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class loadNewArea : MonoBehaviour
{

    public bool playerInRange;
    public string levelToLoad;

    public smallLoader sl;
    public smallLoader2 sl2; 
    public string exitPoint;
    private PlayerMovement thePlayer;

    public int num; 

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            sl.loading();
           // sl2.coinFlip();
            SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
            thePlayer.startPoint = exitPoint; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }

    }

 

}