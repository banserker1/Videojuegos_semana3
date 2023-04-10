using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
  

    const int Idle = 0;
    const int Run = 1;
    const int Jump = 2;
    const int Attack = 3;
    const int Dead = 50;
 

    private bool life = true;
  

    const int vIdle = 0;
    const int vRun = 10;
    const int jumpForce = 10;

    // Start is called before the first frame update
    void Start()
    {      


  rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
         if (life) {
            rb.velocity = new Vector2(vIdle,rb.velocity.y);
            SetAnimacion(Idle);

            if(Input.GetKey(KeyCode.RightArrow)) {
                Debug.Log("Correr derecha");
                sr.flipX = false ;
                rb.velocity = new Vector2(vRun,rb.velocity.y);
                SetAnimacion(Run);
            }
            if(Input.GetKey(KeyCode.LeftArrow)) {
                Debug.Log("Correr izquierda");
                sr.flipX = true ;
                rb.velocity = new Vector2(-vRun,rb.velocity.y);
                SetAnimacion(Run);
            }
            if(Input.GetKey(KeyCode.A)) {
                SetAnimacion(Attack);
            }
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                SetAnimacion(Jump);
            }
            if(Input.GetKeyDown(KeyCode.F)) {
                SetAnimacion(Dead);
                life = false;
            }
        }
    }

    void SetAnimacion(int animacion) {
        animator.SetInteger("Estado",animacion);
    }

}