using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float movespeed = 500f;
    public Detectionzon detectionzon;

    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // Add a reference to the SpriteRenderer component.

    public float Health
    {
        set
        {
            _health = value;

            if(_health <= 0)
            {
                Destroy(gameObject);
            }
        }
        get
        {
            return _health;
        }
    }

    public float _health = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (detectionzon != null && detectionzon.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionzon.detectedObjs[0].transform.position - transform.position).normalized;

            rb.AddForce(direction * movespeed * Time.deltaTime);

            // Flip the sprite based on the movement direction.
            if (direction.x > 0)
            {
                // If moving right, set the sprite's local scale to its original state.
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                // If moving left, flip the sprite horizontally.
                spriteRenderer.flipX = true;
            }
        }
    }
    void OnHit(float damage)
    {
        Debug.Log("Ghost hit for " + damage);
       Health -= damage;
    }
  
}
