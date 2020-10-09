using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Collider2D GameArea;
    public int friendsNumber = 20; 
    public GameObject [] friends;
    //public float spawnTime = 0.5f; 
    private Vector3 spawnPosition;
    public List<GameObject> friendsPool = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        intialSpawn();
       // StartCoroutine(friendsEnter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void intialSpawn()
    {
        for (int i = 0; i<friendsNumber; i++)
        {
           Vector2 spawnPosition = new Vector2(Random.Range(GameArea.bounds.min.x, GameArea.bounds.max.x), Random.Range(GameArea.bounds.min.y, GameArea.bounds.max.y));
           GameObject friend = Instantiate(friends[UnityEngine.Random.Range(0, friends.Length)], spawnPosition, Quaternion.identity) as GameObject;
           friendsPool.Add(friend);
        }
    }


    /*
    public void spawnRandom()
    {

        spawnPosition.x = 21;
        spawnPosition.y = Random.Range(-3f, -8f);
        spawnPosition.z = 0;
        GameObject a = Instantiate(friends[UnityEngine.Random.Range(0, friends.Length)] as GameObject);
        a.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
    }

 

    IEnumerator friendsEnter()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnRandom();
        }
    }

    */

}
