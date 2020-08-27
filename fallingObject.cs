using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObject : MonoBehaviour
{

    public Vector3 startPosition;
    public Vector3 endPosition;
    public bool hasFallen;
    public Player player;
    public float downSpeed;
    public float upSpeed;

    // Start is called before the first frame update
    void Start()
    {
        hasFallen = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.toothCollided == true && !hasFallen)
        {
            StartCoroutine(toothDown());

        }
        if (hasFallen)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, upSpeed * Time.deltaTime);
        }
    }

    IEnumerator toothDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, downSpeed * Time.deltaTime); 
        yield return new WaitForSeconds(10);
        hasFallen = true;
    }

}
