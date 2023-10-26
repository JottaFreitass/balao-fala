using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stella : MonoBehaviour
{
    public float velocidade = 30f;
    public Animator animator;
    private Rigidbody2D playerRigidbody2D;
    private float MovimentoHorizontal;

    void Start()
    {
        Debug.Log("Start de " + this.name);
        animator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        Movimento();
        MovimentoHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void Movimento()
    {
        

        Vector2 moveDirection = new Vector2(MovimentoHorizontal, 0).normalized;
        Vector2 newPosition = playerRigidbody2D.position + moveDirection * velocidade * Time.deltaTime;

        playerRigidbody2D.MovePosition(newPosition);

        /*switch (MovimentoHorizontal)
        {
            case 1:
                animator.Play("andar_direita");
                Debug.Log("Andar Direita");
                break;

            case -1:
                animator.Play("andar_esquerda");
                Debug.Log("Andar Esquerda");
                break;

            case 0:
                animator.Play("Idle");
                Debug.Log("Parado");
                break;
        }*/

        
        }




    }
        private void OnTriggerEnter2D(Collider2D other)
        {

            Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);




            if (other.tag == "Parede")
            {
                animator.SetBool("Idle", true);
            }
            else
            {
                animator.SetBool("Idle", false);
            }

        }

}
    

