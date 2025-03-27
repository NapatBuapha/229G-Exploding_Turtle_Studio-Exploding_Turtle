using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialJumpScare : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private AudioClip fX;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        obj.SetActive(false);
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            audioSource.clip = fX;
            audioSource.Play();
            obj.SetActive(true);
            Destroy(gameObject,5);
        }
    }
}
