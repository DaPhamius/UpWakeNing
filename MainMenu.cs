using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject options;
    public GameObject gameCanvas;
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject difficultyMenu;
    public Text progressText;
    public GameObject filter;
    public bool paused = false;


    public void Update()
    {
        if (paused)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }
    public void PlayGame(string name)
    {
        StartCoroutine(LoadAsynchronously(name));    
    }

    IEnumerator LoadAsynchronously (string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        difficultyMenu.SetActive(false);
        filter.SetActive(false);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";

            yield return null;
        }
    }

    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ResumeGame()
    {
        options.SetActive(false);
        gameCanvas.SetActive(true);
        Time.timeScale = 1f;
    }



}
