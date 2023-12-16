using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float Life;
    [SerializeField] private float LifeMax;

    private void Start()
    {
        Life = LifeMax;
        //LifeBar.StartLifeBar(Life);
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;

        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }
}