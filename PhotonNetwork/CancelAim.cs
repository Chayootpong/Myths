using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelAim : MonoBehaviour {

    public GameObject Light_1;
    public GameObject Light_2;
    public GameObject Light_3;
    public GameObject[] invi;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Delete()
    {
        Light_1.SetActive(true);
        Light_2.SetActive(true);
        Light_3.SetActive(false);
        Choose.isAim = false;

        for (int i = 0; i < 100; i++)
        {
            invi[i].SetActive(false);
        }

        gameObject.SetActive(false);

    }
}
