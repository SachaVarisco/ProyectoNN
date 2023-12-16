using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform[] WayPoints;
    [SerializeField]private float Speed;
    [SerializeField] private float MinDistance;
    [SerializeField] private bool LookLeft = true;
    private int RandNum;
    private float VelocityX;
    private Vector3 PrevPosition;
    // Start is called before the first frame update
    void Start()
    {
        RandNum = Random.Range(0,WayPoints.Length);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[RandNum].position, Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, WayPoints[RandNum].position) < MinDistance)
        {
            RandNum = Random.Range(0,WayPoints.Length);
        } 
    }
    private void FixedUpdate() 
    {
        
        CalcSpeed();
        if (VelocityX > 0 && LookLeft) 
        {
            RotateX(); 
        }
        if (VelocityX < 0 && !LookLeft)
        {
            RotateX(); 
        }
    }
    private float CalcSpeed()
    {
        Vector3 currentPosition = transform.position;
        float deltaTime = Time.deltaTime;

        VelocityX = (currentPosition.x - PrevPosition.x) / deltaTime;

        PrevPosition = currentPosition;

        return VelocityX;
    }
    private void RotateX()
    {
        LookLeft = !LookLeft;
        transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
    }
    /*public void OnCollisionEnter2D(Collision2D other)
   {
     if (other.gameObject.tag == "Player"){
          other.gameObject.GetComponent<PLayerLifeControl>().TakeDamage(other.GetContact(0).normal);
        }
   }*/
}