using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : MonoBehaviour
{
    //private CharacterController CharacterController;
    private Rigidbody2D RigidBody;
    private PlayerUtils Utils;
    

    [Header("Dash")]
    [SerializeField] private float VelocityDash;
    [SerializeField] private float TimeDash;
    private float GravityStart;
    private bool DashIsTrue = true;
    [SerializeField] private TrailRenderer TrailRenderer;
    public float dashDirection = 1;
    void Start()
    {
        Utils = GetComponent<PlayerUtils>();
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

        Utils.moveIsTrue = false;
        DashIsTrue = false;
        RigidBody.gravityScale = 0;
        RigidBody.velocity = new Vector2(VelocityDash * dashDirection, 0);
        TrailRenderer.emitting = true;

        yield return new WaitForSeconds(TimeDash);

        Utils.moveIsTrue = true;
        DashIsTrue = true;
        RigidBody.gravityScale = GravityStart;
        TrailRenderer.emitting = false;
    }
}
