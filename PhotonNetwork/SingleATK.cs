using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleATK : Photon.MonoBehaviour {

    public static PhotonView result;

    // Use this for initialization
    void Start() {

        result = this.photonView;

    }

    // Update is called once per frame
    void Update() {
        

    }

    public static void Single_ATK(int pad, int dmg)
    {
        result.RPC("ReduceHealth", PhotonTargets.All, pad, dmg);
    }

    public static void Slow(int pad)
    {
        result.RPC("SetStatus", PhotonTargets.All, pad, 1);
    }

    public static void Stun(int pad)
    {
        result.RPC("SetStatus", PhotonTargets.All, pad, 2);
    }

    public static void Silence(int pad)
    {
        result.RPC("SetStatus", PhotonTargets.All, pad, 3);
    }

    [PunRPC]
    public void ReduceHealth(int pad, int dmg)
    {

        if (Movement.realpad > 16 && !PlayerInfo.immune)
        {
            if (PlayerInfo.turn % 4 != PlayerInfo.Turnnum)
            {
                if (Movement.realpad == pad)
                {
                    if (PlayerInfo.shield > 0)
                    {
                        PlayerInfo.shield = PlayerInfo.shield - dmg;
                    }
                    else
                    {

                        if (dmg - PlayerInfo.def < 0)
                        {
                            dmg = 0;
                        }

                        else
                        {
                            dmg -= PlayerInfo.def;
                        }


                        PlayerInfo.hp = PlayerInfo.hp - dmg;
                    }

                }
            }
        }
    }

    [PunRPC]
    public void SetStatus(int pad, int status)
    {
        if (Movement.realpad > 16 && !PlayerInfo.immune)
        {
            if (status == 1)
            {
                if (PlayerInfo.turn % 4 != PlayerInfo.Turnnum)
                {
                    if (Movement.realpad == pad)
                    {
                        PlayerInfo.slow = true;
                    }
                }
            }

            if (status == 2)
            {
                if (PlayerInfo.turn % 4 != PlayerInfo.Turnnum)
                {
                    if (Movement.realpad == pad)
                    {
                        PlayerInfo.stun = true;
                    }
                }
            }

            if (status == 3)
            {
                if (PlayerInfo.turn % 4 != PlayerInfo.Turnnum)
                {
                    if (Movement.realpad == pad)
                    {
                        PlayerInfo.silence = true;
                    }
                }
            }
       }
    }
}
