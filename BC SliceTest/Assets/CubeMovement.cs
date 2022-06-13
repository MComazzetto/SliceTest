using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    float cubeRotation;
    Renderer cube;
    bool sliced = false;
    // Start is called before the first frame update
    void Awake()
    {
        cubeRotation = this.gameObject.transform.rotation.eulerAngles.z;
        cube = this.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!sliced)
        {
            //detect if hit by player sword
            if (other.gameObject.CompareTag("Sword"))
            {

                float subRotation = cubeRotation - 30f;
                float addRotation = cubeRotation + 30f;
                float angle = other.gameObject.GetComponent<Sword>().angle;
                Debug.Log("Sword direction: " + angle + " Cube rotation" + cubeRotation);
                //Detect if the direction of the swing is within 30deg of the target angle. The results will change the audio and visual feedback
                if (subRotation < angle && addRotation > angle)
                {
                    //HIT/FEEDBACK
                    Debug.Log("Hit");
                    Destroy(this.gameObject);
                }
                else
                {
                    //FAIL, MISS
                    Debug.Log("Miss");
                    cube.material.color = Color.red;

                }
                sliced = true;
            }
        }
        Debug.Log("Connect");


    }

}
