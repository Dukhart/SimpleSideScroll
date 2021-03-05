using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;
    private float interval;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        interval = GetComponent<BoxCollider>().size.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - interval || transform.position.x > startPos.x + interval)
        {
            transform.position = startPos;
        }
    }
}
