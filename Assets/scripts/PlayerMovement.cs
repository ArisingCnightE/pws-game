using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement; 

    void Update()
    {   //hier word gekeken welke knop er wordt ingedrukt en als het of de pijltjes of WASD is wordt er een x of y aan toegevoegd
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator aangeven dat de x en y waardes ook gelijk zijn aan horizontale en verticale beweging. 
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        //als één van de knopjes word ingedrukt dan heeft de player "movespeed" en dus wordt hij verandert 
        //van de idle sprite naar de rennende sprite
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //hier wordt de player sprite ook echt verplaatst van plek op het scherm
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
