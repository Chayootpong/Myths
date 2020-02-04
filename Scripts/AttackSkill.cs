using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkill : MonoBehaviour {

    public static GameObject target;
    public static float realRange;
    public static GameObject[] block;
    public static int skillnum;

    public GameObject attackTarget;
    public GameObject[] blocks;

    // Use this for initialization
    void Start () {

        target = attackTarget;
        block = blocks;
	}
	
	// Update is called once per frame
	void Update () {      
		
	}

    public static void Attacking(int range, int skill)
    {
        int j = 1;

        for (int i = 1; i <= 5; i++)
        {
            TargetID.targetID[i] = j;
            j++;
        }

        for (int k = Turns.order; k <= 5; k++)
        {
            TargetID.targetID[k]++;
            //Debug.Log(TargetID.targetID[k]);
        }

        target.SetActive(true);
        TargetID.targeting = true;
        Attack.normal = false;

        skillnum = skill;

        Range(range);
        UnableAttack();

    }

    public static void Range(int range)
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

    public static void UnableAttack()
    {

        for (int l = 1; l <= 5; l++)
        {
            if (CheckDistance.distancePlayer[Turns.order, TargetID.targetID[l]] > realRange || StatAll.stat[3, 1, TargetID.targetID[l]] == 0)
            {
                block[l].SetActive(true);
                //Debug.Log("False " + TargetID.targetID[l] + " " + CheckDistance.distancePlayer[Turns.order, TargetID.targetID[l]]);
            }

            else
            {
                block[l].SetActive(false);
                //Debug.Log("True " + TargetID.targetID[l] + " " + CheckDistance.distancePlayer[Turns.order, TargetID.targetID[l]]);
            }

        }
        
    }
}
