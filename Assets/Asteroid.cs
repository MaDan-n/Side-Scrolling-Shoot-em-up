using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //References
    //public SpriteRenderer spriteRender;
    public Rigidbody2D asteroidRigidBody;
    public List<GameObject> drop;

    //Spawn
    public List<Sprite> sprites;
    float size;
    float minSize = 0.5f;
    float maxSize = 1.5f;

    //Attributes
    public float speed;

    private void Start()
    {
        //Spawn attributes
        //spriteRender.sprite = sprites[Random.Range(0, sprites.Count)];
        size = Random.Range(minSize, maxSize);
        transform.localScale = Vector3.one * this.size;
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360.0f);

        //Give a velocity
        asteroidRigidBody.velocity = transform.position * -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("PowerUp"))
        {
            Debug.Log("OUCH! in Asteroid");

            //Drop
            GameObject itemToDrop = drop[Random.Range(0, drop.Count)];
            Instantiate(itemToDrop, transform.position, Quaternion.identity);

            gameObject.SetActive(false);
        }
    }
}
