using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;
    Renderer r;

    void Start(){
        health = 200;
        r = gameObject.GetComponent<Renderer>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "weapon"){

            int damage = col.gameObject.GetComponent<WeaponController>().damage;
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
