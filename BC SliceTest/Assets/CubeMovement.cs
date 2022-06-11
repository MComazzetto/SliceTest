using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    float cubeRotation;
    // Start is called before the first frame update
    void Start()
    {
        cubeRotation = this.gameObject.transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * movementSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //detect if hit by player sword
        if (collision.gameObject.CompareTag("Sword"))
        {
            float subRotation = cubeRotation - 30f;
            float addRotation = cubeRotation + 30f;
            float angle = collision.gameObject.GetComponent<Sword>().angle;
            //detect if the direction of the sword is within 30deg of the target angle, if so give feedback through light, sound and UI
            if (subRotation < angle && addRotation > angle )
            {
                //HIT/FEEDBACK
            }
            else
            {
                //FAIL, MISS
            }
            //Give feedback

            Destroy(this.gameObject);
        }

    }
}
