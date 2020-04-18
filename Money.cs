using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public MoneyThrower m;
    public PlayerMovement p;
    private void Start()
    {
     
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player") == true)
        {
            m.currentMoney--;
            p.money++;
            Destroy(this.gameObject);
        }
    }
}
