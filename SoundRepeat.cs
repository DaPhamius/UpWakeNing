using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRepeat : MonoBehaviour
{
    public AudioSource soundEffect;

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            soundEffect.Play();
        }
    }
}
