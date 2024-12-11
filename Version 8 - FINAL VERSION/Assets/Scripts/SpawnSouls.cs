using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSouls : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1.3f;
    public float minHeight = -3.5f;
    public float maxHeight = -1.5f;
    public float initialDelay = 2.5f;
    //Spawn souls with reference to their spawnRate
    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }
    //Add in a delay for souls to start spawning
    private IEnumerator StartSpawningWithDelay() {
    
        yield return new WaitForSeconds(initialDelay);
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
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