using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator am;

    Vector2 movement;

    // Start is called before the first frame update
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        am.SetFloat("Horizontal", movement.x);
        am.SetFloat("Vertical", movement.y);
        am.SetFloat("Speed", movement.sqrMagnitude);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
