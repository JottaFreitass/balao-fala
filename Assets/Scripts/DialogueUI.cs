using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    Image Balao;
    TextMeshProUGUI nameText;
    TextMeshProUGUI talkText;

    public float speed = 10f;
    bool open = false;

    void Awake()
    {
        Balao = transform.GetChild(0).GetComponent<Image>();
        nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        talkText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(open){
            Balao.fillAmount = Mathf.Lerp(Balao.fillAmount, 1, speed * Time.deltaTime);
        } else{
            Balao.fillAmount = Mathf.Lerp(Balao.fillAmount, 0, speed * Time.deltaTime);
        }
    }


    public void SetName(string name)
    {
        nameText = name;
    }


    public void Enable() 
    {
        Balao.fillAmount = 0;
        open = true;
    }


    public void Disable()
    {
        open = false;
        nameText.text = "";
        talkText.text = "";
    }
}
