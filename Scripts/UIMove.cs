using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMove : MonoBehaviour {

    public Transform hideBT;
    public Transform showBT;
    public Transform hideTP;
    public Transform showTP;
    public GameObject buttom;
    public GameObject top;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        if (Turns.skillshow == true || TargetID.targeting == true)
        {
            buttom.transform.position = Vector3.Lerp(buttom.transform.position, hideBT.position, Time.deltaTime * 5);
            top.transform.position = Vector3.Lerp(top.transform.position, hideTP.position, Time.deltaTime * 5);
        }

        else
        {
            buttom.transform.position = Vector3.Lerp(buttom.transform.position, showBT.position, Time.deltaTime * 5);
            top.transform.position = Vector3.Lerp(top.transform.position, showTP.position, Time.deltaTime * 5);
        }
		
	}
}
