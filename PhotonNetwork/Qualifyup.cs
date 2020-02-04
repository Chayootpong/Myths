using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qualifyup : MonoBehaviour {

    public int typequa;

    public GameObject Qua_1;
    public GameObject Qua_2;
    public GameObject Qua_3;
    public GameObject[] Eff_G;
    public GameObject blockQua;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Qualify()
    {

        if (PlayerInfo.level == 3)
        {
            if (typequa == 1)
            {
                PlayerInfo.qualify[0] = 1;
            }

            else if (typequa == 2)
            {
                PlayerInfo.qualify[0] = 2;
            }

            else if (typequa == 3)
            {
                PlayerInfo.qualify[0] = 3;
            }

        }

        else if (PlayerInfo.level == 7)
        {
            if (typequa == 1)
            {
                PlayerInfo.qualify[1] = 1;
            }

            else if (typequa == 2)
            {
                PlayerInfo.qualify[1] = 2;
            }

            else if (typequa == 3)
            {
                PlayerInfo.qualify[1] = 3;
            }

        }

        else if (PlayerInfo.level == 12)
        {
            if (typequa == 1)
            {
                PlayerInfo.qualify[2] = 1;
            }

            else if (typequa == 2)
            {
                PlayerInfo.qualify[2] = 2;
            }

            else if (typequa == 3)
            {
                PlayerInfo.qualify[2] = 3;
            }

            PlayerInfo.isMaxLVL = true;
        }

        if (typequa == 1)
        {
            Eff_G[1].SetActive(false);
            Eff_G[2].SetActive(false);
            Qua_2.SetActive(false);
            Qua_3.SetActive(false);
        }

        else if (typequa == 2)
        {
            Eff_G[0].SetActive(false);
            Eff_G[2].SetActive(false);
            Qua_1.SetActive(false);
            Qua_3.SetActive(false);
        }

        else if (typequa == 3)
        {
            Eff_G[0].SetActive(false);
            Eff_G[1].SetActive(false);
            Qua_1.SetActive(false);
            Qua_2.SetActive(false);
        }

        StartCoroutine("Effect");
        blockQua.SetActive(false);
        PlayerInfo.onceUp = false;
    }

    IEnumerator Effect()
    {
        yield return new WaitForSeconds(1);

        if (typequa == 1)
        {
            Eff_G[0].SetActive(false);
            Qua_1.SetActive(false);
        }

        else if (typequa == 2)
        {
            Eff_G[1].SetActive(false);
            Qua_2.SetActive(false);
        }

        else if (typequa == 3)
        {
            Eff_G[2].SetActive(false);
            Qua_3.SetActive(false);
        }

    }
}
