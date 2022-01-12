using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol: Collidable
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    private void Awake()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }
    protected override void Update()
    {
        base.Update();

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name != "Player")
        {
            return;
        }

        // Teleporting mechanism here
        else if (coll.name == "Player")
        {
            Debug.Log("You're being teleported!");
            GameManager.instance.SaveState();
            coll.gameObject.transform.position = new Vector3(0.445f, 0.822f, 0);
            GameManager.instance.ShowText("Watch your steps!", 25, Color.white, transform.position + GetComponent<BoxCollider2D>().bounds.extents, Vector3.zero, 4.0f);
        }

        else
        {
            Debug.LogError("InGameReplacer::OnCollide(...) => NOT IMPLEMENTED YET");
        }
    }
}
