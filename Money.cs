﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public MoneyThrower m;
    public PlayerMovement p;
    public bool moneyT;
    private void Start()
    {
     
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player") == true)
        {
            if (moneyT == true)
            {
                m.currentMoney--;
            }
            FindObjectOfType<PlayerMovement>().money++;
            Destroy(this.gameObject);
        }
    }
}
