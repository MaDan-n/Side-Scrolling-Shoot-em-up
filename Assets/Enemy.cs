using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Shooting references
    public Transform firePoint;
    public GameObject equippedProjectilePrefab;
    public Rigidbody2D enemyRigiBody;

    //Attributes
    public float moveSpeed;
    public int hp;

    private void Start()
    {
        enemyRigiBody.velocity = new Vector2(-moveSpeed, 0);
        StartCoroutine("OnFire");
    }

    IEnumerator OnFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            GameObject enemyBullet = Instantiate(equippedProjectilePrefab, firePoint);
        }
    }

    public void ReceiveDamage(int _damage)
    {
        hp -= _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.CompareTag("PowerUp"))
        {
            Debug.Log("OUCH!");
            hp--;
        }
    }
}
