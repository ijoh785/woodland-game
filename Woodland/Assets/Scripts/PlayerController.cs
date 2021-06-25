using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator anim;
    public int speed = 100;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            anim.SetBool("running", true);
            if (!facingRight) {
                Flip();
            }

        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) anim.SetBool("running", false);

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            anim.SetBool("running", true);
            if (facingRight) {
                Flip();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) anim.SetBool("running", false);

        if (Input.GetKeyDown(KeyCode.UpArrow)) anim.SetBool("jumping", true);
        if (Input.GetKeyUp(KeyCode.UpArrow)) anim.SetBool("jumping", false);
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
}
