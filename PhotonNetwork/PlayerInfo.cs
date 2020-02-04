using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : Photon.MonoBehaviour {

    public static int turn = 0;
    public static bool beforeturn = false;
    public static int Turnnum;
    public static int type = 0;
    public static int basehp = 0;
    public static int normalhp = 0;
    public static int hp = 0;
    public static int baseatk = 0;
    public static int addatk = 0;
    public static int atk = 0;
    public static int shield = 0;
    public static int def = 0;
    public static int range;
    public static string c_name;
    public static int level = 1;
    public static int deathstat = 0;
    public static bool attack = true;
    public static bool isDying = false;
    public static bool isSkip = false;
    public static bool isMaxLVL = false;
    public PhotonView skipturn;

    bool checkUpdate = true;

    public static int[] skilllvl = new int[3];
    public static int[] skillcd = new int[3];
    public static int[] qualify = new int[3];

    public GameObject Up_1;
    public GameObject Up_2;
    public GameObject Up_3;
    public GameObject slow_p;
    public GameObject stun_p;
    public GameObject silence_p;
    public GameObject aimproof_p;
    public GameObject immune_p;
    public GameObject Qua_1;
    public GameObject Qua_2;
    public GameObject Qua_3;
    public GameObject[] SL;
    public GameObject[] SLS;
    public GameObject[] SKO;
    public GameObject blockQua;
    public GameObject blockAim;
    public GameObject block;
    public GameObject cancel;
    public GameObject[] Eff;

    public static bool onceUp = false;
    public static bool slow = false;
    public static bool stun = false;
    public static bool aimproof = false;
    public static bool immune = false;
    public static bool silence = false;
    public static bool rush = false;

    void Awake()
    {

    }

    // Use this for initialization
    void Start() {

        if (turn % 4 == Turnnum)
        {
            onceUp = true;
        }

        skilllvl[0] = 0;
        skilllvl[1] = 0;
        skilllvl[2] = 0;

    }

    // Update is called once per frame
    void Update() {

        InputInfo();
        SetStat();
        Silence();
        Upskill();
        UpQualify();

        if (ConnectAndJoinRandom.createRoom)
        {
            SkillOrb();
        }

        Details();
        Stun();

    }

    public void InputInfo()
    {
        if (checkUpdate)
        {
            if (ConnectAndJoinRandom.character == 1)
            {
                c_name = "GOBLIN";
                type = Goblins.stat[0];
                baseatk = Goblins.stat[1];
                normalhp = Goblins.stat[2];
                basehp = Goblins.stat[2];
                range = Goblins.stat[3];
                atk = baseatk;
                hp = basehp;
                //Debug.Log("Set Stat!!! " + hp);
            }

            else if (ConnectAndJoinRandom.character == 2)
            {
                c_name = "MERMAID";
                type = Mermaids.stat[0];
                baseatk = Mermaids.stat[1];
                normalhp = Mermaids.stat[2];
                basehp = Mermaids.stat[2];
                range = Mermaids.stat[3];
                atk = baseatk;
                hp = basehp;
                //Debug.Log("Set Stat!!! " + hp);
            }

            else if (ConnectAndJoinRandom.character == 3)
            {
                c_name = "Griffon";
                type = Griffon.stat[0];
                baseatk = Griffon.stat[1];
                normalhp = Griffon.stat[2];
                basehp = Griffon.stat[2];
                range = Griffon.stat[3];
                atk = baseatk;
                hp = basehp;
                //Debug.Log("Set Stat!!! " + hp);
            }

            else if (ConnectAndJoinRandom.character == 4)
            {
                c_name = "Frankenstein";
                type = Frankenstein.stat[0];
                baseatk = Frankenstein.stat[1];
                normalhp = Frankenstein.stat[2];
                basehp = Frankenstein.stat[2];
                range = Frankenstein.stat[3];
                atk = baseatk;
                hp = basehp;
                //Debug.Log("Set Stat!!! " + hp);
            }

            if (type != 0)
            {
                checkUpdate = false;
            }
        }
    }

    public void SetStat()
    {
        if (shield < 0)
        {
            shield = 0;
        }

        if (hp < 0)
        {
            hp = 0;
        }
    }

    public void Upskill()
    {
        if ((turn % 4 == Turnnum && onceUp) && (level != 3 && level != 7 && level != 12))
        {

            if (skilllvl[0] < 3)
            {
                Up_1.SetActive(true);
            }

            if (skilllvl[1] < 3)
            {
                Up_2.SetActive(true);
            }

            if (skilllvl[2] < 1 && level >= 5)
            {
                Up_3.SetActive(true);
            }

            else if (skilllvl[2] < 2 && level >= 8)
            {
                Up_3.SetActive(true);
            }

            else if (skilllvl[2] < 3 && level >= 11)
            {
                Up_3.SetActive(true);
            }
        }

        else
        {
            Up_1.SetActive(false);
            Up_2.SetActive(false);
            Up_3.SetActive(false);
        }
    }

    public void UpQualify()
    {
        if ((turn % 4 == Turnnum && onceUp) && (level == 3 || level == 7 || level == 12) && !isMaxLVL)
        {
            Qua_1.SetActive(true);
            Qua_2.SetActive(true);
            Qua_3.SetActive(true);
            Eff[0].SetActive(true);
            Eff[1].SetActive(true);
            Eff[2].SetActive(true);
            blockQua.SetActive(true);
        }
    }

    public void Silence()
    {
        if (silence && !stun && !onceUp)
        {
            for (int i = 0; i < 3; i++)
            {
                SLS[i].SetActive(true);
            }
        }

        else
        {
            for (int i = 0; i < 3; i++)
            {
                SLS[i].SetActive(false);
            }
        }
    }
    public void Stun()
    {
        if (stun)
        {
            if (!onceUp || isMaxLVL)
            {
                for (int i = 0; i < 3; i++)
                {
                    SL[i].SetActive(true);
                }

                attack = false;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                SL[i].SetActive(false);
            }
        }
    }

    public void SkillOrb()
    {

        int k = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (skilllvl[i] == j)
                {
                    SKO[k].SetActive(true);
                }

                k++;

            }

        }

        k = 0;

    }

    public void Details()
    {
        atk = baseatk + addatk;

        if (Choose.isAim)
        {
            cancel.SetActive(true);
        }

        else
        {
            cancel.SetActive(false);
        }

        if (Movement.isMove)
        {
            block.SetActive(true);
            //Debug.Log("BlockOn");
        }

        else
        {
            block.SetActive(false);
            //Debug.Log("BlockOff");
        }

        if (Choose.isAim)
        {
            blockAim.SetActive(true);
            //Debug.Log("BlockOn");
        }

        else
        {
            blockAim.SetActive(false);
            //Debug.Log("BlockOff");
        }

        if (slow)
        {
            slow_p.SetActive(true);
        }

        else
        {
            slow_p.SetActive(false);
        }

        if (stun)
        {
            stun_p.SetActive(true);
        }

        else
        {
            stun_p.SetActive(false);
        }

        if (silence)
        {
            silence_p.SetActive(true);
        }

        else
        {
            silence_p.SetActive(false);
        }

        if (aimproof)
        {
            aimproof_p.SetActive(true);
        }

        else
        {
            aimproof_p.SetActive(false);
        }

        if (immune)
        {
            immune_p.SetActive(true);
        }

        else
        {
            immune_p.SetActive(false);
        }
    }

    public void Dying()
    {

        if (deathstat == 0)
        {
            deathstat = 2;
            hp = 0;
            //isDying = false;
            //Debug.Log("Dstack" + deathstat);
        }

        if (deathstat == 1 && (turn % 4) == Turnnum)
        {

            hp = basehp;
            atk = baseatk;
            shield = 0;
            slow = false;
            stun = false;
            silence = false;
            aimproof = false;
            immune = false;
            deathstat = 0;
            //isDying = false;
        }

        if (deathstat > 1 && (turn % 4) == Turnnum)
        {
            //Debug.Log("YAY");           
            skipturn.RPC("SkippingTime", PhotonTargets.All, true);
            skipturn.RPC("UpdateTurn", PhotonTargets.All, 1);
            skipturn.RPC("UpdateStat", PhotonTargets.All, 1);
            deathstat--;
            //isDying = true;

        }

    }

    public void ReduceCD()
    {
        if (turn % 4 == Turnnum)
        {
            for (int i = 0; i < 3; i++)
            {
                if (skillcd[i] <= 0)
                {
                    skillcd[i] = 0;
                }
                else
                {
                    skillcd[i]--;
                }
            }
        }

    }

    [PunRPC]
    public void UpdateTurn(int plusturn)
    {
        beforeturn = true;

        if (turn % 4 == Turnnum)
        {
            silence = false;
            slow = false;
            stun = false;
        }

        turn = turn + plusturn;
        beforeturn = false;

        if (turn % 4 == Turnnum)
        {

            attack = true;

        }

        onceUp = true;
        //skipturn.RPC("UpdateStat", PhotonTargets.All, 1);
        //Debug.Log(turn);
        ReduceCD();

        if (hp <= 0 && turn > 0)
        {
            Dying();
        }
    }

    [PunRPC]
    public void UpdateStat(int pluslvl)
    {
        if (turn > 3)
        {
            if (turn % 4 == Turnnum && level < 12)
            {

                if (type == 1)
                {
                    baseatk += 10;
                    basehp += 20;
                    hp = (hp * basehp) / (basehp - 20);
                }

                else if (type == 2)
                {
                    baseatk += 5;
                    basehp += 30;
                    hp = (hp * basehp) / (basehp - 30);
                }

                else if (type == 3)
                {
                    baseatk += 7;
                    basehp += 25;
                    hp = (hp * basehp) / (basehp - 25);
                }

                level = level + pluslvl;
            }
        }
    }

    [PunRPC]
    public void SkippingTime(bool skip)
    {
        isSkip = skip;
    }
    
}
