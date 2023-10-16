using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    Helperscript helper;
    bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        print("start");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Add the helper script and store a reference to it                                               
        helper = gameObject.AddComponent<Helperscript>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false);

        if (Input.GetKey("a") == true)
        {
            print("player pressed a");
            transform.position = new Vector2(transform.position.x +
            (-3.5f * Time.deltaTime), transform.position.y);
            anim.SetBool("walk", true);
            helper.FlipObject(true);
        }
        if (Input.GetKey("d") == true)
        {
            print("player pressed d");
            transform.position = new Vector2(transform.position.x +
            (3.5f * Time.deltaTime), transform.position.y);
            anim.SetBool("walk", true);
            helper.FlipObject(false);
        }
        grounded = helper.DoRayCollisionCheck(); 
        if (Input.GetKeyDown("space") == true && grounded == true)
        {
            print("player pressed space");
            rb.AddForce(new Vector3(0, 10.15f, 0), ForceMode2D.Impulse);
        }
    }
}
