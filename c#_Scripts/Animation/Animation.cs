using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private GameObject Karakter;
    Animator karakterAnimasyon;
    void Start()
    {
        karakterAnimasyon = Karakter.GetComponent<Animator>();
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
            karakterAnimasyon.SetTrigger("ZÝPLA");
        }
    }
    void Kayma()
    {
        if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
            karakterAnimasyon.SetTrigger("KAYMA");
        }
    }

    void dusme()
    {
        if (Input.GetKey(KeyCode.G))
        {
            karakterAnimasyon.SetTrigger("DUSME");
        }
      


    }


}
