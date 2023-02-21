using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over : MonoBehaviour
{

    oyuncu  playerController;
    public oyuncu degisken;
   

    public void elmas_Kullan()
    {
        degisken.Kalinan_YerdebBaslat();
        //playerController.Kalinan_YerdebBaslat();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game_Scene");
    }
    

    void Update()
    {
        
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
            SceneManager.LoadScene("Game_Scene");

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