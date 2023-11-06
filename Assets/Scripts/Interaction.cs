using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    const int INTERACTABLE_LAYER = 6;
    public TileBasedPlayerController pc;
    public Dialogue dialogueBox;
    private GameObject other;
    private PlayerInventory inventory;
    RaycastHit2D hit;

    void Start(){
        inventory = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, pc.directionFacing, 1f);
        

        if(hit.collider != null){
            Debug.DrawLine(transform.position, hit.point, Color.red);
            
            if(hit.collider.gameObject.layer == INTERACTABLE_LAYER && Input.GetKeyDown(KeyCode.Z)){
                //dialogueBox.StartDialogue(hit.collider.gameObject.GetComponentOfType<NPCDialogueHolder>().GetMyDialogue());
                other = hit.collider.gameObject;
                if(other.GetComponent<ItemHolder>() != null){
                    if(other.GetComponent<ItemHolder>().itemName != ""){
                        inventory.inventory.Add(other.GetComponent<ItemHolder>().PickUpItem());
                    }
                }

                if(other.GetComponent<NPCSoundEffectHolder>() != null){
                    if(other.GetComponent<NPCSoundEffectHolder>().clip != null){
                        dialogueBox.soundEffect = other.GetComponent<NPCSoundEffectHolder>().clip;
                    }
                    
                }
                dialogueBox.StartDialogue(other.GetComponent<NPCDialogueHolder>().GetMyDialogue());
            }
        }
    }
}
