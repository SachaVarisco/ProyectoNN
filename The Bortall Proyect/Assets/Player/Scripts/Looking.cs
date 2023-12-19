using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    [Header("Dash")]
    private DashPlayer DashPlayer;

    [Header("Direction")]
    public string direction;
    
    private void Start(){
        DashPlayer = GetComponent<DashPlayer>();
    }
    void Update()
    {
        CharacterView();
    }

    private void CharacterView(){
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");

        if (HorizontalMove < 0)
        {
            direction = "Left";
            DashPlayer.dashDirection = -1f;
            
        }else if (HorizontalMove > 0)
        {
            direction = "Right";
            DashPlayer.dashDirection = 1f;
        }
        if (VerticalMove < 0)
        {
            direction = "Down";

        }else if (VerticalMove > 0)
        {
            direction = "Up";
        }
    }
}
