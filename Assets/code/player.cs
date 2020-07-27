using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float x_min, x_max, y_min, y_max;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalIput = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontalInput * speed, verticalIput * speed);
        //rb.AddForce(move);
        rb.MovePosition(move);
        rb.position=new Vector2(Mathf.Clamp(rb.position.x, x_min, x_max), Mathf.Clamp(rb.position.y, x_min, x_max));
        //rb.position = new Vector2();
    }
}
