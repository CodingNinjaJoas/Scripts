using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FimbleDore : MonoBehaviour
{
    public float health;
    public float food;
    public GameObject foodNeededPicture;
    public GameObject dialogue;
    public float losefoodTime;
    public bool loseFoodBool = true;
    public string intString;
    public bool dialoguePlayed = false;
    int firstRun = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerPrefs.GetInt(intString)==0)
        {
            if (collision.transform.CompareTag("Player") == true)
            {


                dialogue.SetActive(true);
                PlayerPrefs.SetInt(intString, 1);

            }
            else
            {
                dialogue.SetActive(false);
            }
        }
    }
    public void Start()
    {
        
    }

    public void Update()
    {
        if (food <= 1)
        {
            foodNeededPicture.SetActive(true);
        }
        else
        {

            foodNeededPicture.SetActive(false);

        }
        if(health <= 0)
        {
            Die();
        }
        if(loseFoodBool == false)
        {
            InvokeRepeating("loseFood", losefoodTime, losefoodTime);
        
            loseFoodBool = true;
        }
    }
    public void loseFood()
    {
        if(food > 0)
        {
            food--;
        }
        else
        {
            health--;
        }
    }
    void Die()
    {
        Debug.Log("Fimble died man");
    }

}
