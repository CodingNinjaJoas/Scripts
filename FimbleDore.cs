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
    public bool firstTime = true;
    public string intString;
    public bool dialoguePlayed = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerPrefs.GetInt(intString) == 0)
        {
            if (collision.transform.CompareTag("Player") == true)
            {
                if (dialoguePlayed == false)
                {
                    dialogue.SetActive(true);
                    dialoguePlayed = true;
                }
            }
            else
            {
                dialogue.SetActive(false);
            }
        }
    }
    public void Start()
    {

        if (PlayerPrefs.GetInt(intString)==1)
        {
            
            InvokeRepeating("loseFood", losefoodTime, losefoodTime);
            firstTime = true;
        }
        else
        {
            PlayerPrefs.SetInt(intString,0);
        }
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
        if(firstTime == false)
        {
            InvokeRepeating("loseFood", losefoodTime, losefoodTime);
            PlayerPrefs.SetInt(intString, 0);
            firstTime = true;
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
        
    }

}
