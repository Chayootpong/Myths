using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : Photon.MonoBehaviour {

    bool isDying = false;
    public Renderer me;
    PhotonView vsb;
    //public static int spwappad = 0;

	// Use this for initialization
	void Start () {

        vsb = this.photonView;
        me = GetComponent<Renderer>();
        //spwanpoint = Movement.Waypoints[0].position;
	}
	
	// Update is called once per frame
	void Update () {

        if (photonView.isMine)
        {
            Visible();            
        }

    }
     /*public void Checkpoint()
     {
        /*if (transform.position.x >= 53 && transform.position.x <= 55 
        && transform.position.y >= 9 && transform.position.y <= 11
        && transform.position.z >= -56 && transform.position.z <= -54) //Vector3.Distance(Movement.Waypoint[now], Movement.Waypoint[checkpoint] <= 0.5f)
        {
           spwappad = 0;

        }

        else if (transform.position.x >= 28 && transform.position.x <= 30
        && transform.position.y >= 9 && transform.position.y <= 11
        && transform.position.z >= -7 && transform.position.z <= -5)
        {
           spwanpoint = new Vector3(29.3f,10.25f,-6.74f);
           spwappad = 24;
        }

        else if (transform.position.x >= 21 && transform.position.x <= 23
        && transform.position.y >= 8 && transform.position.y <= 10
        && transform.position.z >= -75 && transform.position.z <= -73)
        {
           spwanpoint = new Vector3(22.59f,9.3f,-74.09f);
           spwappad = 49;
        }
        else if (transform.position.x >= 5 && transform.position.x <= 7
        && transform.position.y >= 9 && transform.position.y <= 11
        && transform.position.z >= -56 && transform.position.z <= -54)
        {
           spwanpoint = new Vector3(6.1f,9.3f,-39.75f);
           spwappad = 74;
       }

    }*/

    public void Visible()
    {
        if (PlayerInfo.hp <= 0)
        {
           if (!isDying)
            {
                // me.enabled = false;
                vsb.RPC("UpdateDie", PhotonTargets.All, PlayerInfo.hp);
                //transform.position = Movement.Waypoints[spwappad].position;
                isDying = true;
                //Debug.Log("isdying");
            }

            
        }

        else if (PlayerInfo.deathstat == 0)
        {
            if (isDying)
            {
                //me.enabled = true;
                vsb.RPC("UpdateDie", PhotonTargets.All, PlayerInfo.hp);
                isDying = false;          
                //Debug.Log("isborn");
            }
            
        }
    }

    [PunRPC]
    public void UpdateDie(int hp)
    {
        if (hp <= 0)
        {
            me.enabled = false;
        }

        else
        {
            me.enabled = true;
        }

    }
}
