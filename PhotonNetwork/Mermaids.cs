using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermaids : Photon.MonoBehaviour
{

    public static int[] stat = { 2, 4, 28, 15 }; //Type, ATK, HP, Range
    public static int skillRange_1 = 20;
    public static int skillRange_2 = 20;
    public static int damage = 0;
    public static PhotonView spawn;

    public bool Q11 = true;
    public static int Q12 = 0;
    public static int Q13 = 0;
    public bool Q21 = true;
    public bool Q22 = true;
    public bool Q31 = true;

    // Use this for initialization
    void Start()
    {
        spawn = this.photonView;
    }

    // Update is called once per frame
    void Update()
    {
        if (ConnectAndJoinRandom.character == 2)
        {
            SetQualify();
        }
    }

    public static void Skill_1()
    {
        if (PlayerInfo.skilllvl[0] > 0)
        {
            if (PlayerInfo.qualify[2] == 2)
            {
                if (PlayerInfo.skilllvl[0] == 1)
                {
                    PlayerInfo.skillcd[0] = 4;
                }

                else if (PlayerInfo.skilllvl[0] == 2)
                {
                    PlayerInfo.skillcd[0] = 3;
                }

                else if (PlayerInfo.skilllvl[0] == 3)
                {
                    PlayerInfo.skillcd[0] = 2;
                }

                AreaATK.Area_ATK_Myself(ConnectAndJoinRandom.character, 1, RandomDie.pad, skillRange_1);
            }

            else
            {
                Choose.Selecting(ConnectAndJoinRandom.character, 1, skillRange_1);
            }

        }
    }

    public static void ACT_Skill_1(int pad)
    {

        if (PlayerInfo.skilllvl[0] == 1)
        {
            PlayerInfo.skillcd[0] = 4;
            damage = 10 + Q12;
        }

        else if (PlayerInfo.skilllvl[0] == 2)
        {
            PlayerInfo.skillcd[0] = 3;
            damage = 50 + Q12;
        }

        else if (PlayerInfo.skilllvl[0] == 3)
        {
            PlayerInfo.skillcd[0] = 2;
            damage = 90 + Q12;
        }

        SingleATK.Single_ATK(pad, damage);
        SingleATK.Slow(pad);
        spawn.RPC("SoundMermaidS1", PhotonTargets.All);
    }

    public static void Skill_2()
    {
        if (PlayerInfo.skilllvl[1] > 0)
        {

            if (PlayerInfo.skilllvl[1] > 1)
            {
                skillRange_2 = 25;
            }
            else
            {
                skillRange_2 = 20;
            }

            if (PlayerInfo.qualify[2] == 2)
            {
                if (PlayerInfo.skilllvl[1] > 2)
                {
                    PlayerInfo.skillcd[1] = 3 - Q13;
                }

                else
                {
                    PlayerInfo.skillcd[1] = 4 - Q13;
                }

                AreaATK.Area_ATK_Myself(ConnectAndJoinRandom.character, 2, RandomDie.pad, skillRange_2);
            }

            else
            {
                Choose.Selecting(ConnectAndJoinRandom.character, 2, skillRange_2);
            }
            
        }
    }

    public static void ACT_Skill_2(int pad)
    {
        if (PlayerInfo.skilllvl[1] > 2)
        {
            PlayerInfo.skillcd[1] = 3 - Q13;
        }

        else
        {
            PlayerInfo.skillcd[1] = 4 - Q13;
        }

        SingleATK.Stun(pad);
        spawn.RPC("SoundMermaidS2", PhotonTargets.All);
    }

    public static void Skill_3()
    {

        if (PlayerInfo.skilllvl[2] > 0)
        {
            spawn.RPC("SpawnUlti", PhotonTargets.MasterClient, RandomDie.pad);

            if (PlayerInfo.skilllvl[2] == 1)
            {
                PlayerInfo.skillcd[2] = 6;
            }

            else if (PlayerInfo.skilllvl[2] == 2)
            {
                PlayerInfo.skillcd[2] = 5;
            }

            else if (PlayerInfo.skilllvl[2] == 3)
            {
                PlayerInfo.skillcd[2] = 4;
            }
        }
    }

    public void SetQualify()
    {
        if (PlayerInfo.qualify[0] == 1)
        {
            if (Q11)
            {
                PlayerInfo.baseatk += 35;
                Q11 = false;
            }
        }

        if (PlayerInfo.qualify[0] == 2)
        {
            Q12 = 30;
        }

        if (PlayerInfo.qualify[0] == 3)
        {
            Q13 = 1;
        }

        if (PlayerInfo.qualify[1] == 1)
        {
            if (Q21)
            {
                PlayerInfo.baseatk += 45;
                Q21 = false;
            }
        }

        if (PlayerInfo.qualify[1] == 2)
        {
            if (Q22)
            {
                PlayerInfo.basehp += 55;
                PlayerInfo.hp = (PlayerInfo.hp * PlayerInfo.basehp) / (PlayerInfo.basehp - 55);
                Q22 = false;
            }
        }

        if (PlayerInfo.qualify[2] == 1)
        {
            if (Q31)
            {
                PlayerInfo.baseatk += 100;
                PlayerInfo.basehp += 100;
                PlayerInfo.hp = (PlayerInfo.hp * PlayerInfo.basehp) / (PlayerInfo.basehp - 100);
                Q31 = false;
            }
        }
    }

    [PunRPC]
    public void SpawnUlti(int pad)
    {

        if (PlayerInfo.qualify[1] == 3)
        {
            PhotonNetwork.InstantiateSceneObject("MermaidUltiUp", Movement.Waypoints[pad].position, Quaternion.Euler(-90, 0, 0), 0, null);
        }

        else
        {
            PhotonNetwork.InstantiateSceneObject("MermaidUlti", Movement.Waypoints[pad].position, Quaternion.Euler(-90, 0, 0), 0, null);
        }
    }

    [PunRPC]
    public void SoundMermaidS1()
    {
        Soundbox.player = 2;
        Soundbox.skill = 1;
        Soundbox.isPlay = true;
    }

    [PunRPC]
    public void SoundMermaidS2()
    {
        Soundbox.player = 2;
        Soundbox.skill = 2;
        Soundbox.isPlay = true;
    }
}
