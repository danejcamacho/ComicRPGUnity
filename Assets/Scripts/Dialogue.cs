using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;

    public float textSpeed;

    private int index;
    public bool isTalking = false;

    public AudioClip soundEffect;
    public AudioSource audioSource;

    private void Awake() {
        gameObject.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue(string[] givenLines)
    {
        if(soundEffect != null)
            audioSource.PlayOneShot(soundEffect);

        if(!isTalking){
            textComponent.text = string.Empty;
            gameObject.SetActive(true);
            lines = givenLines;
            index = 0;
            StartCoroutine(TypeLine());
            isTalking = true;
        }
        
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            isTalking = false;
            gameObject.SetActive(false);
        }
    }
}