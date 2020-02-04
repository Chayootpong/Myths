using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frankenstein : Photon.MonoBehaviour
{

    public static int[] stat = { 2, 5, 39, 10 }; //Type, ATK, HP, Range
    public static int skillRange = 20;
    public static int damage, chance, defatk, defhp, turn, count;
    public static int multiply = 1;
    public static bool acti, refresh = false;
    public static PhotonView frank;

    public static bool Q11 = true;
    public static bool Q21 = true;
    public static bool Q22 = true;
    public static int Q12, Q13, Q23, Q31, Q32, Q33 = 0;

    // Use this for initialization
    void Start()
    {
        frank = this.photonView;
    }

    // Update is called once per frame
    void Update()
    {

        if (ConnectAndJoinRandom.character == 4)
        {

            if (turn != PlayerInfo.turn && acti && !PlayerInfo.isSkip)
            {
                turn = PlayerInfo.turn;
                count--;

                PlayerInfo.addatk -= defatk;
                PlayerInfo.basehp -= defhp;
                PlayerInfo.hp = (PlayerInfo.hp * PlayerInfo.basehp) / (PlayerInfo.basehp + defhp);

                if (count <= 0)
                {
                    count = 0;
                    acti = false;
                }
            }

            Skill_2();
            Refresh();
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
            damage = 25;
            chance = 25 + Q12 + Q31;
        }

        else if (PlayerInfo.skilllvl[0] == 2)
        {
            damage = 45;
            chance = 30 + Q12 + Q31;
        }

        else if (PlayerInfo.skilllvl[0] == 3)
        {
            damage = 65;
            chance = 35 + Q12 + Q31;
        }

        PlayerInfo.skillcd[0] = 2;

        if (Random.Range(1, 101) <= chance)
        {
            SingleATK.Single_ATK(pad, damage);
            SingleATK.Stun(pad);
            //Debug.Log("Stun");
        }

        if (Random.Range(1, 101) <= chance)
        {
            SingleATK.Single_ATK(pad, damage);
            SingleATK.Slow(pad);
            //Debug.Log("Slow");
        }

        if (Random.Range(1, 101) <= chance)
        {
            SingleATK.Single_ATK(pad, damage);
            SingleATK.Silence(pad);
            //Debug.Log("Silence");
        }

        frank.RPC("SoundFrankenS1", PhotonTargets.All);

    }

    public static void Skill_2()
    {
        if (PlayerInfo.skilllvl[1] == 1)
        {
            PlayerInfo.def = 20 + Q13 + Q32;
        }

        else if (PlayerInfo.skilllvl[1] == 2)
        {
            PlayerInfo.def = 30 + Q13 + Q32;
        }

        else if (PlayerInfo.skilllvl[1] == 3)
        {
            PlayerInfo.def = 40 + Q13 + Q32;
        }
    }

    public static void Skill_3() //การคำนวณมันเป็น INT มันเลยเลขปัดไปปัดมาไม่ตรงเป็ะ
    {
        if (PlayerInfo.skilllvl[2] > 0)
        {
            if (PlayerInfo.skilllvl[2] == 1)
            {
                multiply = 2 + Q33;
            }

            else if (PlayerInfo.skilllvl[2] == 2)
            {
                multiply = 3 + Q33;
            }

            else if (PlayerInfo.skilllvl[2] == 3)
            {
                multiply = 4 + Q33;
            }

            PlayerInfo.addatk += PlayerInfo.atk * (multiply - 1);
            defatk = PlayerInfo.atk * (multiply - 1) / 10;
            PlayerInfo.basehp = PlayerInfo.basehp * multiply;
            PlayerInfo.hp = (PlayerInfo.hp * PlayerInfo.basehp) / (PlayerInfo.basehp / multiply);
            defhp = PlayerInfo.basehp / multiply * (multiply - 1) / 10;

            PlayerInfo.skillcd[2] = 5 - Q23;
            turn = PlayerInfo.turn;
            count = 10;
            acti = true;

            frank.RPC("SoundFrankenS3", PhotonTargets.All);
        }
    }

    public void SetQualify()
    {
        if (PlayerInfo.qualify[0] == 1)
        {
            if (Q11)
            {
                PlayerInfo.basehp += 40;
                PlayerInfo.hp = (PlayerInfo.hp * PlayerInfo.basehp) / (PlayerInfo.basehp - 40);
                Q11 = false;
            }
        }

        if (PlayerInfo.qualify[0] == 2)
        {
            Q12 = 10;
        }

        if (PlayerInfo.qualify[0] == 3)
        {
            Q13 = 5;
        }

        if (PlayerInfo.qualify[1] == 1)
        {
            if (Q21)
            {
                PlayerInfo.baseatk += 40;
                Q21 = false;
            }
        }

        if (PlayerInfo.qualify[1] == 2)
        {
            if (Q22)
            {
                PlayerInfo.basehp += 65;
                PlayerInfo.hp = (PlayerInfo.hp * PlayerInfo.basehp) / (PlayerInfo.basehp - 65);
                Q22 = false;
            }
        }

        if (PlayerInfo.qualify[1] == 3)
        {
            Q23 = 1;
        }

        if (PlayerInfo.qualify[2] == 1)
        {
            Q31 = 100;
        }

        if (PlayerInfo.qualify[2] == 2)
        {
            Q32 = 25;
        }

        if (PlayerInfo.qualify[2] == 3)
        {
            Q33 = 1;
        }
    }

    public void Refresh() //เมื่อตาย
    {
        if (PlayerInfo.hp <= 0 && !refresh)
        {
            PlayerInfo.basehp = 0;
            refresh = true;
        }

        if (refresh && PlayerInfo.basehp == 0)
        {

            PlayerInfo.basehp = 39 + (30 * (PlayerInfo.level - 1));

            if (!Q11)
            {
                Q11 = true;
            }

            if (!Q22)
            {
                Q22 = true;
            }
        }

        if (PlayerInfo.basehp != 0)
        {
            refresh = false;
        }
    }

    [PunRPC]
    public void SoundFrankenS1()
    {
        Soundbox.player = 4;
        Soundbox.skill = 1;
        Soundbox.isPlay = true;
    }

    [PunRPC]
    public void SoundFrankennS3()
    {
        Soundbox.player = 4;
        Soundbox.skill = 3;
        Soundbox.isPlay = true;
    }
}
