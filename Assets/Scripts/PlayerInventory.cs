using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerInventory : MonoBehaviour
{

    SaveDataSO saveData;
    public List<string> inventory = new List<string>();

    void Start(){
        saveData = ScriptableObject.CreateInstance<SaveDataSO>();
        if(File.Exists(Application.persistentDataPath+"/PlayerInv.dat"))
        {
            Debug.Log(Application.persistentDataPath+"/PlayerInv.dat");
            JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.persistentDataPath+"/PlayerInv.dat"),saveData);
            inventory = saveData.savedInventory;
        }
    }
    
    void OnDestroy(){
        ShuttingDown();
    }

    public void ShuttingDown(){
        saveData.savedInventory = inventory;
        File.WriteAllText(Application.persistentDataPath+"/PlayerInv.dat",JsonUtility.ToJson(saveData));
    }

    
}
