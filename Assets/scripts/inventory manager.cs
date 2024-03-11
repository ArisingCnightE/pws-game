using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inventorymanager : MonoBehaviour
{
    public TMP_Text textScore;
    public bool HasWater => hasWater;
    private bool hasWater = false;
   

    // Start is called before the first frame updates
    void Start()
    {
        textScore.text = "inventory:";
    }

    public void addwater()
    {
        hasWater = true;
        textScore.text = "inventory:\nwater";
    }
    public void RemoveWater()
    {
        hasWater = false;
        textScore.text = "inventory:";
    }
}
