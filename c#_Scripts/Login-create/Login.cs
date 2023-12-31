using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Login : MonoBehaviour
{    
    private AudioSource ses;

    [SerializeField]
    private TMP_InputField kullaniciAdi_IF, sifre_IF;

    public static string kuladi;
    public static string sifre;

    public static string V_kullanici_degeri;
    public static string V_sifre_degeri;

    panel_gecis pK_Script;

    [SerializeField]
    private GameObject hataPaneli;

    void Start()
    {
        ses = GetComponent<AudioSource>();
        pK_Script = GetComponent<panel_gecis>();

        ses.Play();
    }

    public void kuladi_vesifre_atama_fonk()
    {
        kuladi = kullaniciAdi_IF.text;
        sifre = sifre_IF.text;
    }

    public void girisYap_B()
    {
        if (kullaniciAdi_IF.text.Equals("") || sifre_IF.text.Equals(""))
        {
            StartCoroutine(pK_Script.hataPanel("Boþ BIRAKMAYINIZ!"));
            hataPaneliGetir();
        }
        else
        {          
            StartCoroutine((pK_Script.hataPanel("Giris Basarili")));
            //veritabaný
            StartCoroutine(girisYap());
        }
    }

    IEnumerator girisYap()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity","girisYapma");
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
               Debug.Log("Sorgu Sonucu:" + www.downloadHandler.text);              
               
                if (www.downloadHandler.text.Contains("giriþ baþarýlý"))
                {
                    kuladi_vesifre_atama_fonk();
                    PlayerPrefs.SetString("kullaniciadi_Kayit", kuladi); // set etme iþlemi
                    PlayerPrefs.SetString("sifre_Kayit", sifre);

                    V_kullanici_degeri = PlayerPrefs.GetString("kullaniciadi_Kayit");
                    V_sifre_degeri = PlayerPrefs.GetString("sifre_Kayit");

                    SceneManager.LoadScene("Menu", LoadSceneMode.Single);  //  için sahneyi yükledik                  
                }
                else
                {
                    Debug.Log("Sorgu Sonucu:" + www.downloadHandler.text);
                    StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));
                    hataPaneliGetir();
                }                   
            }
        }
    }
    
    void hataPaneliGetir()
    {
        hataPaneli.GetComponent<RectTransform>().DOLocalMoveY(-260,0.5f);
    }

    public void SesKontrol()
    {  
        if(ses.isPlaying)
        {
            ses.Stop();
        }
        else
        {
            ses.Play();
        }
    }

    public void exit()
    {
        Application.Quit();
    }
}
