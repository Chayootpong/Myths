using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblins : Photon.MonoBehaviour {

    public static int[] stat = {1, 4, 22, 10}; //Type, ATK, HP, Range
    public static int skillRange = 20;
    public static int damage = 0;

    public static int stack = 0;
    public static int temp = 0;
    public static int testhold = 0;
    public static int shield;

    public static PhotonView gain;

    public bool Q11 = true;
    public static float Q13 = 0f;
    public static float Q21 = 1f;
    public static int Q22 = 0;
    public static int Q23 = 0;
    public static int Q31 = 0;
    public bool Q32 = true;
    public static bool Q33 = false;

    // Use this for initialization
    void Start () {

        gain = this.photonView;

    }
	
	// Update is called once per frame
	void Update () {

        if (ConnectAndJoinRandom.character == 1)
        {
            if (ConnectAndJoinRandom.createRoom == true)
            {
                Skill_2();
            }

            SetQualify();
        }
	}

    public static void Skill_1()
    {
        if (PlayerInfo.skilllvl[0] > 0)
        {
            Choose.Selecting(ConnectAndJoinRandom.character, 1, skillRange);
        }
    }

    public static void ACT_Skill_1(int pad)
    {

        if (PlayerInfo.skilllvl[0] == 1)
        {
            damage = (int)(10 + (PlayerInfo.atk * 0.75) * Q21);
        }

        else if (PlayerInfo.skilllvl[0] == 2)
        {
            damage = (int)((30 + PlayerInfo.atk) * Q21);
        }

        else if (PlayerInfo.skilllvl[0] == 3)
        {
            damage = (int)(50 + (PlayerInfo.atk * 1.25) * Q21);
        }

        SingleATK.Single_ATK(pad, damage);
        PlayerInfo.skillcd[0] = 3 - Q31;
        gain.RPC("SoundGoblinS1", PhotonTargets.All);
    }

    public static void Skill_2()
    {

        if (temp > PlayerInfo.hp)
        {
            stack = stack + (temp - PlayerInfo.hp);
            temp = PlayerInfo.hp;
            //gain.RPC("GainArmor", PhotonTargets.All, testhold, shield);
            GainArmor(testhold, shield);
        }

        else if (temp < PlayerInfo.hp)
        {
            temp = PlayerInfo.hp;
        }

        if (PlayerInfo.skilllvl[1] == 1)
        {
            testhold = (int)(PlayerInfo.basehp * (0.4 - Q13));
            shield = 50 + Q22;
        }

        else if (PlayerInfo.skilllvl[1] == 2)
        {
            testhold = (int)(PlayerInfo.basehp * (0.3 - Q13));
            shield = 100 + Q22;
        }

        else if (PlayerInfo.skilllvl[1] == 3)
        {
            testhold = (int)(PlayerInfo.basehp * (0.2 - Q13));
            shield = 150 + Q22;
        }

    }

    public static void Skill_3()
    {
        if (PlayerInfo.skilllvl[2] > 0)
        {
            if (Q33)
            {
                if (PlayerInfo.skilllvl[2] == 1)
                {
                    PlayerInfo.baseatk += 50 + Q23;
                }

                else if (PlayerInfo.skilllvl[2] == 2)
                {
                    PlayerInfo.baseatk += 100 + Q23;
                }

                else if (PlayerInfo.skilllvl[2] == 3)
                {
                    PlayerInfo.baseatk += 150 + Q23;
                }
            }

            else
            {
                if (PlayerInfo.skilllvl[2] == 1)
                {
                    PlayerInfo.addatk += 50 + Q23;
                }

                else if (PlayerInfo.skilllvl[2] == 2)
                {
                    PlayerInfo.addatk += 100 + Q23;
                }

                else if (PlayerInfo.skilllvl[2] == 3)
                {
                    PlayerInfo.addatk += 150 + Q23;
                }
            }

            PlayerInfo.skillcd[2] = 4 - Q31;
            gain.RPC("SoundGoblinS3", PhotonTargets.All);
        }
    }

    public void SetQualify()
    {
        if (PlayerInfo.qualify[0] == 1)
        {
            if (Q11)
            {
                PlayerInfo.baseatk += 20;
                Q11 = false;
            }
        }

        if (PlayerInfo.qualify[0] == 2)
        {
            skillRange = 30;
        }

        if (PlayerInfo.qualify[0] == 3)
        {
            Q13 = 0.05f;
        }

        if (PlayerInfo.qualify[1] == 1)
        {
            Q21 = 1.25f;
        }

        if (PlayerInfo.qualify[1] == 2)
        {
            Q22 = 50;
        }

        if (PlayerInfo.qualify[1] == 3)
        {
            Q23 = 50;
        }

        if (PlayerInfo.qualify[2] == 1)
        {
            Q31 = 2;
        }

        if (PlayerInfo.qualify[2] == 2)
        {
            if (Q32)
            {
                PlayerInfo.basehp += 250;
                PlayerInfo.hp = (PlayerInfo.hp * PlayerInfo.basehp) / (PlayerInfo.basehp - 250);
                Q32 = false;
            }
        }

        if (PlayerInfo.qualify[2] == 3)
        {
            Q33 = true;
        }
    }

    public static void GainArmor(int testhold, int shield)
    {
        if (stack > testhold)
        {
            PlayerInfo.shield += shield;
            stack = 0;
        }
    }

    [PunRPC]
    public void SoundGoblinS1()
    {
        Soundbox.player = 1;
        Soundbox.skill = 1;
        Soundbox.isPlay = true;
    }

    [PunRPC]
    public void SoundGoblinS3()
    {
        Soundbox.player = 1;
        Soundbox.skill = 3;
        Soundbox.isPlay = true;
    }
}

