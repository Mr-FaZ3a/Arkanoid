using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racket : MonoBehaviour
{
    public int speed = 5;
    // Start is called before the first frame update
    
    void Start()
    {
        Debug.Log(GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    {   

        float move = Input.GetAxisRaw("Horizontal") * speed;
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        Debug.Log(Input.GetAxis("Horizontal"));
        GetComponent<Rigidbody2D>().velocity = Vector2.right * move;
        // GetComponent<Rigidbody2D>().AddForce(Vector2.left*(move - 50));
        
    }
    void FixedUpdate()
    {
        // GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
}

