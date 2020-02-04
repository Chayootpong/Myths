using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject target;
    float realRange;
    //bool[] unableTarget = new bool[7];
    public GameObject[] block;
    public static bool normal = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {      
		
	}

    public void Attacking()
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
            
        }

        target.SetActive(true);
        TargetID.targeting = true;
        normal = true;

        Range();
        UnableAttack();

    }

    void Range()
    {
        if (StatAll.stat[0, 2, Turns.order] == 1)
        {
            realRange = 4.5f;
        }

        else if (StatAll.stat[0, 2, Turns.order] == 2)
        {
            realRange = 9f;
        }

        else if (StatAll.stat[0, 2, Turns.order] == 3)
        {
            realRange = 13.5f;
        }

    }

    void UnableAttack()
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
