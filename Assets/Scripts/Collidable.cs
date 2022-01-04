using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    // Start is called before the first frame update
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            // Debug.Log(hits[i].name); // For testing puspose only.
            OnCollide(hits[i]);

            // Since the array is not cleaned up by itself, we do it ourself
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}
