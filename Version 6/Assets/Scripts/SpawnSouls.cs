using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSouls : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1.6f;
    public float minHeight = -5.0f;
    public float maxHeight = 0.0f;

    private void OnEnable() {

        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {

        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() {

        GameObject laser = Instantiate(prefab, transform.position, Quaternion.identity);

        //Adjust the Z-position so it spawns in front of the background
        Vector3 spawnPosition = laser.transform.position;
        spawnPosition.z = -6f; //Move the soul object forward on the Z-axis
        spawnPosition.y += Random.Range(minHeight, maxHeight);
        laser.transform.position = spawnPosition;

    }
}