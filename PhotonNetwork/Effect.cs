using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : Photon.MonoBehaviour {

    public static bool isSpawn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (ConnectAndJoinRandom.createRoom)
        {
            if (PlayerInfo.deathstat == 1 && !isSpawn)
            {
                photonView.RPC("Respawn", PhotonTargets.MasterClient, RandomDie.pad);
                isSpawn = true;
            }
        }
    }

    [PunRPC]
    public void Respawn(int pad)
    {
        PhotonNetwork.InstantiateSceneObject("SpawnEffect", Movement.Waypoints[pad].position, Quaternion.Euler(-90, 0, 0), 0, null);
    }
}
