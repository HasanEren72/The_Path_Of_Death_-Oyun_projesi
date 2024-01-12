using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private GameObject Karakter;  // [Serializefield]  kullanman�n nedeni private eri�ilemez de�i�keni inspector panelinde kullanablmektir

    Animator karakterAnimator;

    void Start()
    {
        karakterAnimator =GetComponent<Animator>();
    }
    
    void Update()
    {
        Ziplama();
        Kayma();
        dusme();
    }
    void Ziplama()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            karakterAnimator.SetTrigger("Z�PLA");
        }
    }
    void Kayma()
    {
        if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
            karakterAnimator.SetTrigger("KAYMA");
        }
    }

    void dusme()
    {
        if (Input.GetKey(KeyCode.G))
        {
            karakterAnimator.SetTrigger("DUSME");
        }
    }
}
