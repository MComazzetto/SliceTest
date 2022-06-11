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
        Vector3 direction = previousTran + this.transform.position;
        //calculate the angle by processing the vector through pi
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log("angle: " + angle);
        previousTran = transform.position;
    }
}
