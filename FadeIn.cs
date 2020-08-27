using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{

    // the image you want to fade, assign in inspector
    public Image img;
    public bool normalCompleted = false;
    public GameObject credits;
    public Player Player;

    public void Start()
    {

    }
    private void Update()
    {
        if (normalCompleted == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(2);
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            credits.SetActive(true);
            StartCoroutine(FadeImage(true));
            normalCompleted = true;
            PlayerPrefs.SetFloat("Seconds", Player.seconds);
            PlayerPrefs.SetFloat("Minutes", Player.minutes);
            PlayerPrefs.SetFloat("Hours", Player.hours);
            PlayerPrefs.SetFloat("Jumps", Player.amountOfJumps);
            PlayerPrefs.Save();
        }
        // fades the image out when you click
    }

    
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {


            // loop over 1 second
            for (float i = 0; i <= 2; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }
}

