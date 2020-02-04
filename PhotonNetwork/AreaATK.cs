using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaATK : Photon.MonoBehaviour {

    public static PhotonView area;
    public static int targetPad;
    public static int new_char, new_st;
    public static bool onceTrig_1 = true;
    public static bool onceTrig_2 = true;

    // Use this for initialization
    void Start () {

        area = this.photonView;

	}
	
	// Update is called once per frame
	void Update () {

        if (!onceTrig_1)
        {
            onceTrig_2 = true;
        }
		
	}

    public static void Area_ATK_Myself(int character, int skilltype, int pad, int range)
    {
        new_char = character;
        new_st = skilltype;
        //Debug.Log(new_char);
        //Debug.Log(new_st);
        area.RPC("FindTarget", PhotonTargets.All, pad, range);        
    }

    [PunRPC]
    public void FindTarget(int pad, int range)
    {
        if (PlayerInfo.turn % 4 != PlayerInfo.Turnnum && onceTrig_1)
        {
            if (Vector3.Distance(Movement.Waypoints[pad].position, Movement.Waypoints[RandomDie.pad].position) < range)
            {
                targetPad = RandomDie.pad + 1;               
            }

            else
            {
                targetPad = 0;
            }
            
        }

        area.RPC("RespondTarget", PhotonTargets.All, targetPad);
        onceTrig_1 = false;
    }

    [PunRPC]
    public void RespondTarget(int pad)
    {
       
        if (PlayerInfo.turn % 4 == PlayerInfo.Turnnum && onceTrig_2)
        {
            if (new_char == 2)
            {
                if (new_st == 1)
                {
                    Mermaids.ACT_Skill_1(pad);
                }

                else if (new_st == 2)
                {
                    Mermaids.ACT_Skill_2(pad);
                }
            }

            if (new_char == 3)
            {
                if (new_st == 1)
                {
                    Griffon.ACT_Skill_1(pad);
                }
            }

            onceTrig_1 = true;
            onceTrig_2 = false;
        }
    }
}
