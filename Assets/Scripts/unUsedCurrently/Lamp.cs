using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{


    [SerializeField] GameObject player;
    //public static SortingLayer Streetlight2;
    // public static GameObject lamp1;
    //public int sortingOrder = 0;
    public SpriteRenderer sprite;
    public GameObject pivot; 

    //public string sortingLayerName { get; private set; }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        LampShade();

    }

    public void LampShade()
    {
        if (player.transform.position.y > pivot.transform.position.y)
        {
          //  Debug.Log("good");
            sprite.sortingOrder = 1; 
           // gameObject.layer = LayerMask.NameToLayer("Streetlight");
        }
        else
        {
            sprite.sortingOrder = 0; 
        }
    }
}