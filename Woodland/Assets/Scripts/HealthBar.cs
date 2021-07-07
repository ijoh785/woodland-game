using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    PlayerController player;
    float maxHealth;
    float currentHealth;
    float maxScale;
    Vector2 scale;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        maxHealth = player.maxHealth;
        currentHealth = player.currentHealth;
        maxScale = 0.7f;

        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.currentHealth;

        scale.x = maxScale * (currentHealth/maxHealth);
        transform.localScale = scale;
    }
}
