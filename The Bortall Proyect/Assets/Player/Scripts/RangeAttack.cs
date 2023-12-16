using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{

    [Header("Bullets")]
    [SerializeField] private Transform bulletController;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float reloadTime;
    [SerializeField] private float countdown;

    [Header("Recoil")]
    private Looking Looking;
    private Rigidbody2D rigidBody;
    private CharacterController characterController;
    [SerializeField] private float impulse;

    private void Start() 
    {
        characterController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody2D>();
        Looking = GetComponent<Looking>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && countdown <= 0)
        {
           Shoot();    
        }
    }

     private void FixedUpdate() 
    {
        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        countdown = reloadTime;
        Instantiate(bullet, bulletController.position, bulletController.rotation);
        StartCoroutine(NullMove());
        
       switch (Looking.direction)
        {
            case "Up":
                rigidBody.AddForce(Vector2.down * (impulse/3), ForceMode2D.Impulse);
                break;
            case "Down":
                rigidBody.AddForce(Vector2.up * (impulse/3), ForceMode2D.Impulse);
                break;
            case "Left":
                rigidBody.AddForce(Vector2.right * impulse, ForceMode2D.Impulse);
                break;
            case "Right":
                rigidBody.AddForce(Vector2.left * impulse, ForceMode2D.Impulse);
                break;
            default:
                break;
        }

    }

    IEnumerator NullMove()
    {
        characterController.moveIsTrue = false;
        rigidBody.gravityScale = 0;

        yield return new WaitForSeconds(0.1f);

        characterController.moveIsTrue = true;
        rigidBody.gravityScale = 1;
    }

}