using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] float offset;

    public float angle;

    Vector3 previousTran;
    // Start is called before the first frame update
    void Awake()
    {
        previousTran = this.transform.position;
        InvokeRepeating("AngleCalc", 1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        //Follow mouse
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + offset));
        this.transform.position = pos;
    }

    //Record the angle of movement every 20ms
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
        else if((-30f < angle && angle < 0) || (330f < angle && 360f > angle))
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
}
