using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerawarenescontroller : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;
    private inventorymanager im;
    private Rigidbody2D _rigidbody;
    public Animator animator;
    Vector2 movement; 

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        im = GameObject.Find("Canvas").GetComponent<inventorymanager>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
        movement = _rigidbody.velocity;
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

    }
    private void FixedUpdate()
    {
        if(AwareOfPlayer)
        {
            _rigidbody.AddForce (DirectionToPlayer * 15);
            

        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.collider.gameObject.CompareTag("Player"))
      {
        im.RemoveWater();
      }
    }
}
