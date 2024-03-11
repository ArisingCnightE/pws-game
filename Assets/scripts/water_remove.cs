using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;
using System.Net.Mail;
using Unity.VisualScripting;

public class water_remove : MonoBehaviour
{
    private inventorymanager im;
    public TMP_Text basewater;
    int watercount = 0;

    public GameObject enemyObject;
    private void Start()
    {
        im = GameObject.Find("Canvas").GetComponent<inventorymanager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (im.HasWater)
        {
            watercount++;

            im.RemoveWater();
            spawnEnemy();
            if (watercount >= 2f)
            {
                prestige();
            }
            else
            {
                normal();
            }
        }
    }

    private void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemyObject) as GameObject;
        enemy.transform.position = new Vector2(Random.Range(-14.4f, 11.8f), Random.Range(-6.5f, 6));
    }
    private void prestige()
    {
        basewater.text = "<color=#FFD700>basewater:" + watercount;
        spawnEnemy();
    }
    private void normal()
    {
        basewater.text = "basewater: " + watercount;
    }
}