using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] float spawnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnSpeed);
    }

    void Spawn()
    {
        //Select a random angle and snap the object to the neirest 45 degree angle.
        float roundedRotation = Mathf.Round(Random.Range(0, 359) / 45) * 45;
        GameObject gO = Instantiate(spawnObject, this.transform.position, Quaternion.Euler(0, 0, roundedRotation));
    }
}
