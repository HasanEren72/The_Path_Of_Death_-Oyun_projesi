using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class panel_gecis : MonoBehaviour
{
    [SerializeField] private GameObject Giris_panel , kayit_panel;
    [SerializeField] private TextMeshProUGUI  hata_TMP;

    public void Kayitol_B()
    {
        kayit_panel.SetActive(true);
        Giris_panel.SetActive(false);  
    }
    public void Geri_B()
    {
        kayit_panel.SetActive(false);
        Giris_panel.SetActive(true);    
    }
    public void EX�T_B()
    {
        Application.Quit();
    }

    public IEnumerator hataPanel(string hataText)
    {
        hata_TMP.SetText(hataText);
       
        yield return new WaitForSeconds(1.5f);
       // hataAnimator.SetBool("HataDurumu", false);
    }
}
