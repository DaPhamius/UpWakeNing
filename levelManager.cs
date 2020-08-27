using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public Button fun;

    // Start is called before the first frame update
    void Start()
    {

        fun.interactable = false;

        int levelOne = PlayerPrefs.GetInt("levelOneCleared", 0);
        int levelTwo = PlayerPrefs.GetInt("levelTwoCleared", 0);

        isNormalCleared(levelOne);
    }

    public void deleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }


    public void isNormalCleared(int value)
    {
        if (value > 0)
        {
            fun.interactable = true;
        }
    }

   /* For hardmode
    * public void isFunCleared(int value)
    {
        if (value > 0)
        {
        
        }
    }
    */
}
