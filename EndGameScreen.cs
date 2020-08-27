using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class EndGameScreen : MonoBehaviour
{
    public TextMeshProUGUI jumps;
    public TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = PlayerPrefs.GetFloat("Hours") + ":" + PlayerPrefs.GetFloat("Minutes") + ":" + (PlayerPrefs.GetFloat("Seconds").ToString("F2"));
        jumps.text = "" + PlayerPrefs.GetFloat("Jumps");
    }

    public void deleteTimer()
    {
        StartCoroutine(deleteKeys());
    }

    public IEnumerator deleteKeys ()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(2f);
        PlayerPrefs.DeleteKey("Jumps");
        PlayerPrefs.DeleteKey("Hours");
        PlayerPrefs.DeleteKey("Minutes");
        PlayerPrefs.DeleteKey("Seconds");
    }
}
