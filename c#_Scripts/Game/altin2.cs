using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altin2 : MonoBehaviour
{

    oyuncu2 karekter;

    public Transform temas_kupu;

    float mesafe;

    void Start()
    {
        karekter = GameObject.Find("oyuncu2").GetComponent<oyuncu2>();

        temas_kupu = GameObject.Find("oyuncu2/temas_kupu").transform;

    }

    void Update()
    {
        if (karekter.miknatis_alindi == true)
        {
            mesafe = Vector3.Distance(transform.position, temas_kupu.position);

            if (mesafe <= 10)
            {
                transform.position = Vector3.MoveTowards(transform.position, temas_kupu.position, Time.deltaTime * 10.0f);

            }

        }

    }

}
