using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Griffon : Photon.MonoBehaviour
{
    public static int[] stat = { 3, 6, 30, 10}; //Type, ATK, HP, Range
    public static int damage_1, damage_3, pushPad, count, turn_2, turn_3, myself;
    public static int currentCD_1 = 3, currentCD_2, currentCD_3;
    public static PhotonView ulti;
    public static bool acti = false;

    public bool Q11 = true;
    public static int Q12 = 0;
    public static int Q13 = 0;
    public static int Q21 = 0;
    public bool Q23 = false;
    public static int Q31 = 0;
    public static bool Q32 = false;
    public static int Q33 = 0;

    // Use this for initialization
    void Start()
    {
        ulti = this.photonView;
    }

    // Update is called once per frame
    void Update()
    {

        if (ConnectAndJoinRandom.character == 3)
        {
            
            if (turn_2 + 4 == PlayerInfo.turn)
            {
                turn_2 = 0;
                PlayerInfo.aimproof = false;
            }

            if (turn_3 != PlayerInfo.turn && acti)
            {
                if (Q23)
                {
                    if (PlayerInfo.skilllvl[2] == 1)
                    {
                        damage_3 = 20;
                    }

                    else if (PlayerInfo.skilllvl[2] == 2)
                    {
                        damage_3 = 35;
                    }

                    else if (PlayerInfo.skilllvl[2] == 3)
                    {
                        damage_3 = 50;
                    }
                }

                turn_3 = PlayerInfo.turn;
                count--;
                ulti.RPC("Ultimate", PhotonTargets.All, damage_3, pushPad);

                if (count <= 0)
                {
                    count = 0;
                    PlayerInfo.immune = false;
                    acti = false;
                }
            }

            SetQualify();
        }   
    }

    public static void Skill_1()
    {
        if (PlayerInfo.skilllvl[0] > 0)
        {
            RandomDie.pad += 4 + Q31;
            AreaATK.Area_ATK_Myself(ConnectAndJoinRandom.character, 1, RandomDie.pad, 10 + Q21);
            PlayerInfo.skillcd[0] = 3;
            PlayerInfo.rush = true;
        }
    }

    public static void ACT_Skill_1(int pad)
    {
        if (PlayerInfo.skilllvl[0] == 1)
        {
            damage_1 = 30 + Q12;
        }

        else if (PlayerInfo.skilllvl[0] == 2)
        {
            damage_1 = 50 + Q12;
        }

        else if (PlayerInfo.skilllvl[0] == 3)
        {
            damage_1 = 70 + Q12;
        }

        SingleATK.Single_ATK(pad, damage_1);
        ulti.RPC("SoundGriffonS1", PhotonTargets.All);

    }

    public static void Skill_2()
    {
        if (PlayerInfo.skilllvl[1] > 0)
        {

            if (PlayerInfo.skilllvl[1] == 1)
            {
                PlayerInfo.skillcd[1] = 5 - Q13;
                currentCD_2 = 5 - Q13;
            }

            else if (PlayerInfo.skilllvl[1] == 2)
            {
                PlayerInfo.skillcd[1] = 4 - Q13;
                currentCD_2 = 4 - Q13;
            }

            else if (PlayerInfo.skilllvl[1] == 3)
            {
                PlayerInfo.skillcd[1] = 3 - Q13;
                currentCD_2 = 3 - Q13;
            }

            if (Q32)
            {
                PlayerInfo.immune = true;
            }

            PlayerInfo.aimproof = true;
            turn_2 = PlayerInfo.turn;
            ulti.RPC("SoundGriffonS2", PhotonTargets.All);

        }
    }

    public static void Skill_3() //ปัญหานิดหน่อย ถ้าเล่น Griffon หลายคน ถ้าเปิด Ulti พร้อมกัน คนที่กดจะไม่รับผล Ulti คนอื่น
    {
        if (PlayerInfo.skilllvl[2] > 0)
        {
            if (PlayerInfo.skilllvl[2] == 1)
            {
                pushPad = 1 + Q33;
                PlayerInfo.skillcd[2] = 6;
                currentCD_3 = 6;
            }

            else if (PlayerInfo.skilllvl[2] == 2)
            {
                pushPad = 2 + Q33;
                PlayerInfo.skillcd[2] = 5;
                currentCD_3 = 5;
            }

            else if (PlayerInfo.skilllvl[2] == 3)
            {
                pushPad = 3 + Q33;
                PlayerInfo.skillcd[2] = 4;
                currentCD_3 = 4;
            }
           
            count = 4;
            turn_3 = PlayerInfo.turn;
            myself = PlayerInfo.Turnnum;
            PlayerInfo.immune = true;
            acti = true;

        }
    }

    public void SetQualify()
    {
        if (PlayerInfo.qualify[0] == 1)
        {
            if (Q11)
            {
                PlayerInfo.basehp += 30;
                PlayerInfo.hp = (PlayerInfo.hp * PlayerInfo.basehp) / (PlayerInfo.basehp - 30);
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
            Q21 = 5;
        }

        if (PlayerInfo.skillcd[0] == currentCD_1 && PlayerInfo.skillcd[1] == currentCD_2 ||
            PlayerInfo.skillcd[0] == currentCD_1 && PlayerInfo.skillcd[2] == currentCD_3 ||
            PlayerInfo.skillcd[1] == currentCD_2 && PlayerInfo.skillcd[2] == currentCD_3)
        {
            if (PlayerInfo.qualify[1] == 2)
            {
                PlayerInfo.skillcd[0]--;
                PlayerInfo.skillcd[1]--;
                PlayerInfo.skillcd[2]--;
            }            
        }

        if (PlayerInfo.qualify[1] == 3)
        {
            Q23 = true;
        }

        if (PlayerInfo.qualify[2] == 1)
        {
            Q31 = 6;
        }

        if (PlayerInfo.qualify[2] == 2)
        {
            Q32 = true;
        }

        if (PlayerInfo.qualify[2] == 3)
        {
            Q33 = 2;
        }
    }

    [PunRPC]
    public void Ultimate(int dmg, int pad)
    {
        if (Movement.realpad > 16 && !PlayerInfo.immune && PlayerInfo.hp > 0)
        {
            Movement.isPush = true;
            Movement.pushnum = pad;

            if (PlayerInfo.shield > 0)
            {
                PlayerInfo.shield -= dmg;
            }
            else
            {
                PlayerInfo.hp -= dmg;
            }      

        }
    }

    [PunRPC]
    public void SoundGriffonS1()
    {
        Soundbox.player = 3;
        Soundbox.skill = 1;
        Soundbox.isPlay = true;
    }

    [PunRPC]
    public void SoundGriffonS2()
    {
        Soundbox.player = 3;
        Soundbox.skill = 2;
        Soundbox.isPlay = true;
    }

}
