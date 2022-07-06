using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] float spawnSpeed;
    [SerializeField] bool  randomised = true;

    [Space]
    [Header("Optional")]
    [SerializeField] float gORotation;

    void Start()
    {
        if (randomised)
        {
            InvokeRepeating("RandomSpawn", 1f, spawnSpeed);
        }
        else
        {
            InvokeRepeating("Spawn", 1f, spawnSpeed);
        }

        
    }

    //Spawn cube at a random rotation
    void RandomSpawn()
    {
        //Select a random angle and snap the cube to the neirest 45 degree angle before spawning.
        float roundedRotation = Mathf.Round(Random.Range(0, 359) / 45) * 45;
        GameObject gO = Instantiate(spawnObject, this.transform.position, Quaternion.Euler(0, 0, roundedRotation));
    }

    void Spawn()
    {
        //Select a specific angle and spawn the cube at that
        GameObject gO = Instantiate(spawnObject, this.transform.position, Quaternion.Euler(0, 0, gORotation));
    }
}
