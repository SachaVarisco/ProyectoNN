using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : MonoBehaviour
{
    private CharacterController characterController;
    private Rigidbody2D RigidBody;
    

    [Header("Dash")]
    [SerializeField] private float VelocityDash;
    [SerializeField] private float TimeDash;
    private float GravityStart;
    private bool DashIsTrue = true;
    [SerializeField] private TrailRenderer TrailRenderer;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        RigidBody = GetComponent<Rigidbody2D>();
        GravityStart = RigidBody.gravityScale;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && DashIsTrue){

            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash(){

        characterController.moveIsTrue = false;
        DashIsTrue = false;
        RigidBody.gravityScale = 0;
        RigidBody.velocity = new Vector2(VelocityDash * transform.localScale.x, 0);
        TrailRenderer.emitting = true;

        yield return new WaitForSeconds(TimeDash);

        characterController.moveIsTrue = true;
        DashIsTrue = true;
        RigidBody.gravityScale = GravityStart;
        TrailRenderer.emitting = false;
    }
}
