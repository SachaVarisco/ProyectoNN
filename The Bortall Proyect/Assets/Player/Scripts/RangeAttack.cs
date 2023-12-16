using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{

    [Header("Bullets")]
    [SerializeField] private Transform bulletController;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float reloadTime;
    [SerializeField] private float countdown;
    [SerializeField] private float bulletSpeed;
    private float moveX;
    private float moveY;

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
        GameObject bullet = Instantiate(bulletPrefab, bulletController.position, bulletController.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(NullMove());
        
       switch (Looking.direction)
        {
            case "Up":
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0 , 1 * bulletSpeed);
                rigidBody.AddForce(Vector2.down * (impulse/3), ForceMode2D.Impulse);
                break;
            case "Down":
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0 , -1 * bulletSpeed);
                rigidBody.AddForce(Vector2.up * (impulse/3), ForceMode2D.Impulse);
                break;
            case "Left":
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * bulletSpeed, 0);
                rigidBody.AddForce(Vector2.right * impulse, ForceMode2D.Impulse);
                break;
            case "Right":
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * bulletSpeed, 0);
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