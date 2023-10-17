using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helperscript : MonoBehaviour
{
    LayerMask GroundLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        GroundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    
    }

   
    public bool DoRayCollisionCheck ()
    {
        float rayLength = 0.5f;
        bool green = false;
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, GroundLayerMask);

        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            print("Player hsa collided with Ground layer");
            hitColor = Color.green;
            green = true;   
        }
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
        return green;
    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f;
        bool hitSomething = false;

        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, GroundLayerMask);

        Color hitColor = Color.white;

        if(hit.collider != null)
        {
            print("Player has collided with the Ground layer");
            hitColor= Color.green;
            hitSomething = true;
        }

        Debug.DrawRay(transform.position + offset, -Vector2.up * rayLength, hitColor);
        return hitSomething;
    }

}
