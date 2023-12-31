using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yagmurSesiManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip YagmurSesi;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = YagmurSesi;
        audioSource.loop = true;
    }
    void Start()
    {
        audioSource.Play();
    }
}
