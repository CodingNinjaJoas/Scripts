using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FimbleDore : MonoBehaviour
{
    public float health;
    public float food;
    public float baseFood;
    public GameObject foodNeededPicture;
    public GameObject outline;
    public GameObject dialogue;
    public GameObject pressEText;
    public float losefoodTime;
    public bool loseFoodBool = true;
    public string intString;
    public bool dialoguePlayed = false;
    public PlayerMovement p;
    public Color color;
    public IEnumerator GotHit()
    {
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.2f);
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
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
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") == true)
        {
            if (food <= 0 && p.food >0)
            {
                outline.SetActive(true);
                pressEText.SetActive(true);
         
            }
        }
        else
        {
            pressEText.SetActive(false);
            outline.SetActive(false);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        pressEText.SetActive(false);
        outline.SetActive(false);
    }
    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (p.food > 0)
            {
                food +=baseFood;
                p.food--;
            }
        }
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
