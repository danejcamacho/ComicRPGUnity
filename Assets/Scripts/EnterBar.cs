using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<PlayerInventory>().inventory.Contains("BarKey")){
                other.GetComponent<PlayerInventory>().inventory.Remove("BarKey");
                Debug.Log("Enter Bar");
                SceneManager.LoadScene("Bar");
            }
            
            
        }
    }
}
