using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    //public float fireBallSpeed = 2.5f; // For single fireBall
    //public Transform fireBall; // For single fireBall

    public float[] fireBallsSpeed = { 2.5f, -2.5f };
    public Transform[] fireBalls;

    public float distance = 0.25f;
    private void Update()
    {
        //fireBall.position = transform.position + new Vector3(-Mathf.Cos(Time.time * fireBallSpeed) * distance, Mathf.Sin(Time.time * fireBallSpeed) * distance, 0); // For single fireBall

        for (int i = 0; i < fireBalls.Length; i++)
        {
            fireBalls[i].position = transform.position +
                                        new Vector3(
                                                    -Mathf.Cos(Time.time * fireBallsSpeed[i]) * distance,
                                                    -Mathf.Sin(Time.time * fireBallsSpeed[i]) * distance,
                                                    0
                                            );
        }
    }
}
