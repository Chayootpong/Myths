using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// This script automatically connects to Photon (using the settings file),
/// tries to join a random room and creates one if none was found (which is ok).
/// </summary>
public class ConnectAndJoinRandom : Photon.MonoBehaviour
{
    /// <summary>Connect automatically? If false you can set this to true later on or call ConnectUsingSettings in your own scripts.</summary>
    public bool AutoConnect = true;
    int count;
    public byte Version = 1;
    public static int character = 1;
    public static string charName;

    Vector3 spawnspot;
    public static string playerName = "Aracturement";
    public static bool createRoom = false;
    private PhotonView view;

    /// <summary>if we don't want to connect in Start(), we have to "remember" if we called ConnectUsingSettings()</summary>
    private bool ConnectInUpdate = true;

    public virtual void Start()
    {
        PhotonNetwork.autoJoinLobby = false;    // we join randomly. always. no need to join a lobby to get the list of rooms.
        spawnspot = new Vector3(54, 9, -56); //จุด Spawn รู้ไว้จะได้ทำ Spawn ของ Checkpoint ด้วย
        playerName = "Aracturement#" + UnityEngine.Random.Range(0, 999); //ตั้งชื่อให้ Player ตอนนี้มันจะชื่อ Aracturement#XXX
    }

    public virtual void Update() 
    {
        if (ConnectInUpdate && AutoConnect && !PhotonNetwork.connected)
        {
            Debug.Log("Update() was called by Unity. Scene is loaded. Let's connect to the Photon Master Server. Calling: PhotonNetwork.ConnectUsingSettings();");

            ConnectInUpdate = false;
            PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);
        }

        //Debug.Log(PlayerInfo.Turnnum);
    }


    // below, we implement some callbacks of PUN
    // you can find PUN's callbacks in the class PunBehaviour or in enum PhotonNetworkingMessage


    public virtual void OnConnectedToMaster() //ช่างแม่ง
    {
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby() //เดี๋ยวได้ใช้
    {
        Debug.Log("OnJoinedLobby(). This client is connected and does get a room-list, which gets stored as PhotonNetwork.GetRoomList(). This script now calls: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed() //สร้างห้องอัตโนมัติ
    {
        Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause) //ช่างแม่ง
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom() 
    {
        createRoom = true;
        count = PhotonNetwork.countOfPlayers;

        if (count == 1)
        {
            PlayerInfo.Turnnum = 0;
        }

        else if (count == 2)
        {
            PlayerInfo.Turnnum = 1;
        }

        else if (count == 3)
        {
            PlayerInfo.Turnnum = 2;
        }

        else if (count == 4)
        {
            PlayerInfo.Turnnum = 3;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        if (character == 1)
        {
            charName = "GOBLIN";
            PhotonNetwork.Instantiate("Goblin", spawnspot, Quaternion.Euler(-30, -45, 0), 0);
        }

        else if (character == 2)
        {
            charName = "MERMAID";
            PhotonNetwork.Instantiate("Mermaid", spawnspot, Quaternion.Euler(-30, -45, 0), 0);
        }

        else if (character == 3)
        {
            charName = "GRIFFON";
            PhotonNetwork.Instantiate("Griffon", spawnspot, Quaternion.Euler(-30, -45, 0), 0);
        }

        else if (character == 4)
        {
            charName = "FRANKENSTEIN";
            PhotonNetwork.Instantiate("Franken", spawnspot, Quaternion.Euler(-30, -45, 0), 0);
        }
        
        PhotonNetwork.playerName = playerName; //จุดตั้งชื่อ Player ลง PlayerList  
        //PhotonNetwork.Instantiate("Franken", spawnspot, Quaternion.Euler(-30, -45, 0), 0); //Code Spawn

        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
    }
}
