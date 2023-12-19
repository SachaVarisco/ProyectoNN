using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour
{
    [SerializeField] private float Life;
    [SerializeField] private float LifeMax;

    [SerializeField] private LifeBar LifeBar;
    private void Start()
    {
        Life = LifeMax;
        LifeBar.StartLifeBar(Life);
    }

    public void TakeDamage(float damage){
        Life -= damage;
        LifeBar.ChangeHPActual(Life);

        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }

   
    void Update()
    {
        
    }
}
