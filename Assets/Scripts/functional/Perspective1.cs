using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective1 : MonoBehaviour
{


    //[SerializeField] GameObject player;
    private GameObject Player1;
    //public static SortingLayer Streetlight2;
    // public static GameObject lamp1;
    //public int sortingOrder = 0;
    public SpriteRenderer sprite;
    public GameObject pivot;

    //public string sortingLayerName { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        Perspective();

    }

    public void Perspective()
    {
        if (Player1.transform.position.y > pivot.transform.position.y)
        {
            //  Debug.Log("good");
            sprite.sortingOrder = 2;
            // gameObject.layer = LayerMask.NameToLayer("Streetlight");
        }
        else
        {
            sprite.sortingOrder = 0;
        }
    }
}