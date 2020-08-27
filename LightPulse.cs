using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{

    public Light light;
    public bool isRed;
    
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        isRed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRed)
        {
            StartCoroutine(lightPulse());
        }
        if (!isRed)
        {
            StartCoroutine(lightPulseDown());
        }
    }



    IEnumerator lightPulse()
    {
        while (isRed)
        {
            light.color -= (Color.white / 1.0f) * Time.deltaTime;
            yield return new WaitForSeconds(1.5f);
            isRed = false;
        }
    }

    IEnumerator lightPulseDown()
    {
        while (!isRed)
        {
            light.color += (Color.red / 1.0f) * Time.deltaTime;
            yield return new WaitForSeconds(1.5f);
            isRed = true;
        }
    }

    /*
    IEnumerator lightPulse()
    {
        while (isRed)
        {
            light.color -= (Color.white / 1.0f) * Time.deltaTime;
            yield return new WaitForSeconds(1.5f);
            isRed = false;
        }

        while (!isRed)
        {
            light.color += (Color.red / 1.0f) * Time.deltaTime;
            yield return new WaitForSeconds(1.5f);
            isRed = true;
        }
    }

    */
}
