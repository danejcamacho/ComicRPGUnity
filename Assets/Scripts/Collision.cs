using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    const int COLLIDABLE_LAYER = 7;
    const int INTERACTABLE_LAYER = 6;
    public TileBasedPlayerController pc;
    public GameObject movePoint;
    RaycastHit2D hit;

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.CircleCast(movePoint.transform.position,.4f,Vector2.zero);

        if(hit.collider != null){
            
            if(hit.collider.gameObject.layer == COLLIDABLE_LAYER || hit.collider.gameObject.layer == INTERACTABLE_LAYER){
                movePoint.transform.position = transform.position;
            }
        }
    }
}
