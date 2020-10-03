using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnExit1 : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "friendly")
        {
            BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
            Vector2 pos = new Vector2(0f, Random.Range(box.bounds.min.y, box.bounds.max.y));
            
            Debug.Log(collision.gameObject.GetComponent<FriendlyMovementSideways>());
            if (collision.gameObject.GetComponent<FriendlyMovementSideways>().randomSpeed < 0f)
            {
                pos.x = box.bounds.min.x;
            }
            else
            {
                pos.x = box.bounds.max.x; 
            }
            
            collision.gameObject.transform.position = pos; 
        }
    }
}
