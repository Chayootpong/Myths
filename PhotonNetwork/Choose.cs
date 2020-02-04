using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose : Photon.MonoBehaviour {

    public static GameObject Light_1;
    public static GameObject Light_2;
    public static GameObject Light_3;

    public static bool isAim = false;
    public static int selectpad;
    public static GameObject[] pads = new GameObject[100];
    public static PhotonView aim;

    // Use this for initialization
    void Start () {

        Light_1 = GameObject.Find("MAIN LIGHT"); //Light_1 = Light1;
        Light_2 = GameObject.Find("MAIN SHADOW"); //Light_2 = Light2;
        Light_3 = GameObject.Find("SECOND LIGHT"); //Light_3 = Light3;
        aim = this.photonView;
        /*block_aim = GameObject.Find("block_aim");
        block_aim.SetActive(false);*/
        //pads = newPads;
        for (int i = 0; i < 100; i++)
        {
            string numpad = string.Format("Pads ({0})", i + 1);
            pads[i] = GameObject.Find(numpad);
            pads[i].GetComponent<MeshCollider>().enabled = false;
            //pads[i].SetActive(false);

            //Debug.Log("Array : " + i + " Numpad : " + numpad);
        }

    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(myself);

    }

    public static void Selecting(int character, int skilltype, int range)
    {
        Light_1.SetActive(false);
        Light_2.SetActive(false);
        Light_3.SetActive(true);
        //block_aim.SetActive(true);
        isAim = true;

        for (int x = 16; x < 99; x++)
        {

            float distance = Vector3.Distance(Movement.Waypoints[RandomDie.pad].position, Movement.Waypoints[x].position);

            if (x != 24 && x != 49 && x != 74)
            {
                if (distance <= range)
                {
                    aim.RPC("DisablePad", PhotonTargets.All, x);
                }

                else
                {
                    pads[x].SetActive(false);
                }
            }

            else
            {
                //pads[x].SetActive(false);
            }
        }

        PressPad.InputVar(character, skilltype);
    }

    [PunRPC]
    public void DisablePad(int x)
    {
        if (PlayerInfo.aimproof && RandomDie.pad == x)
        {
            aim.RPC("SetActive", PhotonTargets.All, x);
        }

        else
        {
            pads[x].SetActive(true);
            pads[x].GetComponent<MeshCollider>().enabled = true;
            pads[x].GetComponent<PressPad>().vars = x + 1;
        }
    }

    [PunRPC]
    public void SetActive(int x)
    {
        pads[x].SetActive(false);
    }
}
