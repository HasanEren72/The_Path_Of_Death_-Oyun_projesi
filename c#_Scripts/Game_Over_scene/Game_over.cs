using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over : MonoBehaviour
{
    oyuncu  playerController;

    AudioSource audioSource;

    [SerializeField]
    private AudioClip gameOverSesi;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.PlayOneShot(gameOverSesi); //1 kez gameOverSesi çalacak
        audioSource.Play();   //Sahne Sesi Calar 
    }

    public void elmas_Kullan()
    {    
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game_Scene");
    }  

    public void Home()
    {
        SceneManager.LoadScene("Menu");

        PlayerPrefs.DeleteKey("puan_verisi");
        PlayerPrefs.DeleteKey("altin_sayisi_verisi");
        PlayerPrefs.DeleteKey("elmas_verisi");
    }

    public void Restart_button()
    {
        PlayerPrefs.DeleteKey("puan_verisi");
        PlayerPrefs.DeleteKey("altin_sayisi_verisi");
        PlayerPrefs.DeleteKey("elmas_verisi");

        if (Menu_paneli.bolum1==true)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("bolum1");
        }
        else
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("bolum2");
        }             
    }

    public void Exit_button()
    {
        PlayerPrefs.DeleteKey("puan_verisi");
        PlayerPrefs.DeleteKey("altin_sayisi_verisi");
        PlayerPrefs.DeleteKey("elmas_verisi");
        Application.Quit();
    }
}