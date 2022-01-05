using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * https://www.youtube.com/watch?v=b8YUfee_pzc&t=288s 
 */

[RequireComponent(typeof(BoxCollider2D))]

public class Player : Mover
{
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }
}
