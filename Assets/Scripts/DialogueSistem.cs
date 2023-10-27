using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum STATE
{
    DISABLE,
    WAITING,
    TYPING
}

public class DialogueSistem : MonoBehaviour
{
    public DialogueData dialogueData;

    int currentText = 0;
    bool finished = false;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    STATE state;

    void Awake()
    {
     typeText = FindObjectOfType<TypeTextAnimation>();
     typeText = FindObjectOfType<DialogueUI>();

     typeText.typeFinished = OnTypeFinishe;
    }

    void Start()
    {
        state = STATE.DISABLE;
    }

    void Update()
    {
        if(state == STATE.DISABLE) return;

        switch(state)
        {
            case STATE.WAITING:
            Waiting();
            break;

            case STATE.TYPING:
            Typing();
            break;
        }
    }

    public void NEXT()
    {

        if(currentText == 0)
        {
            dialogueUI.Enable();
        }

        dialogueUI.SetName(dialogueData.talkScript[currentText].name);

        typeText.fullText = dialogueData.talkScript[currentText++].text;

        if(currentText == dialogueData.talkScript.Count) finished = true;

        typeText.StartTypeText();
        state = STATE.TYPING;
    }

    void OnTypeFinishe(){
        state = STATE.WAITING;
    }

    void Waiting()
    {

        if(Input.GetKeyDown(KeyCode.Return)){
            if(!finished){
            NEXT();
        }else{

            dialogueUI.Disable();
            state = STATE.DISABLE;
            currentText = 0;
            finished = false;

        }
        }
    }


    void Typing()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            typeText.Skip();
            state = STATE.WAITING;
        }
    }
}
