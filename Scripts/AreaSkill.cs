using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSkill : MonoBehaviour {

    public static float realRange;
    public static bool[] target;
    public static int skillnum;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void AttackArea(int range, int skill)
    {

        skillnum = skill;

        AreaRange(range);
        ResultTarget();
        ReturnSkill();

    }

    public static void AreaRange(int range)
    {
        if (range == 1)
        {
            realRange = 4.5f;
        }

        else if (range == 2)
        {
            realRange = 9f;
        }

        else if (range == 3)
        {
            realRange = 13.5f;
        }
    }

    public static void ResultTarget()
    {
        for (int l = 1; l <= 6; l++)
        {
            if (CheckDistance.distancePlayer[Turns.order, l] > realRange || StatAll.stat[3, 1, l] == 0)
            {
                target[l] = false;
            }

            else
            {
                target[l] = true;
            }

        }

    }

    public static void ReturnSkill()
    {
        if (StatAll.stat[0, 0, Turns.order] == 2)
        {
            if (AttackSkill.skillnum == 1)
            {
                Mermaid.Skill_1_Area(target);
            }

            else if (AttackSkill.skillnum == 2)
            {
                Mermaid.Skill_2_Area(target);
            }
        }
    }


}
