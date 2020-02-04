using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomDie : Photon.MonoBehaviour {

    int rand;
    public static int plusturn = 1;
    public static int pluslvl = 1;
    public static int pad = 0;

    float Rspeed = 20;
    int k = 0;

    public GameObject block;
    public GameObject blockup;
    public GameObject TheRoullete;
    public PhotonView turns;

    public Button btn;
    public Sprite _roll, _end, _opp;

    public Sprite[] winplay;
    public Sprite[] loseplay;
    public Image result;
    public GameObject winlose;
    public GameObject[] reseff;
    public int[] RoullPad = new int[] {12,14,16,18,20};

    bool keyres = false;
    bool phase = true;
    bool spining = false;
    PhotonView Roul;

    public int j = 0, endswappoint = -1;

    void Start()
    {
        TheRoullete.SetActive(false);
        Roul = this.photonView;

    }

    void Update()
    {
        Debug.Log(TheRoullete.transform.eulerAngles.z);
        if (pad == 99 && Movement.velocity == 0 && !keyres)
        {
            StartCoroutine("DelayTime");
        }

        if (keyres && Movement.velocity == 0)
        {
            photonView.RPC("EndGame", PhotonTargets.All);
        }

        FindMe();
        BlockUp();
        Yourturn();
        Stuning();
        if(ConnectAndJoinRandom.createRoom == true)
        { 
            RRoulette();
        }
    }

    public void FindMe()
    {

        if ((PlayerInfo.turn % 4) == PlayerInfo.Turnnum && PlayerInfo.deathstat == 0)
        {
            block.SetActive(false);
            //Debug.Log("block_off");
        }

        else
        {
            
            block.SetActive(true);
            //Debug.Log("block_on");
        }

    }

    public void BlockUp()
    {

        if (PlayerInfo.onceUp == true && phase == false && PlayerInfo.level < 12)
        {
            blockup.SetActive(true);
            //Debug.Log("blockup_on");
        }

        else
        {
            blockup.SetActive(false);
            //Debug.Log("blockup_off");
        }
    }
    public void Stuning()
    {
        if (phase && PlayerInfo.stun)
        {
            phase = false;
            PlayerInfo.rush = false;
        }
    }

    public void Yourturn()
    {
        if (PlayerInfo.turn % 4 == PlayerInfo.Turnnum && phase && !PlayerInfo.stun)
        {
            btn.image.sprite = _roll;
        }
        if (PlayerInfo.turn % 4 == PlayerInfo.Turnnum && PlayerInfo.stun)
        {
            btn.image.sprite = _end;
        }

        else if (PlayerInfo.turn % 4 != PlayerInfo.Turnnum && phase)
        {
            btn.image.sprite = _opp;
        }
    }
    public void Rando()
    {
        if (phase)
        {
            btn.image.sprite = _end;

            if (PlayerInfo.level == 1)
            {
                if (PlayerInfo.Turnnum == 0)
                {
                    rand = Random.Range(7, 7);
                }

                else if (PlayerInfo.Turnnum == 1)
                {
                    rand = Random.Range(5, 16);
                }

                else if (PlayerInfo.Turnnum == 2)
                {
                    rand = Random.Range(8, 16);
                }

                else if (PlayerInfo.Turnnum == 3)
                {
                    rand = Random.Range(11, 16);
                }
            }

            else
            {
                rand = Random.Range(2, 13);
            }

            if (PlayerInfo.slow)
            {
                rand = rand / 2;
            }
            

            PlayerInfo.rush = false;
            pad = pad + rand; //ช่อง - 1
            phase = false;
        

        }

        else
        {
            btn.image.sprite = _roll;
            turns.RPC("SkippingTime", PhotonTargets.All, false);
            turns.RPC("UpdateTurn", PhotonTargets.All, plusturn);           
            turns.RPC("UpdateStat", PhotonTargets.All, pluslvl);
            phase = true;
            spining = false;
            Rspeed = 20;
            /*PlayerInfo.slow = false;//*
            PlayerInfo.stun = false;//*
            PlayerInfo.silence = false;//**/
        }

    }
    public void RRoulette()
    {
        Debug.Log("onRoul");
        StartCoroutine("DelayWalk");
        /*if (!spining && PlayerInfo.turn % 4 == PlayerInfo.Turnnum && Movement.velocity == 0)
        {
            Rspeed = 20;
            TheRoullete.SetActive(true);
            spining = true;
            // k = Random.Range(1, 8) * 25;
            k = 285 + (6 * 50);
            if (k > 360)
            {
                k = k % 360;
            }
            Debug.Log("k" + k);
        }*/

        if (spining)
        {
            //TheRoullete.transform.Rotate(0, 0, Rspeed);
            TheRoullete.transform.eulerAngles = new Vector3(0, 0, TheRoullete.transform.eulerAngles.z + Rspeed);

            if (Rspeed > 3)
            {
                Rspeed -= 0.2f;
            }
            else if (Rspeed <= 3 && Rspeed > 0)
            {
                if (Rspeed > 0.4f)
                {
                    /*if ((TheRoullete.transform.eulerAngles.z - k) < 100 && k < TheRoullete.transform.eulerAngles.z)
                    {

                        Rspeed -= 0.1f;
                    }*/
                    if ((TheRoullete.transform.eulerAngles.z - k) > -50 && k > TheRoullete.transform.eulerAngles.z)
                    {

                        Rspeed -= 0.2f;

                    }
                }

                if ((TheRoullete.transform.eulerAngles.z - k) < Random.Range(1, 10) && k < TheRoullete.transform.eulerAngles.z)
                {

                    Rspeed = 0;
                }
                else if ((TheRoullete.transform.eulerAngles.z - k) > -Random.Range(1, 10) && k > TheRoullete.transform.eulerAngles.z)
                {

                    Rspeed = 0;

                }
                else if (Rspeed < 0.3f)
                {
                    Rspeed = 0.4f;
                }

            }
            else if (Rspeed <= 0)
            {
                Rspeed = 0;
                StartCoroutine("DelayWalk");
                if (k != 0)
                {

                    
                    Roul.RPC("RoulEf", PhotonTargets.All, k);
                    k = 0;
                }
                
            }
               
            
            

        }
        Debug.Log("speeed" + Rspeed);
        Debug.Log("k--------------------------------++S" + (TheRoullete.transform.eulerAngles.z - k));
    }
    IEnumerator DelayWalk()
    {
        bool check = false;
        yield return new WaitForSeconds(1);
        while (Movement.velocity != 0 && PlayerInfo.turn % 4 == PlayerInfo.Turnnum && Rspeed == 20  &&
                (pad == 7|| pad == 8 || pad == 9 || pad == 10 || pad == 11|| pad == 6|| pad == 5))
        {
            yield return new WaitForSeconds(1);
            Debug.Log("onRoul2");
            check = true;
        }
        if ( !spining  && Movement.velocity == 0 && check) 
        {
            Rspeed = 30;
            TheRoullete.SetActive(true);
            spining = true;
           
            k = 285 + (Random.Range(0, 6) * 50);
            if (k > 360)
            {
                k = k % 360;
            }
            Debug.Log("k" + k);
        }
        if (Rspeed == 0)
        {
            yield return new WaitForSeconds(1.5f);
            TheRoullete.SetActive(false);
        }
        
        
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(3);

        if (Movement.velocity == 0)
        {
            keyres = true;
        }

        else
        {
            keyres = false;
        }
    }

    [PunRPC]
    public void EndGame()
    {
        winlose.SetActive(true);

        if (PlayerInfo.turn % 4 == PlayerInfo.Turnnum)
        {
            result.sprite = winplay[ConnectAndJoinRandom.character - 1];
            reseff[0].SetActive(true);
        }

        else
        {
            result.sprite = loseplay[ConnectAndJoinRandom.character - 1];
            reseff[1].SetActive(true);
        }
    }

    [PunRPC]
    public void RoulEf(int kk)
    {
        if (PlayerInfo.turn % 4 == PlayerInfo.Turnnum)
        {
            if (kk == 285) //shelid-เทา
            {
                PlayerInfo.shield += 100;
            }

            else if (kk == 335)//heal-เขียว
            {
                PlayerInfo.hp = PlayerInfo.basehp;
            }

            else if (kk == 25) //d buff-ม่วง
            {
                PlayerInfo.aimproof = false;
                PlayerInfo.immune = false;

            }

            else if (kk == 75) //Cd-น้ำตาล
            {
                PlayerInfo.skillcd[0] = 0;
                PlayerInfo.skillcd[1] = 0;
                PlayerInfo.skillcd[2] = 0;
            }

            else if (kk == 125) //d debuff-เหลือง
            {
                PlayerInfo.silence = false;
                PlayerInfo.slow = false;
                PlayerInfo.stun = false;
            }

            else if (kk == 175) //d hp 5-กำ
            {
                PlayerInfo.hp = PlayerInfo.hp / 2;
            }

            else if (kk == 225) //tele-ฟ้า
            {
                j = PlayerInfo.Turnnum;
                while(j == PlayerInfo.Turnnum)
                {
                    j = Random.Range(0, 4);
                    //Debug.Log("SUS");
                }

                Debug.Log(pad);
                Debug.Log(j);

                Roul.RPC("Swapping", PhotonTargets.All, pad, j);
            }
        }
    }

    [PunRPC]
    public void Swapping(int startswappoint, int endswap)
    {
        endswappoint = -1;
        //Debug.Log("SUS");

        if(PlayerInfo.Turnnum == endswap)
        {
            endswappoint = pad;
            Movement.isSwap = startswappoint;
            Roul.RPC("Conswapping", PhotonTargets.All, endswappoint);
        }

        /*if(PlayerInfo.turn % 4 == PlayerInfo.Turnnum)
        {
            Movement.isSwap = endswappoint;
        }*/
    }

    [PunRPC]
    public void Conswapping(int endswap)
    {
        if(PlayerInfo.turn % 4 == PlayerInfo.Turnnum)
        {
            Movement.isSwap = endswap;
        }
    }

}
