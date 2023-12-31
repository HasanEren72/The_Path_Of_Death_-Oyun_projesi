using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Game_canvas_script : MonoBehaviour
{   
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip OyunBaslangicSesi;

    private AudioSource[] tumSesler;

    bool sesCalsinmi;

    private void Awake()
    {
        tumSesler = Object.FindObjectsOfType<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = OyunBaslangicSesi;
        audioSource.loop = true;           
    }

    private void Start()
    {
        sesCalsinmi = false;
        audioSource.Play();
    }
    
    public void Home()
    {       
        oyuncu.puan = 0;
        oyuncu.altin = 0;
        oyuncu.elmas = 0;
        SceneManager.LoadScene("Menu");
    }

    public void Exit_button()
    {
        Application.Quit();
        oyuncu.puan = 0;
        oyuncu.altin = 0;
        oyuncu.elmas = 0;
    }

    public void ses_kapat()
    {
        if (!sesCalsinmi)
        {
            foreach (var item in tumSesler)
            {
                item.Stop();
            }
        }
        else
        {
            foreach (var item in tumSesler)
            {
                item.Play();
            }
        }
        sesCalsinmi = !sesCalsinmi;
    }
}
