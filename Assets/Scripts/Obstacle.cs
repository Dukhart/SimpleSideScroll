using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -20 || transform.position.y < -10) Destroy(gameObject);
    }
}
