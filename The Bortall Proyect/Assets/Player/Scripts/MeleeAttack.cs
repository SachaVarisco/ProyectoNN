
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    [Header("Attack")]
    [SerializeField] private Transform MeleeController;
    [SerializeField] private float MeleeRadius;
    [SerializeField] private float MeleeDamage;
    

    [Header("CoolDown")]
    [SerializeField] private float Cooldown;
    [SerializeField] private float TimeNextAttack;

    [Header("Watch")]
    private Looking Looking;
    private Vector3 MeleePosition;
    private void Start() 
    {
        Looking = GetComponent<Looking>();
        SpriteRenderer = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update() 
    {
        if (Input.GetButtonDown("Fire1") && TimeNextAttack <= 0)
        {
            Attack();
            TimeNextAttack = Cooldown;
        }
    }
    private void FixedUpdate() 
    {
        if(TimeNextAttack > 0)
        {
            TimeNextAttack -= Time.deltaTime;
        }
    }
    private void Attack()
    {
        ChangePosition();
        StartCoroutine(Alpha());
        Collider2D[] objects = Physics2D.OverlapCircleAll(MeleeController.position, MeleeRadius);

        foreach (Collider2D collider in objects)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<EnemyStats>().TakeDamage(MeleeDamage);
            }
        }
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(MeleeController.position, MeleeRadius);
    }

    private IEnumerator Alpha()
    {
        SpriteRenderer.color = new Color(255f, 146f, 0f, 0.45f);
        yield return new WaitForSeconds(0.05f);
        SpriteRenderer.color = new Color(255f, 146f, 0f, 0f);
    }

    private void ChangePosition()
    {
        switch (Looking.direction)
        {
            case "Up":
                MeleeController.position = transform.position + new Vector3(0f, 1.5f, 0f);
                break;
            case "Down":
                MeleeController.position = transform.position + new Vector3(0f, -1.5f, 0f);
                break;
            case "Left":
                MeleeController.position = transform.position + new Vector3(-1.5f, 0f, 0f);
                break;
            case "Right":
                MeleeController.position = transform.position + new Vector3(1.5f, 0f, 0f);
                break;
            default:
                break;
        }
    }
}
