using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdater : MonoBehaviour
{
    public Text foodT;
    public Text moneyT;
    public List<GameObject> hearts = new List<GameObject>();
    public float localHealth;
    public PlayerMovement player;
    public void Update()
    {
        moneyT.text = ""+player.money;
        foodT.text = "" + player.food;

        localHealth = player.health;
        if (localHealth <= 0)
        {
            player.Die();
            return;
        }
        foreach(GameObject h in hearts)
        {
            if(hearts.IndexOf(h)>= localHealth)
            {
                h.SetActive(false);
            }
            else
            {
                h.SetActive(true);
            }
        }
    }
}
