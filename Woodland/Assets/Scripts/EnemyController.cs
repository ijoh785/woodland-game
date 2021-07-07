using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;
    Renderer r;

    void Start(){
        health = 200f;
        r = gameObject.GetComponent<Renderer>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "weapon"){

            float damage = col.gameObject.GetComponent<WeaponController>().damage;
            health -= damage;
            StartCoroutine(damageColor());
            Debug.Log(health+"/200");

            if (health <= 0){
                Destroy(gameObject);
            }
        }
    }

    IEnumerator damageColor(){
        r.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.3f);
        r.material.SetColor("_Color", Color.white);
    }
}
