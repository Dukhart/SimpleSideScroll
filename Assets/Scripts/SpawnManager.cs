using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnObject;
    private PlayerController player;
    public float spawnRate = 1;
    public float delay = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", delay, spawnRate);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void SpawnObject()
    {
        if (!player.gameOver)
        {
            // pick a random obstacle
            int i = Random.Range(0, spawnObject.Length);
            Instantiate(spawnObject[i], transform.position, spawnObject[i].transform.rotation);
        }
    }
}
