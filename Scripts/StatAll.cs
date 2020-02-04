using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatAll : MonoBehaviour {

    public static int[,,] stat = new int[50,50,7];
    public static bool[,] status = new bool[7,50];
    public Text ATK;
    public Text MaxHP;
    public Text HP;
    public Text names;

    // Use this for initialization
    void Start () {

        //Set Stats
        stat[1, 0, 1] = 1;
        stat[1, 0, 2] = 0;
        stat[1, 0, 3] = 0;
        stat[1, 0, 4] = 0;
        stat[1, 0, 5] = 0;
        stat[1, 0, 6] = 0;

    }
	
	// Update is called once per frame
	void Update () {

        /*Debug.Log("Level Blue " + stat[1, 0, 1]);
        Debug.Log("Level Red " + stat[1, 0, 2]);

        Debug.Log("Blue Skill " + stat[5, 0, 1] + " " + stat[6, 0, 1] + " " + stat[7, 0, 1]);
        Debug.Log("Red Skill " + stat[5, 0, 2] + " " + stat[6, 0, 2] + " " + stat[7, 0, 2]);

        Debug.Log("Blue Upgrade " + stat[8, 0, 1] + " " + stat[8, 1, 1] + " " + stat[8, 2, 1]);
        Debug.Log("Red Upgrade " + stat[8, 0, 2] + " " + stat[8, 1, 2] + " " + stat[8, 2, 2]);

        Debug.Log("Blue Stat " + stat[2, 0, 1] + "/" + stat[3, 0, 1]);
        Debug.Log("Red Stat " + stat[2, 0, 2] + "/" + stat[3, 0, 2]);*/

    }
}
