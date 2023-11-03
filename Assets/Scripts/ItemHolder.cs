using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public string itemName;

    public string PickUpItem(){
        Debug.Log("ItemRecieved");
        string temp = itemName;
        itemName = "";
        return temp;
    }
}



