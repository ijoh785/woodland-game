using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rb;
    public ParticleSystem dirtEffect;
    public float speed;
    public float jump_force = 500f;
    private bool facingRight = true;
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Initialise transform. Particle effects dont start without this for some reason?
        Vector2 scale = transform.localScale;
        scale.x *= 1;
        transform.localScale = scale;

        speed = 30f;
        dirtEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Handles right arrow animations
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) { // If right arrow is being pressed
            anim.SetBool("running", true);
            if(!dirtEffect.isPlaying && !anim.GetBool("jumping")) dirtEffect.Play();
            if (!facingRight) {
                Flip();
            }

        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)){
            anim.SetBool("running", false); // If right arrow has been lifted
            if(dirtEffect.isPlaying) dirtEffect.Stop();
        } 

        // Handles left arrow animations
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) { // If left arrow is being pressed
            anim.SetBool("running", true);
            if(!dirtEffect.isPlaying && !anim.GetBool("jumping")) dirtEffect.Play();
            if (facingRight) {
                Flip();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            anim.SetBool("jumping", true);
        }

        // Handles attack animations
        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetBool("attacking", true);
            if(anim.GetBool("running")){
                speed /= 2;
            }
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
            anim.SetBool("falling", false);
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "ground"){
            if(dirtEffect.isPlaying) dirtEffect.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "damage zone"){
            currentHealth -= 10f;
            Debug.Log(currentHealth + "/" + maxHealth);
        }
    }

    void Jump(){
        rb.AddForce(transform.up*jump_force);
    }

    void EndAttack(){
        anim.SetBool("attacking", false);
        speed = 30f;
    }

}
