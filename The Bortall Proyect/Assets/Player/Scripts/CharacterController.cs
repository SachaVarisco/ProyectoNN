using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement")]

    public float speed;
    
    private bool lookingRight = true;
    private Rigidbody2D rigidBody;


    [Header("Salto")]

    public float jumpForce;
    public LayerMask floorMask;

    private BoxCollider2D boxCollider;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        CharacterMovement();
        Jump();
        
    }


    private void CharacterMovement()
    {
        //Movimiiento de personaje
        float horizontalMovement = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(horizontalMovement * speed, rigidBody.velocity.y);

        BodyOrientation(horizontalMovement);
    }

    private void BodyOrientation(float horizontalMovement)
    {
        //Cambio de orientacion del personaje

        if((lookingRight == true && horizontalMovement < 0) || (lookingRight == false && horizontalMovement > 0))
        {
            lookingRight = !lookingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && OnTheFloor())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool OnTheFloor()
    {
        //Evitar salto multiple
        //
        //Cuando vuelve a tocar el Layer de "Platforms", puede volver a saltar.

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, floorMask);
        return raycastHit.collider != null;
    }
}
