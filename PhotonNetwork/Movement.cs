using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Movement : Photon.MonoBehaviour {

    //PhotonView PhotonView;
    //PhotonView game;
    public NavMeshAgent agent;
    public Animator anim;
    public static bool isMove, isWarp = false;
    public static Transform[] Waypoints = new Transform[100];
    //public static GameObject[] Padnumb;
    public static int realpad = 0;
    public static int maxpad = 0;
    public static float velocity;
    public static bool isPush = false;
    public static int isSwap = -1;
    public static int pushnum = 0;
    public static int countwin = 0;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        //game = this.photonView;
        //PhotonView = GetComponent<PhotonView>();
    }

    // Use this for initialization
    void Start () {   

        for (int i = 0; i < 100; i++)
        {
            string numpad = string.Format("Pad ({0})" , i + 1);
            Waypoints[i] = GameObject.Find(numpad).transform;

            //Debug.Log("Array : " + i + " Numpad : " + numpad);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (photonView.isMine) //เช็คว่าเป็นตัวเองไหม ไม่ต้องสนใจก็ได้
        {
            CheckInput();

            if (isPush && pushnum != 0)
            {
                Pushing();
            }
        }    

        if (PlayerInfo.rush)
        {
            agent.speed = 5;
        }

        else
        {
            agent.speed = 1.5f;
        }

    }

    void CheckInput()
    {

        if (maxpad < realpad)
        {
            maxpad = realpad;
        }

        if (PlayerInfo.hp <= 0 && !isWarp) //Spawn
        {
            if (maxpad >= 75)
            {
                agent.Warp(Waypoints[74].position);
                RandomDie.pad = 74;
            }

            else if (maxpad >= 50)
            {
                agent.Warp(Waypoints[49].position);
                RandomDie.pad = 49;
            }

            else if (maxpad >= 25)
            {
                agent.Warp(Waypoints[24].position);
                RandomDie.pad = 24;
            }

            else
            {
                agent.Warp(Waypoints[0].position);
                RandomDie.pad = 0;
            }

            isWarp = true;
            
        }

        if (PlayerInfo.hp > 0 && isWarp)
        {
            //agent.enabled = true;
            isWarp = false;
        }

        if(isSwap != -1)
        {
            agent.Warp(Waypoints[isSwap].position);
            RandomDie.pad = isSwap;
            isSwap = -1;
        }

        velocity = agent.velocity.magnitude;
        float h = agent.velocity.x;
        float v = agent.velocity.z;
        //int myAngle = (int)(Mathf.Atan2(v, h) * Mathf.Rad2Deg) + 180;

        // เริ่มการคำนวณช่องสำหรับ NavMeshAgent
        for (int j = 0; j < 2; j++)
        {

            if (RandomDie.pad > 99 && countwin >= 3)
            {
                agent.SetDestination(Waypoints[99].position);
                RandomDie.pad = 99;
            }

            else if (RandomDie.pad > 99)
            {
                agent.SetDestination(Waypoints[99 - (RandomDie.pad - 99)].position);
                RandomDie.pad = 99 - (RandomDie.pad - 99);
                countwin++;
            }

            else
            {
                agent.SetDestination(Waypoints[RandomDie.pad].position);
            }

            realpad = RandomDie.pad + 1; //ช่อง Pad ที่แท้จริง
            //names.RPC("UpdateName", PhotonTargets.All, photonView.owner.NickName, realpad);

            //อันนี้แหละตัวสำคัญ เป็นการส่งค่าไปยัง UpdateName อยู่ใน PlayerName
            //ช่องที่สองคือเป้าหมายที่จะส่งไปให้ ปกติก็เลือก .All แหละ
            //ช่องที่เหลือคือตัวแปรที่จะส่งไปให้ PlayerName
        }

        /*if (myAngle >= 146 && myAngle <= 235 && myAngle != 180)
        {
            anim.SetInteger("Speed", 1);
            isMove = true;
        }

        else if (myAngle >= 236 && myAngle <= 325)
        {
            anim.SetInteger("Speed", 3);
            isMove = true;
        }

        else if ((myAngle >= 326 && myAngle <= 360) || (myAngle >= 0 && myAngle <= 55))
        {
            anim.SetInteger("Speed", 4);
            isMove = true;
        }

        else if (myAngle >= 56 && myAngle <= 145)
        {
            anim.SetInteger("Speed", 2);
            isMove = true;
        }*/

        /*if(myAngle == 180)
        {
            anim.SetInteger("Speed", 0); //ควบคุม Animator
            isMove = false;
        }

        else
        {
            anim.SetInteger("Speed", 1); //ควบคุม Animator
            isMove = true;
        }*/
    }

    public void Pushing()
    {
        if (RandomDie.pad - pushnum <= 0)
        {
            RandomDie.pad = 0;
        }

        else
        {
            RandomDie.pad -= pushnum;
        }
        
        pushnum = 0;
        isPush = false;
    }
       
}
