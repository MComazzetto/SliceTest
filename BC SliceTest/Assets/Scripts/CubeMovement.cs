using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    float cubeRotation;
    Renderer cube;
    bool sliced = false;
    void Awake()
    {
        //assign veraibles
        cubeRotation = this.gameObject.transform.rotation.eulerAngles.z;
        cube = this.gameObject.GetComponent<MeshRenderer>();
    }


    void Update()
    {
        //Move cube towards camera
        transform.Translate(Vector3.back * movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        float angle = 0f;

        //Detect if cube has already been slashed
        if (!sliced)
        {
            //Detect if hit by player sword
            if (other.gameObject.CompareTag("Sword"))
            {

                float subRotation = cubeRotation - 30f;
                float addRotation = cubeRotation + 30f;
                
                if(other.gameObject.GetComponent<Sword>() != null)
                {
                    angle = other.gameObject.GetComponent<Sword>().angle;
                }else if(other.gameObject.GetComponent<SmokeSword>() != null)
                {
                    angle = other.gameObject.GetComponent<SmokeSword>().angle;
                }
                
                Debug.Log("Sword direction: " + angle + " Cube rotation" + cubeRotation);

                //Detect if the direction of the swing is within 30deg of the target angle. The results will change the audio and visual feedback
                if (subRotation < angle && addRotation > angle)
                {
                    //HIT/FEEDBACK
                    Debug.Log("Hit");
                    StartCoroutine(WaitToDespawn(Color.green));
                }
                else
                {
                    //FAIL/ FEEDBACK
                    Debug.Log("Miss");

                    StartCoroutine(WaitToDespawn(Color.red));
                }
                sliced = true;
            }
        }
        Debug.Log("Connect");

        IEnumerator WaitToDespawn(Color col)
        {
            cube.material.color = col;
            yield return new WaitForSeconds(0.3f);
            Destroy(this.gameObject);
        }
    }

}
