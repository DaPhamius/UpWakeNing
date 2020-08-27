using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrigger : MonoBehaviour
{
    public AudioSource soundEffect;
    public bool hasPlayed;
    public GameObject theSubtitles;

    void Start()
    {
        hasPlayed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasPlayed)
        {
            theSubtitles.SetActive(true);
            soundEffect.Play();
            hasPlayed = true;
        }
    }
}
