using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermaid : MonoBehaviour {

    public static int[] stat = { 2, 4, 28, 2 };
    public static int damage;
    public Transform[] mermaid;
    public GameObject ultimate;
    public GameObject ultimateUp;
    public static int[] s3 = new int[2];// round,order

    bool C31 = false;
    public static int C32 = 0;
    int C33;
    bool C71 = false;
    bool C72 = false;
    bool C73 = false;
    bool C121 = false;
    bool C122 = false;
    // Challenge 12, 3 อยู่ใน Ulti Mermaid 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Upskill_1();
        Upskill_2();
        Upskill_3();

        if (StatAll.stat[8, 0, Turns.order] == 1)
        {
            if (C31 == false)
            {
                StatAll.stat[2, 0, Turns.order] = StatAll.stat[2, 0, Turns.order] + 35;
                C31 = true;
            }
        }

        if (StatAll.stat[8, 0, Turns.order] == 2)
        {
            C32 = 30;
        }

        if (StatAll.stat[8, 0, Turns.order] == 3)
        {
            C33 = 1;
        }

        if (StatAll.stat[8, 1, Turns.order] == 1)
        {
            if (C71 == false)
            {
                StatAll.stat[2, 0, Turns.order] = StatAll.stat[2, 0, Turns.order] + 45;
                C71 = true;
            }
        }

        if (StatAll.stat[8, 1, Turns.order] == 2)
        {
            if (C72 == false)
            {
                StatAll.stat[3, 0, Turns.order] += 55;
                StatAll.stat[3, 1, Turns.order] = (StatAll.stat[3, 0, Turns.order] * StatAll.stat[3, 1, Turns.order]) / StatAll.stat[3, 2, Turns.order];
                C72 = true;
            }
        }

        if (StatAll.stat[8, 1, Turns.order] == 3)
        {
            C73 = true;
        }

        if (StatAll.stat[8, 2, Turns.order] == 1)
        {
            if (C121 == false)
            {
                StatAll.stat[2, 0, Turns.order] = StatAll.stat[2, 0, Turns.order] + 100;
                StatAll.stat[3, 0, Turns.order] += 100;
                StatAll.stat[3, 1, Turns.order] = (StatAll.stat[3, 0, Turns.order] * StatAll.stat[3, 1, Turns.order]) / StatAll.stat[3, 2, Turns.order];
                C121 = true;
            }
        }

        if (StatAll.stat[8, 2, Turns.order] == 2)
        {
            C122 = true;
        }

    }

    public void Skill_1_click()
    {
        if (StatAll.stat[0, 0, Turns.order] == 2)
        {
            if (C122 == true)
            {
                AreaSkill.AttackArea(StatAll.stat[5, 3, Turns.order], 1);
            }
            else
            {
                AttackSkill.Attacking(StatAll.stat[5, 3, Turns.order], 1);
            }
               
        }
        
    }

    public void Skill_2_click()
    {
        if (StatAll.stat[0, 0, Turns.order] == 2)
        {
            if (C122 == true)
            {
                AreaSkill.AttackArea(StatAll.stat[6, 3, Turns.order], 2);
            }

            else
            {
                AttackSkill.Attacking(StatAll.stat[6, 3, Turns.order], 2);
            }
            
        }
    }

    public void Skill_3_click()
    {

        s3[0] = Turns.round;
        s3[1] = Turns.order;

        if (C73 == true)
        {
            Instantiate(ultimateUp, mermaid[Turns.order].position, mermaid[Turns.order].rotation);
        }

        else
        {
            Instantiate(ultimate, mermaid[Turns.order].position, mermaid[Turns.order].rotation);
        }

        StatAll.stat[7, 2, Turns.order] = StatAll.stat[7, 1, Turns.order];

    }

    public static void Skill_1(int target)
    {

        damage = 0;

        if (StatAll.stat[5, 0, Turns.order] == 1)
        {
            damage = 10 + C32;
        }

        else if (StatAll.stat[5, 0, Turns.order] == 2)
        {
            damage = 50 + C32;
        }

        else if (StatAll.stat[5, 0, Turns.order] == 3)
        {
            damage = 90 + C32;
        }

        StatAll.status[target, 1] = true;

        Damage(target, damage);

        StatAll.stat[5, 2, Turns.order] = StatAll.stat[5, 1, Turns.order];

    }

    public static void Skill_1_Area(bool[] target)
    {
        damage = 0;

        if (StatAll.stat[5, 0, Turns.order] == 1)
        {
            damage = 10 + C32;
        }

        else if (StatAll.stat[5, 0, Turns.order] == 2)
        {
            damage = 50 + C32;
        }

        else if (StatAll.stat[5, 0, Turns.order] == 3)
        {
            damage = 90 + C32;
        }

        for (int x = 1; x <= 6; x++)
        {
            if (target[x] == true)
            {
                StatAll.status[x, 1] = true;
                Damage(x, damage);
            }
        }

        StatAll.stat[5, 2, Turns.order] = StatAll.stat[5, 1, Turns.order];
    }

    public static void Skill_2(int target)
    {

        StatAll.status[target, 0] = true;

        StatAll.stat[6, 2, Turns.order] = StatAll.stat[6, 1, Turns.order];

    }

    public static void Skill_2_Area(bool[] target)
    {
        for (int x = 1; x <= 6; x++)
        {
            if (target[x] == true)
            {
                StatAll.status[x, 0] = true;
            }
        }

        StatAll.stat[6, 2, Turns.order] = StatAll.stat[6, 1, Turns.order];
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
        if (StatAll.stat[0, 0, Turns.order] == 2)
        {
            if (StatAll.stat[5, 0, Turns.order] == 1)
            {
                StatAll.stat[5, 1, Turns.order] = 4;
                StatAll.stat[5, 3, Turns.order] = 2;
            }

            else if (StatAll.stat[5, 0, Turns.order] == 2)
            {
                StatAll.stat[5, 1, Turns.order] = 3;
                StatAll.stat[5, 3, Turns.order] = 2;
            }

            else if (StatAll.stat[5, 0, Turns.order] == 3)
            {
                StatAll.stat[5, 1, Turns.order] = 2;
                StatAll.stat[5, 3, Turns.order] = 2;
            }
        }
    }

    void Upskill_2()
    {
        if (StatAll.stat[0, 0, Turns.order] == 2)
        {
            if (StatAll.stat[6, 0, Turns.order] == 1)
            {
                StatAll.stat[6, 1, Turns.order] = 4 - C33;
                StatAll.stat[6, 3, Turns.order] = 2;
            }

            else if (StatAll.stat[6, 0, Turns.order] == 2)
            {
                StatAll.stat[6, 1, Turns.order] = 4 - C33;
                StatAll.stat[6, 3, Turns.order] = 3;
            }

            else if (StatAll.stat[6, 0, Turns.order] == 3)
            {
                StatAll.stat[6, 1, Turns.order] = 3 - C33;
                StatAll.stat[6, 3, Turns.order] = 3;
            }
        }
    }

    void Upskill_3()
    {
        if (StatAll.stat[0, 0, Turns.order] == 2)
        {
            if (StatAll.stat[7, 0, Turns.order] == 1)
            {
                StatAll.stat[7, 1, Turns.order] = 6;
            }

            else if (StatAll.stat[7, 0, Turns.order] == 2)
            {
                StatAll.stat[7, 1, Turns.order] = 5;
            }

            else if (StatAll.stat[7, 0, Turns.order] == 3)
            {
                StatAll.stat[7, 1, Turns.order] = 4;
            }
        }
    }
}
