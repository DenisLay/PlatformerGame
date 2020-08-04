using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;


    private Rigidbody2D rigidbody;
    private bool inAir;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(direction, 0).normalized * moveSpeed);
        
        if (Input.GetKey(KeyCode.Space) && !inAir)
        {
            inAir = true;
            rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void OnColissionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Ground")
        {
            inAir = false;
        }

        Debug.Log(collision.gameObject.name);
    }
}
