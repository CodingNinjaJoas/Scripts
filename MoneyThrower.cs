using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyThrower : MonoBehaviour
{
    public float throwSpeed;
    public float maximumMoney;
    public GameObject money;
    public float currentMoney;
    public float maxX;
    public float minX;
    private void Start()
    {
        InvokeRepeating("ThrowMoney",throwSpeed,throwSpeed);
    }
    void ThrowMoney()
    {
        if(currentMoney >= maximumMoney)
        {
            return;
        }
        else
        {
            GameObject g =Instantiate(money,this.transform);
            Vector3 v =new Vector3(UnityEngine.Random.Range(minX,maxX),this.transform.position.y,this.transform.position.z);
            g.transform.position = v;
            g.GetComponent<Money>().m = this;

            currentMoney++;
        }
    }
}
