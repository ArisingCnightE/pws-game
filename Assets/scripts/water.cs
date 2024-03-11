using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class water : MonoBehaviour
{
  private inventorymanager im;
  private void Start ()
  {
    im = GameObject.Find("Canvas").GetComponent<inventorymanager>();
  }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.collider.gameObject.CompareTag("Player"))
        {
          im.addwater();
        } 
    }
}
