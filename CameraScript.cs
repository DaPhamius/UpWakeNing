using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject objectToFollow;
    public GameObject options;
    public GameObject gameScreen;

    public float speed = 2.0f;
    public float y_offset;
    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y + y_offset, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

        this.transform.position = position;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            options.SetActive(true);
            Time.timeScale = 0f;
        }

        
    }
}
