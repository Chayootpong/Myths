using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Die : MonoBehaviour {
    public static GameObject[] player = new GameObject[7];

    public GameObject[] plays = new GameObject[7];
    // Use this for initialization
    void Start () {

        player = plays;
		
	}
	
	// Update is called once per frame
	void Update () {


        if (StatAll.stat[3, 1, 1] <= 0)
        {           
            StatAll.stat[2, 1, 1] = 0;
            StatAll.stat[3, 1, 1] = 0;
            StatAll.stat[4, 0, 1] = 0;
            player[1].SetActive(false);
            ClearDeBuff(1);
        }

        if (StatAll.stat[3, 1, 2] <= 0)
        {
            StatAll.stat[2, 1, 2] = 0;
            StatAll.stat[3, 1, 2] = 0;
            StatAll.stat[4, 0, 2] = 0;
            player[2].SetActive(false);
            ClearDeBuff(2);
        }

        if (StatAll.stat[3, 1, 3] <= 0)
        {
            StatAll.stat[2, 1, 3] = 0;
            StatAll.stat[3, 1, 3] = 0;
            StatAll.stat[4, 0, 3] = 0;
            player[3].SetActive(false);
            ClearDeBuff(3);
        }

        if (StatAll.stat[3, 1, 4] <= 0)
        {
            StatAll.stat[2, 1, 4] = 0;
            StatAll.stat[3, 1, 4] = 0;
            StatAll.stat[4, 0, 4] = 0;
            player[4].SetActive(false);
            ClearDeBuff(4);
        }

        if (StatAll.stat[3, 1, 5] <= 0)
        {
            StatAll.stat[2, 1, 5] = 0;
            StatAll.stat[3, 1, 5] = 0;
            StatAll.stat[4, 0, 5] = 0;
            player[5].SetActive(false);
            ClearDeBuff(5);
        }

        if (StatAll.stat[3, 1, 6] <= 0)
        {
            StatAll.stat[2, 1, 6] = 0;
            StatAll.stat[3, 1, 6] = 0;
            StatAll.stat[4, 0, 6] = 0;
            player[6].SetActive(false);
            ClearDeBuff(6);
        }

    }

    void ClearDeBuff(int ID)
    {

        for (int x = 0; x <= 35; x++)
        {
            StatAll.stat[9, x, ID] = 0;
            StatAll.stat[10, x, ID] = 0;
        } 
    }
}
