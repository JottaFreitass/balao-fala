using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeTextAnimation : MonoBehaviour
{

    public Action TypeFinished;

    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;
    public string fullText;
    public int i = 0; 
    
    void Start()
    {
        StartCoroutine(TypeText());
    }


    IEnumerator TypeText()
    {
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        for(i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }

        TypeFinished?.Invoke();

    }

    public void Skip()
    {
        StopCoroutine(coroutine);
        textObject.maxVisibleCharacters = textObject.text.Length;
    }




}