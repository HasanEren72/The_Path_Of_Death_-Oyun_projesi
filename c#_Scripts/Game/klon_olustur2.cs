using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klon_olustur2 : MonoBehaviour
{
    [SerializeField]  private GameObject altin, tas, kutuk, miknatis;
    [SerializeField] private GameObject kalkan, hiz_nesnesi, elmas, cit_engel;
    [SerializeField]  public Transform oyuncuT;
    float silme_zamani = 5.0f;
    float sag_x_kardinat = 1.07f;
    float sol_x_kordinat = -1.9f;

    [SerializeField]
    private GameObject[] nesneX;

    private BoxCollider[] collider;

    void Start()
    {
        InvokeRepeating("nesne_klonla_fonk", 0, 0.5f); //5 saniye aral�klarla tekrar tekrar nesne klonla fonksiyonunu �a��r�r

        collider = new BoxCollider[nesneX.Length];
        for (int i = 0; i < nesneX.Length; i++)
        {
            collider[i] = nesneX[i].GetComponent<BoxCollider>();
        }

        nesneX = GameObject.FindGameObjectsWithTag("engel");
    }

    void nesne_klonla_fonk()
    {
        int rastgele_sayi = Random.Range(0, 100);

        if (rastgele_sayi > 0 && rastgele_sayi < 55)
        {
            klonla(altin, 2.0f);
        }
        if (rastgele_sayi > 55 && rastgele_sayi < 60)
        {
            klonla(elmas, 2.0f);
        }
        if (rastgele_sayi > 60 && rastgele_sayi < 65)
        {
            klonla(cit_engel, 0.6f);
        }
        if (rastgele_sayi > 65 && rastgele_sayi < 70)
        {
            if (oyuncuT.gameObject.GetComponent<oyuncu2>().hiz_nesnesi_alindi == false && oyuncuT.gameObject.GetComponent<oyuncu2>().kalkan_alindi == false)
            {
                klonla(hiz_nesnesi, 2.0f);
            }
        }
        if (rastgele_sayi > 70 && rastgele_sayi < 75)
        {
            if (oyuncuT.gameObject.GetComponent<oyuncu2>().kalkan_alindi == false && oyuncuT.gameObject.GetComponent<oyuncu2>().hiz_nesnesi_alindi == false)
            {
                klonla(kalkan, 1.6f);
            }
        }

        if (rastgele_sayi > 75 && rastgele_sayi < 80)
        {
            klonla(kutuk, 0.6f);
        }
        if (rastgele_sayi > 80 && rastgele_sayi < 85)
        {
            klonla(tas, 0.6f);
        }
        if (rastgele_sayi > 85 && rastgele_sayi < 90)
        {
            if (oyuncuT.gameObject.GetComponent<oyuncu2>().miknatis_alindi == false)
            {
                klonla(miknatis, 2.0f);
            }
        }
        if (rastgele_sayi > 90 && rastgele_sayi < 100)
        {
            klonla(altin, 2.0f);
        }
    }


    void klonla(GameObject nesne, float y_kordinat)
    {
        GameObject yeni_klon = Instantiate(nesne); // bu nesne yi yeni klon nesnesine y�kledik

        int rastsayi = Random.Range(0, 100);

        if (nesne == kutuk || nesne == tas)
        {
            if (oyuncu2.boxcolider_aktiflik == false)
            {
                yeni_klon.GetComponent<BoxCollider>().enabled = false;

                for (int i = 0; i < collider.Length; i++)  //bursa� �al��m�yor
                {
                    collider[i].GetComponent<BoxCollider>().enabled = false;
                    Debug.Log("deger dondu" + oyuncu2.boxcolider_aktiflik);
                }


                if (rastsayi > 50)
                {
                    yeni_klon.transform.position = new Vector3(sag_x_kardinat, y_kordinat, oyuncuT.position.z + 10.0f);
                }
                if (rastsayi < 50)
                {
                    yeni_klon.transform.position = new Vector3(sol_x_kordinat, y_kordinat, oyuncuT.position.z + 10.0f);
                }
            }

            else
            {
                if (rastsayi > 50)
                {
                    yeni_klon.transform.position = new Vector3(sag_x_kardinat, y_kordinat, oyuncuT.position.z + 10.0f);
                }
                else
                {
                    yeni_klon.transform.position = new Vector3(sol_x_kordinat, y_kordinat, oyuncuT.position.z + 10.0f);
                }

                Debug.Log("deger donmedi! kutuk-tas" + oyuncu2.boxcolider_aktiflik);
            }

            Destroy(yeni_klon, silme_zamani);
        }
        else
        {
            if (rastsayi > 50)
            {
                yeni_klon.transform.position = new Vector3(sag_x_kardinat, y_kordinat, oyuncuT.position.z + 10.0f);
            }
            else
            {
                yeni_klon.transform.position = new Vector3(sol_x_kordinat, y_kordinat, oyuncuT.position.z + 10.0f);
            }
        }

        Destroy(yeni_klon, silme_zamani);
    }
}
