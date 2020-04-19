using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerMovement p;
    public List<float> upsBought = new List<float>();
    public List<float> maxUps = new List<float>();
    public List<float> cost = new List<float>();
    public List<int> index = new List<int>();
    public void Up(int i)
    {
        if (upsBought[i] >= maxUps[i])
        {
            return;
        }
        else
        {

            if (p.money >= cost[i])
            {
                upsBought[i]++;
                if (index[i] == 0)
                {
                    p.speed++;
                }
                if (index[i] == 1)
                {
                    p.jumpForce++;
                }
                if (index[i] == 2)
                {
                    p.damage++;
                }
                if (index[i] == 3)
                {

                }
                if (index[i] == 4)
                {

                }
                if (index[i] == 5)
                {

                }
                  
                p.money -= cost[i];
            } 
        }
    }
    void Update()
    {
        
    }
}
