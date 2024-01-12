using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using DG.Tweening;

public class create : MonoBehaviour
{
    [SerializeField] private TMP_InputField kullaniciAdi_IF, sifre_IF, sifreTekrar_IF;
    [SerializeField] private Toggle sozlesme;
    [SerializeField] private GameObject hataPaneli;

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
            StartCoroutine(pK_Script.hataPanel("Bo� BIRAKMAYINIZ!"));
            hataPaneliGetir();
        }
        else
        {          
            if (sifre_IF.text.Equals(sifreTekrar_IF.text))
            {
                if (sozlesme.isOn)
                {                  
                    Debug.Log("Veritaban� Ba�lant�s�");
                    StartCoroutine(kayitOl());
                }
                else
                {
                    StartCoroutine(pK_Script.hataPanel("L�tfen S�zle�meyi Kabul Ediniz!"));
                    hataPaneliGetir();
                }
            }
            else
            {
                StartCoroutine(pK_Script.hataPanel("�ifreler E�le�miyor!"));
                hataPaneliGetir();
            }
        }
    }

    IEnumerator kayitOl()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity","kayitOlma"); //php dosyas�nda kayitOlma if blo�una gider

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
                if (www.downloadHandler.text.Contains("kay�t ba�ar�l�"))
                {
                    StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));  //kay�t ba�ar�l� olma durumunda sorgu sonucunu hata paneline yazar

                    PlayerPrefs.DeleteAll();
                    kayitoldu = true;
               
                    StartCoroutine(pK_Script.hataPanel("Kay�t Ba�ar�l� �imdide Giri� yap�n."));
                    hataPaneliGetir();
                }
                else
                {
                  //hata olma durumunda//
                    StartCoroutine(pK_Script.hataPanel("L�tfen benzersiz kullan�c� ad� kullan�n�z!"));
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
