using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        print("start");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        }
        if (Input.GetKey("d") == true)
        {
            print("player pressed d");
            transform.position = new Vector2(transform.position.x +
            (3.5f * Time.deltaTime), transform.position.y);
            anim.SetBool("walk", true);
        }

       if (Input.GetKey("space") == true)
        {
            print("player pressed space");
            rb.AddForce(new Vector3(0, 0.25f, 0), ForceMode2D.Impulse);
        }
    }
}
