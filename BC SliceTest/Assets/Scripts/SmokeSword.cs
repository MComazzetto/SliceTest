using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSword : MonoBehaviour
{
    [SerializeField] float offset;

    public float angle;
    Vector3 previousTran;
    Vector3 direction;
    Transform target;

    [SerializeField] Transform[] targetLocation;
    [SerializeField] float swingSpeed;
    [SerializeField] bool traveled;

    Vector3 startposition;
    void Awake()
    {
        Swipe();

        //Assign values and start monitoring sword movement
        startposition = this.transform.position;
        previousTran = this.transform.position;
    }

    void FixedUpdate()
    {
        this.gameObject.transform.position -= direction * Time.deltaTime * swingSpeed;
        if(this.transform.position == target.position)
        {
            direction = Vector3.zero;
            this.transform.position = startposition;

            Swipe();
        }
        AngleCalc();
    }

    //Record the angle of movement every 10ms
    void AngleCalc()
    {
        //subtract the vector of the previous position with the vector of the gameobject
        Vector3 direction = previousTran - this.transform.position;
        //calculate the angle by processing the vector to recieve the direction of the swords movement
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (-150f > angle && -180f < angle) // On swipe up, if 
        {
            angle = 180f;
        }
        else if ((-30f < angle && angle < 0) || (330f < angle && 360f > angle))
        {
            angle = 0f;
        }
        else if (angle < 0)
        {
            angle += 360f;
        }

        //update values
        previousTran = transform.position;
    }


    void Swipe()
    {
        Debug.Log("Yes");
        //variable to manage while loop

        target = targetLocation[Random.Range(0, targetLocation.Length)];

        direction = this.transform.position - target.position;
        Debug.Log(direction);

        //once completed go back to start position

        //select a target angle 
        //swipe that direction
        
    }

}
