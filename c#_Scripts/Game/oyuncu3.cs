using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;
using System.Data;

public class oyuncu3 : MonoBehaviour
{
    [SerializeField] private Transform oyuncu_kayma;
    [SerializeField] private Animator animasyon;
    [SerializeField] private GameObject altin_efekti, hiz_efekti, elmas_efekti, kalkan_efekti, devamlı_kalkan_efekti;
    [SerializeField] private Transform Yol_1, Yol_2;
    [SerializeField] private Transform oyuncu_T_efekt_icin;
    [SerializeField] private Rigidbody rigi;
    public bool sag = true;
    public bool miknatis_alindi = false;
    public bool hiz_nesnesi_alindi = false;
    public bool kalkan_alindi = false;
    private AudioSource audioSource;
    [SerializeField] private AudioClip miknatisSesi, AltinTemasSesi, kalkanSesi, ElmasSesi;
    [SerializeField] private TMPro.TextMeshProUGUI puan_txt, toplanan_altin_txt, elmas_txt;  //textmeshpro değerleri
    [SerializeField] private float hiz = 9.0f;

    public static int puan = 0;      // skor artış degerleri
    public static int toplanan_altin = 0;
    public static int elmas = 0;

    public static int toplanan_altin_Kayit; // skor kayıt değerleri
    public static int puan_Kayit;
    public static int elmas_Kayit;

    public static string kullaniciadi_str, sifre_str, puan_str, toplamAltin_str, elmas_str;

    public static bool engeleCarpabilir = true;

    public static bool boxcolider_aktiflik = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        //if (create.kayitoldu == true)
        //{

        //}
        //else
        //{
        //    Debug.Log("ilk kayıt başarısız fonks çağrısı başarısız");  
        //}

        rigi = GetComponent<Rigidbody>();

        kullaniciadi_str = PlayerPrefs.GetString("kullaniciadi_Kayit");
        sifre_str = PlayerPrefs.GetString("sifre_Kayit");

        Debug.Log("kullaniciadi_str alınan veri :" + kullaniciadi_str);

        StartCoroutine(İLKskorlar_ekleme()); //ilk skorları veritabanına ekliyor
    }

    public void BoxColider_aktiflik_true()
    {
        boxcolider_aktiflik = true;
    }

    private void OnTriggerEnter(Collider other) //�arp��ma 
    {
        if (other.gameObject.tag == "duvar_1")
        {
            Yol_2.position = new Vector3(Yol_1.position.x, Yol_1.position.y, Yol_1.position.z + 69.0f);
        }
        if (other.gameObject.tag == "duvar_2")
        {
            Yol_1.position = new Vector3(Yol_2.position.x, Yol_2.position.y, Yol_2.position.z + 69.0f);
        }

        if (other.gameObject.tag == "hiz_nesne")
        {
            engeleCarpabilir = false;

            Destroy(other.gameObject);

            GameObject[] tum_hiz_nesneleri = GameObject.FindGameObjectsWithTag("hiz_nesne");
            foreach (GameObject hiz_nesne in tum_hiz_nesneleri)
            {
                Destroy(hiz_nesne);
            }

            hiz_nesnesi_alindi = true;
            Invoke("nesneleri_resetle", 20.0f);

            StartCoroutine(HizSuresi());
        }
        IEnumerator HizSuresi()
        {
            Time.timeScale = 2;
            boxcolider_aktiflik = false;

            GameObject yeni_hiz_efekti = Instantiate(hiz_efekti, oyuncu_T_efekt_icin.transform.position, Quaternion.identity);
            yeni_hiz_efekti.transform.SetParent(oyuncu_T_efekt_icin.transform, true);

            yield return new WaitForSeconds(20);
            Destroy(yeni_hiz_efekti, 0.0f);
            BoxColider_aktiflik_true();
            Time.timeScale = 1;
            engeleCarpabilir = true;
        }

        if (other.gameObject.tag == "kalkan")
        {
            GameObject yeni_kalkan_efekti = Instantiate(kalkan_efekti, other.gameObject.transform.position, Quaternion.identity); //parlayan alt�n efekti

            Destroy(yeni_kalkan_efekti, 0.5f);

            GameObject[] tum_kalkanlar = GameObject.FindGameObjectsWithTag("kalkan");

            foreach (GameObject kalkan in tum_kalkanlar)
            {
                Destroy(kalkan);   //t�m m�knat�slar� siler  
            }

            engeleCarpabilir = false;
            StartCoroutine(engelaktiflik());

            audioSource.PlayOneShot(kalkanSesi);
            kalkan_alindi = true;
            Invoke("nesneleri_resetle", 10.0f);
        }

        IEnumerator engelaktiflik()
        {
            GameObject yeni_kalkan_efektix = Instantiate(devamlı_kalkan_efekti, oyuncu_T_efekt_icin.transform.position, Quaternion.identity);
            yeni_kalkan_efektix.transform.SetParent(oyuncu_T_efekt_icin.transform, true);

            yield return new WaitForSeconds(10);

            Destroy(yeni_kalkan_efektix, 0.0f);

            Time.timeScale = 1;
            engeleCarpabilir = true;
        }

        if (engeleCarpabilir)
        {
            if (other.gameObject.tag == "engel")
            {
                puan = 0;
                toplanan_altin = 0;
                elmas = 0;

                Time.timeScale = 0.0f;

                PlayerPrefs.DeleteKey("puan_verisi");
                PlayerPrefs.DeleteKey("altin_sayisi_verisi");
                PlayerPrefs.DeleteKey("elmas_verisi");

                SceneManager.LoadScene("Game_Over");

                StartCoroutine(skorlar_ekleme()); // engellere çarpınca  skorları veritabanına kayıt etmek için
            }
        }

        if (other.gameObject.tag == "altin")
        {
            audioSource.PlayOneShot(AltinTemasSesi);

            GameObject yeni_altin_efekti = Instantiate(altin_efekti, other.gameObject.transform.position, Quaternion.identity); //parlayan altin efekti

            Destroy(yeni_altin_efekti, 0.5f);

            toplanan_altin++;
            PlayerPrefs.SetInt("altin_sayisi_verisi", toplanan_altin);
            toplanan_altin_Kayit = PlayerPrefs.GetInt("altin_sayisi_verisi");

            puan += 5;
            PlayerPrefs.SetInt("puan_verisi", puan);
            puan_Kayit = PlayerPrefs.GetInt("puan_verisi");

            // puan_txt.text = puan.ToString("0000");

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "elmas")
        {
            GameObject yeni_elmas_efekti = Instantiate(elmas_efekti, other.gameObject.transform.position, Quaternion.identity); //elmas efekti

            Destroy(yeni_elmas_efekti, 0.5f);

            elmas++;
            PlayerPrefs.SetInt("elmas_verisi", elmas);
            elmas_Kayit = PlayerPrefs.GetInt("elmas_verisi");

            puan += 10;
            PlayerPrefs.SetInt("puan_verisi", puan);
            puan_Kayit = PlayerPrefs.GetInt("puan_verisi");

            Destroy(other.gameObject);

            audioSource.PlayOneShot(ElmasSesi);
        }

        if (other.gameObject.tag == "miknatis")
        {
            audioSource.PlayOneShot(miknatisSesi);

            GameObject[] tum_miknatislar = GameObject.FindGameObjectsWithTag("miknatis");

            foreach (GameObject miknatis in tum_miknatislar)
            {
                Destroy(miknatis);   //t�m m�knat�slar� siler  
            }

            miknatis_alindi = true;  //sadece bir tane m�knat�s al�n�r 
            Invoke("nesneleri_resetle", 10.0f); // m�knat�s silme fonksiyonunu 10 saniye sonra  �al��t�racak

        }
    }

    void nesneleri_resetle()
    {
        miknatis_alindi = false;
        hiz_nesnesi_alindi = false;
        kalkan_alindi = false;
    }

    private void OnCollisionStay(Collision collision) //oyuncu ile yol ars�nda �arp��ma devam ederken
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) //klavyeden yukar� ok tu�una bas�lm�� ise
        {
            rigi.velocity = Vector3.up * 300.0f * Time.deltaTime;
            //rigi.velocity = new Vector3(0, 6f, 0);
            // animasyon.SetBool("zipla", true);          
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) //kayma
        {
            oyuncu_kayma.position = new Vector3(oyuncu_kayma.position.x, 0.72f, oyuncu_kayma.position.z);
            //animasyon.SetBool("kayma", true);
        }

        // Oyunun Android versiyonu için  yön hareketleri

        //if (Input.touchCount > 0)//ekrana dokunduğunda
        //{
        //    Touch parmak = Input.GetTouch(0);//parmağın konumu

        //    if (parmak.deltaPosition.y > 50.0f) // ekran y ekseninde ne kadar dokunduğu zıplama
        //    {
        //        rigi.velocity = Vector3.up * 300.0f * Time.deltaTime;

        //    }
        //    if (parmak.deltaPosition.y < -50.0f) // ekran x ekseninde ne kadar dokunduğu kayma
        //    {
        //        oyuncu_kayma.position = new Vector3(oyuncu_kayma.position.x, 0.72f, oyuncu_kayma.position.z);

        //    }

        //}
    }

    private void OnCollisionExit(Collision collision)//oyuncu ile yol ars�nda  �arp��ma dbitti�i zaman //z�plad��� zaman
    {
        if (!(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))   //zıplama tuşuna basmadığı zaman dusme animasyonu çalışacaktır
        {
            // animasyon.SetBool("dusme", true);
            //gameover_ses.enabled = true;
        }
    }

    // skor ekleme işlemleri

    public IEnumerator skorlar_ekleme() // veritabanına güncellenmiş şekilde skorları günceller
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "skorlar_ekleme");
        form.AddField("kullaniciAdi", kullaniciadi_str);
        form.AddField("sifre", sifre_str);
        form.AddField("puan", puan_str);
        form.AddField("toplamAltin", toplamAltin_str);
        form.AddField("top_elmas", elmas_str);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity_DB/user.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Skorlar kayıt Sonucu başarılı:" + www.downloadHandler.text);
            }
        }
    }
    public IEnumerator İLKskorlar_ekleme() // veritabanına ilk skorları ekler
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "ilk_skorlar_ekleme");
        form.AddField("kullaniciAdi", kullaniciadi_str);
        form.AddField("sifre", sifre_str);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity_DB/user.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("İLK Skorlar kayıt :" + www.downloadHandler.text);
            }
        }
    }

    void Update()
    {
        sifre_str = PlayerPrefs.GetString("sifre_Kayit");

        puan_str = puan_Kayit.ToString();
        toplamAltin_str = toplanan_altin_Kayit.ToString();
        elmas_str = elmas_Kayit.ToString();

        puan_txt.text = puan.ToString();
        toplanan_altin_txt.text = toplanan_altin.ToString();
        elmas_txt.text = elmas.ToString();

        hareket();
        pozisyon_kaydet();
    }
    public void pozisyon_kaydet()
    {
        PlayerPrefs.SetFloat("X", transform.position.x);
        PlayerPrefs.SetFloat("Y", transform.position.y);
        PlayerPrefs.SetFloat("Z", transform.position.z);
    }

    public void Kalinan_YerdebBaslat()
    {
        if (PlayerPrefs.HasKey("Z"))
        {
            float X = PlayerPrefs.GetFloat("X");
            float Y = PlayerPrefs.GetFloat("Y");
            float Z = PlayerPrefs.GetFloat("Z");

            transform.position = new Vector3(X, Y, Z);
        }
    }
    void hareket()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            sag = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            sag = false;
        }


        if (sag)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-1.63f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(1.5f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);
        }

        // android versiyonu için

        //if (Input.touchCount > 0) //ekrana dokunduğunda 
        //{
        //    Touch parmak = Input.GetTouch(0);//parmağın konumu

        //    if (parmak.deltaPosition.x > 50.0f) // ekran y ekseninde ne kadar dokunduğu zıplama
        //    {
        //        transform.position = Vector3.Lerp(transform.position, new Vector3(-1.63f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);

        //    }
        //    if (parmak.deltaPosition.x < -50.0f) // ekran x ekseninde ne kadar dokunduğu kayma
        //    {
        //        transform.position = Vector3.Lerp(transform.position, new Vector3(1.37f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);

        //    }

        //}

        transform.Translate(0, 0, hiz * Time.deltaTime);
    }
}
