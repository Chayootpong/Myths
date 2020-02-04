using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour {

    public static int[] stat = { 1, 4, 22, 1 };
    public static int damage;
    int[] temp = new int[7];
    float[] stack = new float[7];
    bool S2onece = true;

    bool C31 = false;
    int C32 = 0;
    float C33 = 0;
    public static int C71 = 0;
    int C72 = 0;
    int C73 = 0;
    bool C122 = false;
    int C123 = 0;
    // Use this for initialization

    void Start() {
        

    }

    // Update is called once per frame
    void Update() {

        Skill_2();
        Upskill_1();
        Upskill_3();

        if (StatAll.stat[8, 0, Turns.order] == 1)
        {
            if (C31 == false)
            {
                StatAll.stat[2, 0, Turns.order] = StatAll.stat[2, 0, Turns.order] + 40;
                C31 = true;
            }
        }

        if (StatAll.stat[8, 0, Turns.order] == 2)
        {
            C32 = 1;
        }

        if (StatAll.stat[8, 1, Turns.order] == 1)
        {
            C71 = 5;
        }

        if (StatAll.stat[8, 1, Turns.order] == 3)
        {
            C73 = 50;
        }

        if (StatAll.stat[8, 2, Turns.order] == 1)
        {
            StatAll.stat[5, 1, Turns.order] = 1;
            StatAll.stat[7, 1, Turns.order] = 2;
        }

        if (StatAll.stat[8, 2, Turns.order] == 2)
        {
            if (C122 == false)
            {
                StatAll.stat[3, 0, Turns.order] += 250;
                StatAll.stat[3, 1, Turns.order] = (StatAll.stat[3, 0, Turns.order] * StatAll.stat[3, 1, Turns.order]) / StatAll.stat[3, 2, Turns.order];
                C122 = true;
            }
        }

        if (StatAll.stat[8, 2, Turns.order] == 3)
        {
            C123 = 2;
        }

    }
    public void Skill_1_click()
    {
        if (StatAll.stat[0, 0, Turns.order] == 1)
        {
            AttackSkill.Attacking(StatAll.stat[5, 3, Turns.order] + C32, 1);
        }
    }

    public void Skill_3_click()
    {
        if (StatAll.stat[0, 0, Turns.order] == 1)
        {
            if (StatAll.stat[7, 0, Turns.order] == 1)
            {
                StatAll.stat[2, 2 - C123, Turns.order] = StatAll.stat[2, 2, Turns.order] + 100 + C73;
            }

            else if (StatAll.stat[7, 0, Turns.order] == 2)
            {
                StatAll.stat[2, 2 - C123, Turns.order] = StatAll.stat[2, 2, Turns.order] + 150 + C73;
            }

            else if (StatAll.stat[7, 0, Turns.order] == 3)
            {
                StatAll.stat[2, 2 - C123, Turns.order] = StatAll.stat[2, 2, Turns.order] + 200 + C73;
            }
        }

        StatAll.stat[7, 2, Turns.order] = StatAll.stat[7, 1, Turns.order];
    }

    public static void Skill_1(int target)
    {
        
        int x = 0;
        damage = 0;

        if (StatAll.stat[5, 0, Turns.order] == 1)
        {
            damage = 10 + StatAll.stat[2, 2, Turns.order];
        }

        else if (StatAll.stat[5, 0, Turns.order] == 2)
        {
            damage = 30 + StatAll.stat[2, 2, Turns.order];
        }

        else if (StatAll.stat[5, 0, Turns.order] == 3)
        {
            damage = 50 + StatAll.stat[2, 2, Turns.order];
        }

        Damage(target, damage);

        while (true)
        {

            if (StatAll.stat[9, x, target] == 0)
            {

                if (StatAll.stat[5, 0, Turns.order] == 1)
                {
                    StatAll.stat[9, x, target] = 5 + C71;
                }

                else if (StatAll.stat[5, 0, Turns.order] == 2)
                {
                    StatAll.stat[9, x, target] = 10 + C71;
                }

                else if (StatAll.stat[5, 0, Turns.order] == 3)
                {
                    StatAll.stat[9, x, target] = 15 + C71;
                }

                StatAll.stat[10, x, target] = 6;
                break;

            }

            else
            {
                x++;
            }
        }

        StatAll.stat[5, 2, Turns.order] = StatAll.stat[5, 1, Turns.order];

    }

    void Skill_2()
    {
        for (int x = 1; x <= 6; x++)
        {
            if (StatAll.stat[0, 0, x] == 1)
            {
                if (StatAll.stat[6, 0, x] > 0)
                {
                    if (S2onece == true)
                    {
                        temp[x] = StatAll.stat[3, 1, x];
                        stack[x] = 0;
                        S2onece = false;
                    }

                    if (StatAll.stat[3, 1, x] >= 0)
                    {
                        stack[x] = 0;
                    }

                    if (StatAll.stat[8, 0, x] == 3)
                    {
                        C33 = 0.05f;
                    }

                    if (StatAll.stat[8, 1, x] == 2)
                    {
                        C72 = 50;
                    }

                    if (temp[x] < StatAll.stat[3, 1, x])
                    {
                        temp[x] = StatAll.stat[3, 1, x];
                    }

                    else if (temp[x] > StatAll.stat[3, 1, x])
                    { 
                        stack[x] += (temp[x] - StatAll.stat[3, 1, x]);
                        temp[x] = StatAll.stat[3, 1, x];

                        if (StatAll.stat[6, 0, x] == 1)
                        {
                            if (stack[x]  >=  StatAll.stat[3, 0, x] * (0.4f - C33))
                            {
                                StatAll.stat[4, 0, x] += 50 + C72;
                                stack[x] = 0;
                            }

                        }
                        if (StatAll.stat[6, 0, x] == 2)
                        {
                            if (stack[x] >= StatAll.stat[3, 0, x] * (0.3f - C33))
                            {
                                StatAll.stat[4, 0, x] += 100 + C72;
                                stack[x] = 0;
                            }

                        }
                        if (StatAll.stat[6, 0, x] == 3)
                        {
                            if (stack[x] >= StatAll.stat[3, 0, x] * (0.2f - C33))
                            {
                                StatAll.stat[4, 0, x] += 150 + C72;
                                stack[x] = 0;
                            }
                        }
                    }
                }
            }
        }
    }


    public static void Damage(int target, int damage)
    {

        if (damage >= StatAll.stat[4, 0, target])
        {
            StatAll.stat[3, 1, target] = StatAll.stat[3, 1, target] + (StatAll.stat[4, 0, target] - damage);
            StatAll.stat[4, 0, target] = 0;
        }

        else
        {
            StatAll.stat[4, 0, target] = StatAll.stat[4, 0, target] - damage;
        }
    }

    void Upskill_1()
    {
        if (StatAll.stat[0, 0, Turns.order] == 1)
        {
            if (StatAll.stat[5, 0, Turns.order] > 0)
            {
                StatAll.stat[5, 1, Turns.order] = 3;
                StatAll.stat[5, 3, Turns.order] = 2;
            }
        }  
    }

    void Upskill_3()
    {
        if (StatAll.stat[0, 0, Turns.order] == 1)
        {
            if (StatAll.stat[7, 0, Turns.order] > 0)
            {
                StatAll.stat[7, 1, Turns.order] = 4;
            }
        }
    }

}
