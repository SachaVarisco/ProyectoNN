using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float lifeTime;

    private void Awake() 
    {
        damage = 30f;    
        lifeTime = 0.1f;
    }

    private void Update() 
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }     
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().TakeDamage(damage);
        }    

        Destroy(gameObject);
    }

}
