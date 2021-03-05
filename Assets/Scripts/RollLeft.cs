using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollLeft : MonoBehaviour
{
    PlayerController player;
    Rigidbody objectRB;
    public float rollRate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        objectRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player && !player.gameOver)
            objectRB.AddForce(Vector3.left * rollRate, ForceMode.VelocityChange);
    }
}
