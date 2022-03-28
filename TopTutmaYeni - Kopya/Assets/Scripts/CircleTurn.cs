using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTurn : MonoBehaviour
{
    float speed= 100;
    bool isRight;
    bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        isRight = false;
        isLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        }
        if (isLeft)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        }
    }
    public void turnLeftOn()
    {
        isLeft = true ;
    }
    public void turnLeftOff()
    {
        isLeft = false;
    }
    public void turnRightOn()
    {
        isRight = true;
    }
    public void turnRightOff()
    {
        isRight = false;
    }
}
