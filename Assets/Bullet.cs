using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //References
    public Rigidbody2D bulletRigidBody;
    public AudioSource shotSound, destroySound;

    //Attributes
    public float speed;

    private void Start()
    {
        bulletRigidBody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("PowerUp"))
            gameObject.SetActive(false);
    }
}
