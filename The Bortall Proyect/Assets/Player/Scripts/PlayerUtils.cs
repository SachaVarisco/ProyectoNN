using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtils : MonoBehaviour
{
    [Header("Stats")]

    public float speed;
    public bool moveIsTrue = true;
    public float impulse;
    public float Life;
    public float LifeMax;
    public LifeBar LifeBar;
    
    private void Start()
    {
        Life = LifeMax;
        //LifeBar.StartLifeBar(Life);
    }

    public void TakeDamage(float damage){
        Life -= damage;
        LifeBar.ChangeHPActual(Life);

        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
