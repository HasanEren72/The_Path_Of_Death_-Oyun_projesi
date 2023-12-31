using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karekter_islemleri : MonoBehaviour
{
    [SerializeField]
    private GameObject oyuncu1, oyuncu2, oyuncu3;

    [SerializeField]
    private bool karekter1, karekter2, karekter3;

    void Start()
    {
        karekter1 = Menu_paneli.karekter1_buy;
        karekter2 = Menu_paneli.karekter2_buy;
        karekter3 = Menu_paneli.karekter3_buy;

        if (karekter1 == true)
        {
            oyuncu1.SetActive(true);
            oyuncu2.SetActive(false);
            oyuncu3.SetActive(false);
        }
        if (karekter2 == true)
        {
            oyuncu2.SetActive(true);
            oyuncu1.SetActive(false);          
            oyuncu3.SetActive(false);
        }
        if(karekter3 == true)
        {
            oyuncu3.SetActive(true);
            oyuncu1.SetActive(false);
            oyuncu2.SetActive(false);
        }
        else
        {
            
        }
    }
}
