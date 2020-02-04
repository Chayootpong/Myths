using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseChar : MonoBehaviour {

    public int player;

    public Text _name;
    public Text _diff;
    public Text _type;
    public Text _sk1;
    public Text _sk2;
    public Text _sk3;
    public Text _sk1_info;
    public Text _sk2_info;
    public Text _sk3_info;

    public GameObject[] character;
    public Image[] skill;

    public Sprite[] s_goblin;
    public Sprite[] s_mermaid;
    public Sprite[] s_griffon;
    public Sprite[] s_franken;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectChar()
    {
        if (player == 1)
        {
            Running(0);
            ConnectAndJoinRandom.character = 1;
            _name.text = "GOBLIN";
            _diff.text = "Difficulty : Easy";
            _type.text = "AGGRO";
            _sk1.text = "JAVELIN SHOT";
            _sk2.text = "SHABBY ARMOR";
            _sk3.text = "REVENGE BLOOD";
            _sk1_info.text = "Throw javelin that deal damage";
            _sk2_info.text = "Gain armor when damaged";
            _sk3_info.text = "Increase massive attack";

            for (int j = 0; j < 3; j++)
            {
                skill[0].sprite = s_goblin[0];
                skill[1].sprite = s_goblin[1];
                skill[2].sprite = s_goblin[2];
            }
        }

        else if (player == 2)
        {
            Running(1);
            ConnectAndJoinRandom.character = 2;
            _name.text = "MERMAID";
            _diff.text = "Difficulty : Hard";
            _type.text = "DEFENSE";
            _sk1.text = "WATER SPLASH";
            _sk2.text = "BUBBLE CAGE";
            _sk3.text = "FALL OF HEAVEN";
            _sk1_info.text = "Splash tide that slow an enermy";
            _sk2_info.text = "Stun an enermy";
            _sk3_info.text = "Cast holy area that regen HP overtime";

            for (int j = 0; j < 3; j++)
            {
                skill[0].sprite = s_mermaid[0];
                skill[1].sprite = s_mermaid[1];
                skill[2].sprite = s_mermaid[2];
            }
        }

        else if (player == 3)
        {
            Running(2);
            ConnectAndJoinRandom.character = 3;
            _name.text = "GRIFFON";
            _diff.text = "Difficulty : Medium";
            _type.text = "BALANCE";
            _sk1.text = "WIND RUSH";
            _sk2.text = "AIR SHIELD";
            _sk3.text = "CALL OF STORM";
            _sk1_info.text = "Move toward and deal damage when landing";
            _sk2_info.text = "Gain aimproof buff";
            _sk3_info.text = "Create the storm that blow other players";

            for (int j = 0; j < 3; j++)
            {
                skill[0].sprite = s_griffon[0];
                skill[1].sprite = s_griffon[1];
                skill[2].sprite = s_griffon[2];
            }
        }

        else if (player == 4)
        {
            Running(3);
            ConnectAndJoinRandom.character = 4;
            _name.text = "FRANKENSTEIN";
            _diff.text = "Difficulty : Medium";
            _type.text = "DEFENSE";
            _sk1.text = "ELECTRIC SHOCK";
            _sk2.text = "POWER MEMBRANE";
            _sk3.text = "ETERNAL FLESH";
            _sk1_info.text = "Taser an enermy, debuff it";
            _sk2_info.text = "Ruduce incoming damage";
            _sk3_info.text = "Increase stat by multiply";

            for (int j = 0; j < 3; j++)
            {
                skill[0].sprite = s_franken[0];
                skill[1].sprite = s_franken[1];
                skill[2].sprite = s_franken[2];
            }
        }
    }

    public void Running(int player)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == player)
            {
                character[i].SetActive(true);
            }

            else
            {
                character[i].SetActive(false);
            }
        }
    }
}
