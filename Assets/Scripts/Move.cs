using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float velocidad;
    public float FuerzaSalto;
    
    public int Saltos;
    public LayerMask CapaSuelo;
    public AudioManager audioManager;
    public AudioClip AudSalto;

    private Rigidbody2D Rigidbody;
    private BoxCollider2D boxCollider;
    private bool Orientacion = true;
    private int saltosRestantes;
    private Animator animator;
    

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = Saltos;
        animator = GetComponent<Animator>();

    }

    
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    bool Suelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, CapaSuelo);
        return raycastHit.collider != null;
    }

    void ProcesarSalto()
    {
        if(Suelo())
        {
            saltosRestantes = Saltos;
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes --;
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, 0f);
            Rigidbody.AddForce(Vector2.up * FuerzaSalto, ForceMode2D.Impulse);
            audioManager.ReproducirSonido(AudSalto);
        }



    }



    void ProcesarMovimiento()
    {
        

       float inputMove = Input.GetAxis("Horizontal");

       if(inputMove != 0f)
       {
        animator.SetBool("Corriendo", true);
       }
       else
       {
        animator.SetBool("Corriendo", false);
       }
       
       Rigidbody.velocity = new Vector2(inputMove * velocidad, Rigidbody.velocity.y);

       GestionarOrientacion(inputMove);
    }

    void GestionarOrientacion(float inputMove)
    {
        if((Orientacion == true && inputMove < 0) || (Orientacion == false && inputMove > 0 ))
        {
            Orientacion = !Orientacion;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    

        
    
    

    
}
