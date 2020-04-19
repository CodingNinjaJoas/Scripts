using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Animator fadeIn;
    public GameObject main;
    public GameObject options;
    public GameObject quit;
    public float musicVolume;
    public Slider musicVolS;
    public Text musicD;

    public void Update()
    {

        musicVolume = musicVolS.value;
        musicD.text = "" + musicVolume;
        PlayerPrefs.SetFloat("musicVol", musicVolume);
    }
    public void OpenMain()
    {
        StartCoroutine(Fade(false,false,true));
        fadeIn.SetBool("Fade", true);
        Invoke("Disable",1);
    }
    public void OpenOptions()
    {
        StartCoroutine(Fade(true, false, false));
        fadeIn.SetBool("Fade", true);
        Invoke("Disable", 1);
    }
    public void OpenQuit()
    {
        StartCoroutine(Fade(false, true, false));
        fadeIn.SetBool("Fade", true);
        Invoke("Disable", 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartClicked()
    {
        SceneManager.LoadScene(1);
    }
    public IEnumerator Fade(bool a,bool b, bool c)
    {
        yield return new WaitForSeconds(0.5f);
        options.SetActive(a);
        quit.SetActive(b);
        main.SetActive(c);
    }
    private void Disable()
    {
        fadeIn.SetBool("Fade", false);
    }
}
