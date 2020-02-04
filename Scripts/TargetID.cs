using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetID : MonoBehaviour {

    public static int[] targetID = { 0, 1, 2, 3, 4, 5 };
    public GameObject target;
    public static bool targeting;
    public GameObject attack;
    public static int lockTarget;

	// Use this for initialization
	void Start () {

        target.SetActive(false);
        targeting = false;

    }
	
	// Update is called once per frame
	void Update () {

        

    }

    public void Target_1()
    {
        lockTarget = 1;
        Target_all(lockTarget);
    }

    public void Target_2()
    {
        lockTarget = 2;
        Target_all(lockTarget);
    }

    public void Target_3()
    {
        lockTarget = 3;
        Target_all(lockTarget);
    }

    public void Target_4()
    {
        lockTarget = 4;
        Target_all(lockTarget);
    }

    public void Target_5()
    {
        lockTarget = 5;
        Target_all(lockTarget);
    }
    public void Target_all(int ID)
    {

        if (Attack.normal == true)
        {
           
            attack.SetActive(false);

            if (StatAll.stat[2, 2, Turns.order] >= StatAll.stat[4, 0, targetID[ID]])
            {
                StatAll.stat[3, 1, targetID[ID]] = StatAll.stat[3, 1, targetID[ID]] + (StatAll.stat[4, 0, targetID[ID]] - StatAll.stat[2, 2, Turns.order]);
                StatAll.stat[4, 0, targetID[ID]] = 0;
            }

            else
            {
                StatAll.stat[4, 0, targetID[ID]] = StatAll.stat[4, 0, targetID[ID]] - StatAll.stat[2, 2, Turns.order];
            }

        }

        else
        {
            if (StatAll.stat[0, 0, Turns.order] == 1)
            {
                Goblin.Skill_1(targetID[ID]);
            }

            if (StatAll.stat[0, 0, Turns.order] == 2)
            {
                if (AttackSkill.skillnum == 1)
                {
                    Mermaid.Skill_1(targetID[ID]);
                }

                else if (AttackSkill.skillnum == 2)
                {
                    Mermaid.Skill_2(targetID[ID]);
                }
            }

        }

        target.SetActive(false);
        targeting = false;     
    }

    public void Cancel()
    {
        target.SetActive(false);
        targeting = false;
    }
}
