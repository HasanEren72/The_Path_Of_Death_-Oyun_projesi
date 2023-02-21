using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Game_canvas_script : MonoBehaviour
{
    public AudioSource ses;

     void Start()
     {
       
     }


    void Update()
    {
        
    }
    public void Home()
    {
       
        oyuncu.puan = 0;
        oyuncu.toplanan_altin = 0;
        oyuncu.elmas = 0;


        SceneManager.LoadScene("Menu");

    }

    public void Exit_button()
    {
        Application.Quit();

        oyuncu.puan = 0;
        oyuncu.toplanan_altin = 0;
        oyuncu.elmas = 0;


    }
    public void ses_kapat()
    {
        if (ses.enabled == true)
        {
            ses.enabled = false;

        }
        else
        {
            ses.enabled = true;

        }


    }
}
