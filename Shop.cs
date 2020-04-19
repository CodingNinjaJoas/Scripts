using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public bool gamePause;
    public GameObject shopUI;
    public GameObject coreUI;
    public GameObject interactionUI;
    public PlayerMovement p;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true && gamePause == false)
        {
            interactionUI.SetActive(true);
        }
        if (collision.CompareTag("Player") == true && Input.GetKeyDown(KeyCode.E))
        {
            shopUI.SetActive(!shopUI.activeSelf);
            coreUI.SetActive(!coreUI.activeSelf);
            gamePause = true;
            interactionUI.SetActive(false);
        }
    }
    public void Update()
    {
        p.gamePause = gamePause;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopUI.SetActive(false);
            coreUI.SetActive(true);
            gamePause = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            gamePause = false;
            shopUI.SetActive(false);
            coreUI.SetActive(true);
            interactionUI.SetActive(false);
        }
    }
}
