using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restartmanager : MonoBehaviour
{
    public Animator anim;
    public GameObject texts;
    public GameObject buttons;
    private void Start()
    {
        buttons.SetActive(false);
        anim.SetBool("Fadeout", true);
        Invoke("Anim",8);
    }
    private void Update()
    {
     
    }   
    void Anim()
    {
        anim.SetBool("Fade", true);
        StartCoroutine(EquipButtons());
    }
    public IEnumerator EquipButtons()
    {
        yield return new WaitForSeconds(0.5f);
        texts.SetActive(false);
        buttons.SetActive(true);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
