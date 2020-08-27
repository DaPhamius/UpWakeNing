using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatforms : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float moveSpeed;
    private Rigidbody rb;
    public bool collidingWithPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collidingWithPlayer = false;
        transform.position = startPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (collidingWithPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        collidingWithPlayer = true;
        Debug.Log("Collision detected");
    }

    private void OnCollisionExit(Collision other)
    {
        collidingWithPlayer = false;
        Debug.Log("Collision left");

    }
}
