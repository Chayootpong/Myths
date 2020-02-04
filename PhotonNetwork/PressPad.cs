using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPad : Photon.MonoBehaviour {

    public int vars = 0;
    public int invi = -1;

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject[] invipad;

    static int checkChar;
    static int checkST;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void InputVar(int character, int skilltype)
    {
        checkChar = character;
        checkST = skilltype;
    }

    void OnMouseDown()
    {

        Light1.SetActive(true);
        Light2.SetActive(true);
        Light3.SetActive(false);
        Choose.isAim = false;

        for (int i = 0; i < 100; i++)
        {
            invipad[i].SetActive(false);
        }

        if (checkST == 0)
        {
            SingleATK.Single_ATK(vars, PlayerInfo.atk);
            PlayerInfo.attack = false;
        }

        else if (checkChar == 1)
        {
            if (checkST == 1)
            {
                Goblins.ACT_Skill_1(vars);
            }
        }

        else if (checkChar == 2)
        {
            if (checkST == 1)
            {
                Mermaids.ACT_Skill_1(vars);
            }

            else if (checkST == 2)
            {
                Mermaids.ACT_Skill_2(vars);
            }
        }

        else if (checkChar == 4)
        {
            if (checkST == 1)
            {
                Frankenstein.ACT_Skill_1(vars);
            }
        }
    }
}
