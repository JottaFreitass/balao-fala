using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar_Stella : MonoBehaviour
{
    public float entradaHorizontal;
    public float velocidade;
    [SerializeField] private Animator animator;
    public float movimentoHorizontal;
    public bool podeAndar;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start de " + this.name);
        velocidade = 3.0f;
        transform.position = new Vector3(-7.61f, -4.16f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        movimentoHorizontal = Input.GetAxis("Horizontal");
        

        if (podeAndar == true)
       {
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);
        Movimento();
       }
       else
       {

       }

    }

    void Movimento()
    {
        if (movimentoHorizontal < 0)
        {
            animator.SetBool("Esquerda", true);
        }
        else
        {
            animator.SetBool("Esquerda", false);
        }
        if (movimentoHorizontal > 0)
        {
            animator.SetBool("Direita", true);
        }
        else
        {
            animator.SetBool("Direita", false);
        }
    
    }



}
    

