using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : MonoBehaviour
{

    [Header("Enemy")]
    [SerializeField] private float damage;
    [SerializeField] private float TimeBetweenDamage;
    private float TimeNextDamage;

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.CompareTag("Player")){

            TimeNextDamage -= Time.deltaTime;

            if (TimeNextDamage <= 0)
            {
                other.gameObject.GetComponent<PlayerUtils>().TakeDamage(damage);
                TimeNextDamage = TimeBetweenDamage;
            }

            
        }
 
    }
}
