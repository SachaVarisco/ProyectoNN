using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float lifeTime;

    private void Awake() 
    {
        speed = 20f;
        damage = 30f;    
        lifeTime = 0.3f;
    }

    private void Update() 
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); 

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }     
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("triggereo");
        
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().TakeDamage(damage);
        }    

        Destroy(gameObject);
    }

}
