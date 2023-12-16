using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    [Header("Direction")]
    public string direction;
    
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
            
        }else if (HorizontalMove > 0)
        {
            direction = "Right";
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
