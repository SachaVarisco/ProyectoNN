using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 Min;
    [SerializeField] private Vector2 Max;
    [SerializeField] private float Smoothing;
    [SerializeField] private Vector2 Velocity;
    private GameObject Player;
    private void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        
        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref Velocity.x, Smoothing);
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref Velocity.y, Smoothing);

        transform.position = new Vector3(Mathf.Clamp(posX,Min.x,Max.x), Mathf.Clamp(posY,Min.y,Max.y), transform.position.z);
    }
}