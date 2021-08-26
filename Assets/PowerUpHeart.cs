using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeart : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            player.hp++;
            gameObject.SetActive(false);
        }
    }
}
