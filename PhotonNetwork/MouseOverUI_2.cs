using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverUI_2 : MonoBehaviour
{

    public int qualinum;
    public GameObject qualify;
    public Text qualify_info;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Qualify_1()
    {

        if (PlayerInfo.qualify[0] == 0)
        {
            qualify.SetActive(false);
        }

        else
        {
            qualify.SetActive(true);

            if (qualinum == 1)
            {
                if (ConnectAndJoinRandom.character == 1)
                {
                    if (PlayerInfo.qualify[0] == 1)
                    {
                        qualify_info.text = "+20 Attack";
                    }

                    else if (PlayerInfo.qualify[0] == 2)
                    {
                        qualify_info.text = "+10 Javelin Shot Range";
                    }

                    else if (PlayerInfo.qualify[0] == 3)
                    {
                        qualify_info.text = "Shabby Armor -5% Limit";
                    }
                }

                else if (ConnectAndJoinRandom.character == 2)
                {
                    if (PlayerInfo.qualify[0] == 1)
                    {
                        qualify_info.text = "+35 Attack";
                    }

                    else if (PlayerInfo.qualify[0] == 2)
                    {
                        qualify_info.text = "+30 Water Splash DMP";
                    }

                    else if (PlayerInfo.qualify[0] == 3)
                    {
                        qualify_info.text = "-1 Bubble Cage CD";
                    }
                }

                else if (ConnectAndJoinRandom.character == 3)
                {
                    if (PlayerInfo.qualify[0] == 1)
                    {
                        qualify_info.text = "+30 HP";
                    }

                    else if (PlayerInfo.qualify[0] == 2)
                    {
                        qualify_info.text = "+30 Wind Rush DMP";
                    }

                    else if (PlayerInfo.qualify[0] == 3)
                    {
                        qualify_info.text = "-1 Air Shield CD";
                    }
                }

                else if (ConnectAndJoinRandom.character == 4)
                {
                    if (PlayerInfo.qualify[0] == 1)
                    {
                        qualify_info.text = "+40 HP";
                    }

                    else if (PlayerInfo.qualify[0] == 2)
                    {
                        qualify_info.text = "+10% Electric Shock Chance";
                    }

                    else if (PlayerInfo.qualify[0] == 3)
                    {
                        qualify_info.text = "-5 Power Membrane DMP";
                    }
                }
            }
        }
    }

    public void Qualify_2()
    {

        if (PlayerInfo.qualify[1] == 0)
        {
            qualify.SetActive(false);
        }

        else
        {
            qualify.SetActive(true);

            if (qualinum == 2)
            {
                if (ConnectAndJoinRandom.character == 1)
                {
                    if (PlayerInfo.qualify[1] == 1)
                    {
                        qualify_info.text = "+125% Javelin Shot DMP";
                    }

                    else if (PlayerInfo.qualify[1] == 2)
                    {
                        qualify_info.text = "Shabby Armor + 50 Shield";
                    }

                    else if (PlayerInfo.qualify[1] == 3)
                    {
                        qualify_info.text = "+50 Revenge Blood ATK";
                    }
                }

                else if (ConnectAndJoinRandom.character == 2)
                {
                    if (PlayerInfo.qualify[1] == 1)
                    {
                        qualify_info.text = "+45 Attack";
                    }

                    else if (PlayerInfo.qualify[1] == 2)
                    {
                        qualify_info.text = "+55 HP";
                    }

                    else if (PlayerInfo.qualify[1] == 3)
                    {
                        qualify_info.text = "+5 Range Fall of Heaven";
                    }
                }

                else if (ConnectAndJoinRandom.character == 3)
                {
                    if (PlayerInfo.qualify[1] == 1)
                    {
                        qualify_info.text = "+10 Wind Rush AOE";
                    }

                    else if (PlayerInfo.qualify[1] == 2)
                    {
                        qualify_info.text = "-1 CD When Cast 2 Skill in Turn";
                    }

                    else if (PlayerInfo.qualify[1] == 3)
                    {
                        qualify_info.text = "Call of Storm Deal Damage";
                    }
                }

                else if (ConnectAndJoinRandom.character == 4)
                {
                    if (PlayerInfo.qualify[1] == 1)
                    {
                        qualify_info.text = "+40 Attack";
                    }

                    else if (PlayerInfo.qualify[1] == 2)
                    {
                        qualify_info.text = "+65 HP";
                    }

                    else if (PlayerInfo.qualify[1] == 3)
                    {
                        qualify_info.text = "-1 Eternal Flesh CD";
                    }
                }
            }
        }
    }

    public void Qualify_3()
    {
        if (PlayerInfo.qualify[2] == 0)
        {
            qualify.SetActive(false);
        }

        else
        {
            qualify.SetActive(true);

            if (qualinum == 3)
            {
                if (ConnectAndJoinRandom.character == 1)
                {
                    if (PlayerInfo.qualify[2] == 1)
                    {
                        qualify_info.text = "-2 All Skill CD";
                    }

                    else if (PlayerInfo.qualify[2] == 2)
                    {
                        qualify_info.text = "+250 HP";
                    }

                    else if (PlayerInfo.qualify[2] == 3)
                    {
                        qualify_info.text = "Permanent Revenge Blood";
                    }
                }


                else if (ConnectAndJoinRandom.character == 2)
                {
                    if (PlayerInfo.qualify[2] == 1)
                    {
                        qualify_info.text = "+100 / 100 Stat";
                    }

                    else if (PlayerInfo.qualify[2] == 2)
                    {
                        qualify_info.text = "Surround Skill";
                    }

                    else if (PlayerInfo.qualify[2] == 3)
                    {
                        qualify_info.text = "Fall of Heaven Upgrade";
                    }
                }

                else if (ConnectAndJoinRandom.character == 3)
                {
                    if (PlayerInfo.qualify[2] == 1)
                    {
                        qualify_info.text = "+6 Wind Rush Pads";
                    }

                    else if (PlayerInfo.qualify[2] == 2)
                    {
                        qualify_info.text = "Air Shield Gain Immune";
                    }

                    else if (PlayerInfo.qualify[2] == 3)
                    {
                        qualify_info.text = "Call of Storm -2 Pads More";
                    }
                }

                else if (ConnectAndJoinRandom.character == 4)
                {
                    if (PlayerInfo.qualify[2] == 1)
                    {
                        qualify_info.text = "+100% Electric Shock Chance";
                    }

                    else if (PlayerInfo.qualify[2] == 2)
                    {
                        qualify_info.text = "Power Membrane -15 DMP ";
                    }

                    else if (PlayerInfo.qualify[2] == 3)
                    {
                        qualify_info.text = "+100 / 100 % Eternal Flesh";
                    }
                }
            }
        }
    }

    public void PointOut()
    {
        qualify.SetActive(false);
    }
}
