using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillup : MonoBehaviour {

    public int typeskill;

    public GameObject Up_1;
    public GameObject Up_2;
    public GameObject Up_3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Upgrade()
    {
        if (typeskill == 1)
        {
            PlayerInfo.skilllvl[0]++;
        }

        else if (typeskill == 2)
        {
            PlayerInfo.skilllvl[1]++;
        }

        else if (typeskill == 3)
        {
            PlayerInfo.skilllvl[2]++;
        }

        Up_1.SetActive(false);
        Up_2.SetActive(false);
        Up_3.SetActive(false);

        PlayerInfo.onceUp = false;
    }
}
