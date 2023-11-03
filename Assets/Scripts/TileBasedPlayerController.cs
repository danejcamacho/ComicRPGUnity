using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.XR;

public class TileBasedPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Vector2 directionFacing = Vector2.down;
    private float xInput = 0;
    private float yInput = 0;
    private bool isMoving = false;

    public Dialogue dialogue;

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Start() {
        movePoint.parent = null;
    }

    private void Update() {

        if(!dialogue.isTalking){    
            if(xInput != 0 || yInput != 0){
            isMoving =true;
            
            } else {
                isMoving = false;
                
            }
        
        
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            
            anim.SetFloat("moveX", directionFacing.x );
            anim.SetFloat("moveY", directionFacing.y);
            anim.SetBool("isMoving", isMoving);
            

            if(Vector3.Distance(transform.position, movePoint.position) == 0f) {//if player has reached movePoint
                
                //Horizontal timePassed, horizontal direction
                //vertical "" "" ""

                //Vector2 lastInputDirection = 0,0
                //When and input is detect (on the frame)
                // last input direction = input direction


                //move in last input direction
                xInput = Input.GetAxisRaw("Horizontal");
                yInput = Input.GetAxisRaw("Vertical");


                if(Mathf.Abs(xInput) == 1f){
                    
                    
                    
                    if (xInput <= 0f){
                        directionFacing = Vector2.left;
                    }
                    if (xInput >= 0f){
                        directionFacing = Vector2.right;
                    }

                    
                    movePoint.position += new Vector3(xInput, 0f,0f);
                } else if(Mathf.Abs(yInput) == 1f){
                    
                    
                    if (yInput <= 0f){
                        directionFacing = Vector2.down;
                    }
                    if (yInput >= 0f){
                        directionFacing = Vector2.up;
                    }
                    movePoint.position += new Vector3(0f, yInput,0f);
                }
                

            }
        } else {
            anim.SetBool("isMoving", false);
        }
        
    }

}
