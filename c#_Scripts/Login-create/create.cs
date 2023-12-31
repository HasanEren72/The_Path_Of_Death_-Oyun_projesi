using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using DG.Tweening;

public class create : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField kullaniciAdi_IF, sifre_IF, sifreTekrar_IF;

    [SerializeField]
    private Toggle sozlesme;

    [SerializeField]
    private GameObject hataPaneli;

    panel_gecis pK_Script;

    public static  bool kayitoldu;

    void Start()
    {
         kayitoldu = false;
         pK_Script = GetComponent<panel_gecis>();
    }

    public void uyeligiOlustur_Buton()
    {
        if (kullaniciAdi_IF.text.Equals("") || sifre_IF.text.Equals("") || sifreTekrar_IF.text.Equals(""))
        {
            StartCoroutine(pK_Script.hataPanel("Boþ BIRAKMAYINIZ!"));
            hataPaneliGetir();
        }
        else
        {          
            if (sifre_IF.text.Equals(sifreTekrar_IF.text))
            {
                if (sozlesme.isOn)
                {                  
                    Debug.Log("Veritabaný Baðlantýsý");
                    StartCoroutine(kayitOl());
                }
                else
                {
                    StartCoroutine(pK_Script.hataPanel("Lütfen Sözleþmeyi Kabul Ediniz!"));
                    hataPaneliGetir();
                }
            }
            else
            {
                StartCoroutine(pK_Script.hataPanel("Þifreler Eþleþmiyor!"));
                hataPaneliGetir();
            }
        }
    }

    IEnumerator kayitOl()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity","kayitOlma"); //php dosyasýnda kayitOlma if bloðuna gider

        form.AddField("kullaniciAdi", kullaniciAdi_IF.text); 
        form.AddField("sifre", sifre_IF.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity_DB/user.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {               
                if (www.downloadHandler.text.Contains("kayýt baþarýlý"))
                {
                    StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));  //kayýt baþarýlý olma durumunda sorgu sonucunu hata paneline yazar

                    PlayerPrefs.DeleteAll();
                    kayitoldu = true;
               
                    StartCoroutine(pK_Script.hataPanel("Kayýt Baþarýlý þimdide Giriþ yapýn."));
                    hataPaneliGetir();
                }
                else
                {
                  //hata olma durumunda//
                    StartCoroutine(pK_Script.hataPanel("Lütfen benzersiz kullanýcý adý kullanýnýz!"));
                    hataPaneliGetir();
                }               
            }
        }
    }

    void hataPaneliGetir()
    {
        hataPaneli.GetComponent<RectTransform>().DOLocalMoveY(-260, 0.5f);
    }
}
