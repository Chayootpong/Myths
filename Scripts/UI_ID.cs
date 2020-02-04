using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ID : MonoBehaviour {

    public static int ID;
    public Text ATK;
    public Text MaxHP;
    public Text HP;
    public Text names;
    public Text shield;
    public Text CDC_1;
    public Text CDC_2;
    public Text CDC_3;
    public Text level;
    public GameObject CD_1;
    public GameObject CD_2;
    public GameObject CD_3;
    public GameObject bigBlock;

    // Use this for initialization
    void Start () {

        ID = 1;
		
	}
	
	// Update is called once per frame
	void Update () {

        ATK.text = StatAll.stat[2, 2, ID].ToString();
        MaxHP.text = StatAll.stat[3, 0, ID].ToString();
        HP.text = StatAll.stat[3, 1, ID].ToString();
        shield.text = StatAll.stat[4, 0, ID].ToString();
        CDC_1.text = StatAll.stat[5, 2, ID].ToString();
        CDC_2.text = StatAll.stat[6, 2, ID].ToString();
        CDC_3.text = StatAll.stat[7, 2, ID].ToString();
        //Debug.Log(StatAll.stat[4, 0, 1]);

        if (StatAll.stat[0, 0, ID] == 1)
        {
            names.text = "Goblin" + ID.ToString();
        }

        if (StatAll.stat[0, 0, ID] == 2)
        {
            names.text = "Mermaid" + ID.ToString();
        }

        BlockingTurn();
        BlockingSkill();

    }

    void BlockingTurn()
    {
        if (Turns.order != ID)
        {
            bigBlock.SetActive(true);
        }

        else
        {
            bigBlock.SetActive(false);
        }
    }

    void BlockingSkill()
    {
        if (StatAll.stat[5, 2, ID] == 0 && StatAll.stat[5, 0, ID] != 0)
        {
            CD_1.SetActive(false);
        }

        else
        {
            CD_1.SetActive(true);
        }

        if (StatAll.stat[6, 2, ID] == 0 && StatAll.stat[6, 0, ID] != 0)
        {
            CD_2.SetActive(false);
        }

        else
        {
            CD_2.SetActive(true);
        }

        if (StatAll.stat[7, 2, ID] == 0 && StatAll.stat[7, 0, ID] != 0)
        {
            CD_3.SetActive(false);
        }

        else
        {
            CD_3.SetActive(true);
        }
    }

    public void ID_1()
    {
        ID = 1;
    }

    public void ID_2()
    {
        ID = 2;
    }

    public void ID_3()
    {
        ID = 3;
    }

    public void ID_4()
    {
        ID = 4;
    }

    public void ID_5()
    {
        ID = 5;
    }

    public void ID_6()
    {
        ID = 6;
    }
}
