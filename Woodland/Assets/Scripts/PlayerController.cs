using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rb;
    public float speed = 100f;
    public float jump_force = 500f;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hanles right arrow animations
        if (Input.GetKey(KeyCode.RightArrow)) { // If right arrow is being pressed
            anim.SetBool("running", true);
            if (!facingRight) {
                Flip();
            }

        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) anim.SetBool("running", false); // If right arrow has been lifted

        // Handles left arrow animations
        if (Input.GetKey(KeyCode.LeftArrow)) { // If left arrow is being pressed
            anim.SetBool("running", true);
            if (facingRight) {
                Flip();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) anim.SetBool("running", false); // If left arrow has been lifted

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            anim.SetBool("jumping", true);
        }
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        float horizontal = Input.GetAxis("Horizontal");
        position.x = position.x + speed * horizontal * Time.deltaTime;
        transform.position = position;
        
    }

    void Flip(){
        facingRight = !facingRight;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "ground"){
            anim.SetBool("jumping", false);
        }
    }

    void Jump(){
        rb.AddForce(transform.up*jump_force);
    }
}
