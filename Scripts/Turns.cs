using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{

    public static int order;
    //public static bool port;
    public GameObject Red;
    public GameObject Blue;
    public GameObject skill;
    public static bool skillshow;
    public GameObject dice; //Stun Use
    public GameObject attack;
    public static int now_p, before_p;
    public static int round = 0;

    //Stun

    public GameObject stun_1;
    public GameObject stun_2;
    public GameObject stun_3;
    public GameObject stun_atk;

    int x, j;
    int[] reborn  = { 0, 0, 0, 0, 0, 0, 0 };

    // Use this for initialization
    void Start()
    {

        //port = true;
        order = 1;
        skillshow = true;

    }

    // Update is called once per frame
    void Update()
    {

        StatAll.stat[2, 2, order] = StatAll.stat[2, 1, order] + StatAll.stat[2, 0, order];

        if (StatAll.status[order, 0] == true)
        {
            stun_1.SetActive(true);
            stun_2.SetActive(true);
            stun_3.SetActive(true);
            stun_atk.SetActive(true);
            dice.SetActive(false);
        }

        else
        {
            stun_1.SetActive(false);
            stun_2.SetActive(false);
            stun_3.SetActive(false);
            stun_atk.SetActive(false);
        }

    }

    public void Endturn()
    {
        //if (port == false)
        //{
            before_p = order; // เช็คเทิร์น // รอบ // ----- End Turn -----

            StatAll.status[order, 0] = false; //Disable Stun

            OvertimeCount();

            order = (order % 4) + 1; // ----- Start Turn -----

            for (int i = 1; i < 12; i++)
            {
                if (StatAll.stat[3, 1, order] <= 0 && reborn[order] != 1)
                {
                    reborn[order] = 1;
                    order = (order % 4) + 1;
                }
            }

            if (reborn[order] == 1)
            {
                StatAll.stat[3, 1, order] = StatAll.stat[3, 0, order];
                StatAll.stat[2, 0, order] = StatAll.stat[2, 0, order];
                Char_Die.player[order].SetActive(true);
                reborn[order] = 0;

            }

            StatAll.stat[1, 0, order]++;
            skill.SetActive(true);
            skillshow = true;
            //port = true;
            //Dice.waitTime = true;
            dice.SetActive(true);
            attack.SetActive(true);
            now_p = order; // เช็คเทิร์น // รอบ
            UI_ID.ID = order;
            //Dices.Clear();

            StatAll.stat[3, 1, order] = (StatAll.stat[3, 0, order] * StatAll.stat[3, 1, order]) / StatAll.stat[3, 2, order];

            DecreaseCooldown();

            if (now_p < before_p)
            {
                round++;
            }

            StatAll.stat[3, 2, order] = StatAll.stat[3, 0, order];

            if (StatAll.stat[1, 0, order] >= 2 && StatAll.stat[1, 0, order] < 13)
            {

                if (StatAll.stat[0, 1, order] == 1)
                {
                    StatAll.stat[2, 0, order] += 10;
                    StatAll.stat[3, 0, order] += 20;
                   
                }

                else if (StatAll.stat[0, 1, order] == 2)
                {
                    StatAll.stat[2, 0, order] += 7;
                    StatAll.stat[3, 0, order] += 25;
                }

                else if (StatAll.stat[0, 1, order] == 3)
                {
                    StatAll.stat[2, 0, order] += 5;
                    StatAll.stat[3, 0, order] += 30;
                }

                //Debug.Log(StatAll.stat[2, 1, order] + "/" + StatAll.stat[2, 0, order]);

            //}    

        }

    }

    void OvertimeCount()
    {
        j = 0;

        for (x = 1; x <= 6; x++)
        {
            for (j = 0; j <= 35; j++)
            {
                if (StatAll.stat[9, j, x] != 0)
                {
                    Damage();
                    StatAll.stat[10, j, x]--;

                    if (StatAll.stat[10, j, x] == 0)
                    {
                        StatAll.stat[9, j, x] = 0;
                    }
                }
            }
        }

        
    }

    public void Damage()
    { 

        if (StatAll.stat[9, j, x] >= StatAll.stat[4, 0, x])
        {
            StatAll.stat[3, 1, x] = StatAll.stat[3, 1, x] + (StatAll.stat[4, 0, x] - StatAll.stat[9, j, x]);
            StatAll.stat[4, 0, x] = 0;
        }

        else
        {
            StatAll.stat[4, 0, x] = StatAll.stat[4, 0, x] - StatAll.stat[9, j, x];
        }
    }

    void DecreaseCooldown()
    {
        for (int x = 5; x <= 7; x++)
        {
            if (StatAll.stat[x, 2, order] != 0)
            {
                StatAll.stat[x, 2, order]--;
            }
        }
    }
}

