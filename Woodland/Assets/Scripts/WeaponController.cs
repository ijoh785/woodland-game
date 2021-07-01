using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Enemy"){
            Debug.Log("Enemy hit");
        }
    }
}
