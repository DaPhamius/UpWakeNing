using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LangText : MonoBehaviour
{
    public string Identifier;
    public int seconds;

    public void Awake()
    {
        if(seconds > 0)
        {
            StartCoroutine(SubtitlesOn());
        }
        
    }
    public void ChangeText(string text)
    {
        GetComponent<TextMeshProUGUI>().text = Regex.Unescape(text);
    }

    IEnumerator SubtitlesOn()
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        Debug.Log("test");
    }

}