using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualifyUI : MonoBehaviour {

    public Text q_1;
    public Text q_2;
    public Text q_3;

    public Button qp_1;
    public Button qp_2;
    public Button qp_3;

    public Sprite[] q_goblin;
    public Sprite[] q_mermaid;
    public Sprite[] q_griffon;
    public Sprite[] q_franken;

    public Image[] q_slot;

    public Sprite[] i_goblin;
    public Sprite[] i_mermaid;
    public Sprite[] i_griffon;
    public Sprite[] i_franken;

    //bool[] isUp = {false, false, false};


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        Level_3();
        Level_7();
        Level_12();

        int i, j, count = 0;

        //if ((PlayerInfo.qualify[0] != 0 && !isUp[0]) || (PlayerInfo.qualify[1] != 0 && !isUp[1]) || (PlayerInfo.qualify[2] != 0 && !isUp[2]))
        //{
            if (ConnectAndJoinRandom.character == 1)
            {
                for (i = 0; i < 3; i++)
                {
                    for (j = 1; j < 4; j++)
                    {
                        if (PlayerInfo.qualify[i] == j)
                        {
                            q_slot[i].sprite = i_goblin[count];
                        }

                        count++;
                    }
                }
            }

            else if (ConnectAndJoinRandom.character == 2)
            {
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (PlayerInfo.qualify[i] == j + 1)
                        {
                            q_slot[i].sprite = i_mermaid[count];                            
                        }

                        count++;
                    }
                }
            }

            else if (ConnectAndJoinRandom.character == 3)
            {
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (PlayerInfo.qualify[i] == j + 1)
                        {
                            q_slot[i].sprite = i_griffon[count];                            
                        }

                        count++;
                    }
                }
            }

            else if (ConnectAndJoinRandom.character == 4)
            {
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (PlayerInfo.qualify[i] == j + 1)
                        {
                            q_slot[i].sprite = i_franken[count]; 
                        }

                        count++;
                    }
                }
            }

            /*if (PlayerInfo.qualify[0] != 0 && !isUp[0])
            {
                isUp[0] = true;
            }

            if (PlayerInfo.qualify[1] != 0 && !isUp[1])
            {
                isUp[1] = true;
            }

            if (PlayerInfo.qualify[2] != 0 && !isUp[2])
            {
                isUp[2] = true;
            }*/
        //}

    }

    public void Level_3()
    {
        if (PlayerInfo.level == 3)
        {
            if (ConnectAndJoinRandom.character == 1)
            {
                q_1.text = "+20 Attack";
                q_2.text = "+10 Javelin Shot Range";
                q_3.text = "-5% Shabby Armor Limit";
                qp_1.image.sprite = q_goblin[0];
                qp_2.image.sprite = q_goblin[1];
                qp_3.image.sprite = q_goblin[2];
            }

            else if (ConnectAndJoinRandom.character == 2)
            {
                q_1.text = "+35 Attack";
                q_2.text = "+30 Water Splash DMP";
                q_3.text = "-1 Bubble Cage CD";
                qp_1.image.sprite = q_mermaid[0];
                qp_2.image.sprite = q_mermaid[1];
                qp_3.image.sprite = q_mermaid[2];
            }

            else if (ConnectAndJoinRandom.character == 3)
            {
                q_1.text = "+30 HP";
                q_2.text = "+30 Wind Rush DMP";
                q_3.text = "-1 Air Shield CD";
                qp_1.image.sprite = q_griffon[0];
                qp_2.image.sprite = q_griffon[1];
                qp_3.image.sprite = q_griffon[2];
            }

            else if (ConnectAndJoinRandom.character == 4)
            {
                q_1.text = "+40 HP";
                q_2.text = "+10% Electric Shock Chance";
                q_3.text = "-5 Power Membrane DMP";
                qp_1.image.sprite = q_franken[0];
                qp_2.image.sprite = q_franken[1];
                qp_3.image.sprite = q_franken[2];
            }

            //q_slot[0].sprite = q_up;
        }
    }

    public void Level_7()
    {
        if (PlayerInfo.level == 7)
        {
            if (ConnectAndJoinRandom.character == 1)
            {
                q_1.text = "+125% Javelin Shot DMP";
                q_2.text = "+50 Shabby Armor Shield";
                q_3.text = "+50 Revenge Blood ATK";
                qp_1.image.sprite = q_goblin[3];
                qp_2.image.sprite = q_goblin[4];
                qp_3.image.sprite = q_goblin[5];
            }

            else if (ConnectAndJoinRandom.character == 2)
            {
                q_1.text = "+45 Attack";
                q_2.text = "+55 HP";
                q_3.text = "+5 Fall of Heaven AOE";
                qp_1.image.sprite = q_mermaid[3];
                qp_2.image.sprite = q_mermaid[4];
                qp_3.image.sprite = q_mermaid[5];
            }

            else if (ConnectAndJoinRandom.character == 3)
            {
                q_1.text = "+10 Wind Rush AOE";
                q_2.text = "-1 CD When Cast 2 Skill in Turn";
                q_3.text = "Call of Storm Deal Damage (20/35/50)";
                qp_1.image.sprite = q_griffon[3];
                qp_2.image.sprite = q_griffon[4];
                qp_3.image.sprite = q_griffon[5];
            }

            else if (ConnectAndJoinRandom.character == 4)
            {
                q_1.text = "+40 Attack";
                q_2.text = "+65 HP";
                q_3.text = "-1 Eternal Flesh CD";
                qp_1.image.sprite = q_franken[3];
                qp_2.image.sprite = q_franken[4];
                qp_3.image.sprite = q_franken[5];
            }

            //q_slot[1].sprite = q_up;
        }
    }

    public void Level_12()
    {
        if (PlayerInfo.level == 12)
        {
            if (ConnectAndJoinRandom.character == 1)
            {
                q_1.text = "2 All Skill CD";
                q_2.text = "+250 HP";
                q_3.text = "Permanent Revenge Blood";
                qp_1.image.sprite = q_goblin[6];
                qp_2.image.sprite = q_goblin[7];
                qp_3.image.sprite = q_goblin[8];
            }

            else if (ConnectAndJoinRandom.character == 2)
            {
                q_1.text = "+100 / 100 Stat";
                q_2.text = "Surround Skill (No longer to target enermy)";
                q_3.text = "Fall of Heaven Upgrade (Increse turn and regen)";
                qp_1.image.sprite = q_mermaid[6];
                qp_2.image.sprite = q_mermaid[7];
                qp_3.image.sprite = q_mermaid[8];
            }

            else if (ConnectAndJoinRandom.character == 3)
            {
                q_1.text = "+6 Wind Rush Pads";
                q_2.text = "Air Shield Gain Immune";
                q_3.text = "-2 Call of Storm Pads More";
                qp_1.image.sprite = q_griffon[6];
                qp_2.image.sprite = q_griffon[7];
                qp_3.image.sprite = q_griffon[8];
            }

            else if (ConnectAndJoinRandom.character == 4)
            {
                q_1.text = "+100% Electric Shock Chance";
                q_2.text = "-25 Power Membrane DMP";
                q_3.text = "+100 / 100 % Eternal Flesh";
                qp_1.image.sprite = q_franken[6];
                qp_2.image.sprite = q_franken[7];
                qp_3.image.sprite = q_franken[8];
            }

            //q_slot[2].sprite = q_up;
        }
    }
}
