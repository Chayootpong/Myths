using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upskill : MonoBehaviour {

    public GameObject skill;
    public GameObject[] block;

    // Use this for initialization
    void Start() {

        skill.SetActive(true);

    }

    // Update is called once per frame
    void Update() {

        for (int i = 1; i <= 2; i++)
        {
            if (StatAll.stat[1, 2, Turns.order] == i && StatAll.stat[1, 0, Turns.order] <= 8
                && StatAll.stat[1, 0, Turns.order] != 3 && StatAll.stat[1, 0, Turns.order] != 7)
            {
                block[i].SetActive(true);
            }

            else
            {
                block[i].SetActive(false);
            }
        }

        if (StatAll.stat[1, 0, Turns.order] == 3 || StatAll.stat[1, 0, Turns.order] == 7 || StatAll.stat[1, 0, Turns.order] == 12)
        {
            block[3].SetActive(false);
        }

        else if (StatAll.stat[1, 0, Turns.order] >= 5 && StatAll.stat[7, 0, Turns.order] == 0)
        {
            block[3].SetActive(false);
        }

        else if (StatAll.stat[1, 0, Turns.order] >= 8 && StatAll.stat[7, 0, Turns.order] == 1)
        {
            block[3].SetActive(false);
        }

        else if (StatAll.stat[1, 0, Turns.order] >= 11 && StatAll.stat[7, 0, Turns.order] == 2)
        {
            block[3].SetActive(false);
        }

        else
        {
            block[3].SetActive(true);
        }

    }

    public void SelectOne()
    {
        if (StatAll.stat[1,0,Turns.order] != 3 && StatAll.stat[1, 0, Turns.order] != 7 && StatAll.stat[1, 0, Turns.order] != 12)
        {

            Turns.skillshow = false;

            if (StatAll.stat[5, 0, Turns.order] < 3)
            {
                StatAll.stat[5, 0, Turns.order]++;
            }

            StatAll.stat[1, 2, Turns.order] = 1;

        }

        else if(StatAll.stat[1, 0, Turns.order] == 3)
        {
            StatAll.stat[8, 0, Turns.order] = 1;
            Turns.skillshow = false;
            StatAll.stat[1, 2, Turns.order] = 4;
        }

        else if (StatAll.stat[1, 0, Turns.order] == 7)
        {
            StatAll.stat[8, 1, Turns.order] = 1;
            Turns.skillshow = false;
            StatAll.stat[1, 2, Turns.order] = 4;
        }

        else if (StatAll.stat[1, 0, Turns.order] == 12)
        {
            StatAll.stat[8, 2, Turns.order] = 1;
            Turns.skillshow = false;
            StatAll.stat[1, 2, Turns.order] = 4;
        }

        Result();
    }

    public void SelectTwo()
    {
        if (StatAll.stat[1, 0, Turns.order] != 3 && StatAll.stat[1, 0, Turns.order] != 7 && StatAll.stat[1, 0, Turns.order] != 12)
        {

            Turns.skillshow = false;

            if (StatAll.stat[6, 0, Turns.order] < 3)
            {
                StatAll.stat[6, 0, Turns.order]++;
            }

            StatAll.stat[1, 2, Turns.order] = 2;
        }

        else if (StatAll.stat[1, 0, Turns.order] == 3)
        {
            StatAll.stat[8, 0, Turns.order] = 2;
            Turns.skillshow = false;
            StatAll.stat[1, 2, Turns.order] = 4;
        }

        else if (StatAll.stat[1, 0, Turns.order] == 7)
        {
            StatAll.stat[8, 1, Turns.order] = 2;
            Turns.skillshow = false;
            StatAll.stat[1, 2, Turns.order] = 4;
        }

        else if (StatAll.stat[1, 0, Turns.order] == 12)
        {
            StatAll.stat[8, 2, Turns.order] = 2;
            Turns.skillshow = false;
            StatAll.stat[1, 2, Turns.order] = 4;
        }

        Result();
    }

    public void SelectThree()
    {
        if (StatAll.stat[1, 0, Turns.order] != 3 && StatAll.stat[1, 0, Turns.order] != 7 && StatAll.stat[1, 0, Turns.order] != 12)
        { 

            Turns.skillshow = false;

            if (StatAll.stat[7, 0, Turns.order] < 3)
            {
                StatAll.stat[7, 0, Turns.order]++;
            }

            StatAll.stat[1, 2, Turns.order] = 3;
        }

        else if (StatAll.stat[1, 0, Turns.order] == 3)
        {
            StatAll.stat[8, 0, Turns.order] = 3;
            Turns.skillshow = false;
            StatAll.stat[1, 2, Turns.order] = 4;
        }

        else if (StatAll.stat[1, 0, Turns.order] == 7)
        {
            StatAll.stat[8, 1, Turns.order] = 3;
            Turns.skillshow = false;
            StatAll.stat[1, 2, Turns.order] = 4;
        }

        else if (StatAll.stat[1, 0, Turns.order] == 12)
        {
            StatAll.stat[8, 2, Turns.order] = 3;
            Turns.skillshow = false;
            StatAll.stat[1, 2, Turns.order] = 4;
        }

        Result();

    }

    void Result()
    {
        skill.SetActive(false);
    }

}
