using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Input System References
    public PlayerInputActions playerInput;
    InputAction moveAction;

    //Shooting references
    public Transform firePoint;
    public GameObject equippedProjectilePrefab;

    //Attributes
    public float moveSpeed;
    bool isShooting = false;
    public int hp; 

    private void Awake()
    {
        playerInput = new PlayerInputActions();
        moveAction = playerInput.Player.Move;
        playerInput.Player.Fire.performed += ctx => OnFire();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void Update()
    {
        OnMove();
    }

    private void OnMove()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * moveSpeed * Time.deltaTime;
    }

    private void OnFire()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
        }

        else
            Debug.Log("Bullet No Available");
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