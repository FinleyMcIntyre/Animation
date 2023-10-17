using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Helperscript helper;
    bool left;
    bool right;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<Helperscript>();
        speed = 1.5f;
 
    }

    // Update is called once per frame

    void Update()
    {
        left = helper.ExtendedRayCollisionCheck(-0.75f,0);
        right = helper.ExtendedRayCollisionCheck(0.75f, 0);
        if (right == false && (speed > 0))
        {
            speed = -1.5f;
            helper.FlipObject(true);


        }
        if (left == false && (speed < 0))
        {
            speed = 1.5f;
            helper.FlipObject(false);
        }
        transform.position = new Vector2(transform.position.x +
            (speed * Time.deltaTime), transform.position.y);
        


        print("speed=" + speed);



    }
}

