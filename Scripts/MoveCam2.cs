using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam2 : MonoBehaviour {
    float speed = 20.0f;
    float xUp, xLow, yL, yR, zU, zL;
    float rc = -2.0f;
    Vector3 msp,maxsp;
   



    // Use this for initialization
    void Start () {
        msp = transform.localPosition;
        xUp =  msp.x;//left
        xLow = msp.x;
        yL = msp.y;
        yR = msp.y;
        zU = msp.z;
        zL = msp.z;
        
       
    }

    // Update is called once per frame
    void Update () {

        xUp = msp.x;
        xLow = msp.x;
        yL = msp.y;
        yR = msp.y;
        zU = msp.z;
        zL = msp.z;
        xUp = xUp - ((Camera.main.orthographicSize - 27) * rc);
        xLow = xLow + ((Camera.main.orthographicSize - 27) * rc);
        yL = yL - ((Camera.main.orthographicSize - 27) * rc);
        yR = yR + ((Camera.main.orthographicSize - 27) * rc);
        zU = zU + ((Camera.main.orthographicSize - 27) * rc);
        zL = zL - ((Camera.main.orthographicSize - 27) * rc);


        if (transform.localPosition.x < xUp)
    {
        transform.localPosition = new Vector3(xUp,transform.localPosition.y,transform.localPosition.z);
    }
    if (transform.localPosition.x > xLow)
    {
        transform.localPosition = new Vector3(xLow,transform.localPosition.y,transform.localPosition.z);
    }
    if (transform.localPosition.y > yR)
    {
        transform.localPosition = new Vector3(transform.localPosition.x,yR,transform.localPosition.z);
    }
        if (transform.localPosition.y < yL)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, yL, transform.localPosition.z);
        }
    if (transform.localPosition.z > zU)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, zU);
    }
        if (transform.localPosition.z < zL)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, zL);
        }




        if (transform.position.x > xUp || transform.position.x < xLow|| transform.position.y >yL || transform.position.y < yR)
        { 

        if (Input.GetMouseButton(1))
        {

                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position += new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * speed, 0.0f, (Input.GetAxis("Mouse X") * 1.00f) * Time.deltaTime * speed);
                }
                else if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position += new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * speed, 0.0f, (Input.GetAxis("Mouse X") * 1.00f) * Time.deltaTime * speed);
                }
                if (Input.GetAxis("Mouse Y") > 0)
                {
                    transform.position += new Vector3(-(Input.GetAxis("Mouse Y") * Time.deltaTime * speed * 2.0f), (Input.GetAxis("Mouse Y") * -1.00f) * Time.deltaTime * speed, (Input.GetAxis("Mouse Y") * 2) * Time.deltaTime * speed);
                }
                else if (Input.GetAxis("Mouse Y") < 0)
                {
                    transform.position += new Vector3(-(Input.GetAxis("Mouse Y") * Time.deltaTime * speed * 2.0f), (Input.GetAxis("Mouse Y") * -1.00f) * Time.deltaTime * speed, (Input.GetAxis("Mouse Y") * 2) * Time.deltaTime * speed);
                }
            }
        }
    }
}
