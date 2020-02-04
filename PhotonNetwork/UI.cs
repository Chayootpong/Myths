using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : Photon.MonoBehaviour {

    public Text Name;
    public Text ATK;
    public Text RANGE;
    public Text HP;
    public Text SH;
    public Text LVL;
    public Text Turn;

    public Button skill_1;
    public Button skill_2;
    public Button skill_3;

    public Image portrait;
    public Image[] hpbar;
    public Image icon_1;
    public Image icon_2;
    public Image icon_3;
    public Image icon_4;

    public GameObject cd_1;
    public GameObject cd_2;
    public GameObject cd_3;
    public GameObject cd_atk;

    public Text cdNum_1;
    public Text cdNum_2;
    public Text cdNum_3;

    public Sprite[] s_goblin;
    public Sprite[] s_mermaid;
    public Sprite[] s_griffon;
    public Sprite[] s_frankenstein;
    public Sprite[] s_player;
    public Sprite[] s_icon;
    public Sprite[] s_icon_dead;

    PhotonView _UI;

    // Use this for initialization
    void Start () {

        _UI = this.photonView;
		
	}
	
	// Update is called once per frame
	void Update () {

        SetSprite();
        UpdateSprite();
        OnCooldown();

        if (ConnectAndJoinRandom.createRoom)
        {
            StartCoroutine("Delaysync");
        }

        Name.text = PlayerInfo.c_name;
        ATK.text = PlayerInfo.atk.ToString();
        HP.text = PlayerInfo.hp.ToString() + " / " + PlayerInfo.basehp.ToString();
        LVL.text = PlayerInfo.level.ToString();
        SH.text = PlayerInfo.shield.ToString();
        Turn.text = (PlayerInfo.turn + 1).ToString();
        RANGE.text = PlayerInfo.range.ToString();

    }

    public void UpdateSprite() //ค่อยใช้ Loop
    {

        portrait.sprite = s_player[0];

        if (ConnectAndJoinRandom.character == 1)
        {
            if (PlayerInfo.skilllvl[0] > 0)
            {
                skill_1.image.sprite = s_goblin[0];
            }

            if (PlayerInfo.skilllvl[1] > 0)
            {
                skill_2.image.sprite = s_goblin[1];
            }

            if (PlayerInfo.skilllvl[2] > 0)
            {
                skill_3.image.sprite = s_goblin[2];
            }
        }

        else if (ConnectAndJoinRandom.character == 2)
        {
            portrait.sprite = s_player[1];

            if (PlayerInfo.skilllvl[0] > 0)
            {
                skill_1.image.sprite = s_mermaid[0];
            }

            if (PlayerInfo.skilllvl[1] > 0)
            {
                skill_2.image.sprite = s_mermaid[1];
            }

            if (PlayerInfo.skilllvl[2] > 0)
            {
                skill_3.image.sprite = s_mermaid[2];
            }
        }

        else if (ConnectAndJoinRandom.character == 3)
        {
            portrait.sprite = s_player[2];

            if (PlayerInfo.skilllvl[0] > 0)
            {
                skill_1.image.sprite = s_griffon[0];
            }

            if (PlayerInfo.skilllvl[1] > 0)
            {
                skill_2.image.sprite = s_griffon[1];
            }

            if (PlayerInfo.skilllvl[2] > 0)
            {
                skill_3.image.sprite = s_griffon[2];
            }
        }

        else if (ConnectAndJoinRandom.character == 4)
        {
            portrait.sprite = s_player[3];

            if (PlayerInfo.skilllvl[0] > 0)
            {
                skill_1.image.sprite = s_frankenstein[0];
            }

            if (PlayerInfo.skilllvl[1] > 0)
            {
                skill_2.image.sprite = s_frankenstein[1];
            }

            if (PlayerInfo.skilllvl[2] > 0)
            {
                skill_3.image.sprite = s_frankenstein[2];
            }
        }
    }

    public void SetSprite() //ค่อยใช้ Loop
    {
        if (ConnectAndJoinRandom.character == 1)
        {

            if (PlayerInfo.skilllvl[0] <= 0)
            {
                skill_1.image.sprite = s_goblin[3];
            }

            if (PlayerInfo.skilllvl[1] <= 0)
            {
                skill_2.image.sprite = s_goblin[4];
            }

            if (PlayerInfo.skilllvl[2] <= 0)
            {
                skill_3.image.sprite = s_goblin[5];
            }
        }

        else if (ConnectAndJoinRandom.character == 2)
        {
            if (PlayerInfo.skilllvl[0] <= 0)
            {
                skill_1.image.sprite = s_mermaid[3];
            }

            if (PlayerInfo.skilllvl[1] <= 0)
            {
                skill_2.image.sprite = s_mermaid[4];
            }

            if (PlayerInfo.skilllvl[2] <= 0)
            {
                skill_3.image.sprite = s_mermaid[5];
            }
        }

        else if (ConnectAndJoinRandom.character == 3)
        {
            if (PlayerInfo.skilllvl[0] <= 0)
            {
                skill_1.image.sprite = s_griffon[3];
            }

            if (PlayerInfo.skilllvl[1] <= 0)
            {
                skill_2.image.sprite = s_griffon[4];
            }

            if (PlayerInfo.skilllvl[2] <= 0)
            {
                skill_3.image.sprite = s_griffon[5];
            }
        }

        else if (ConnectAndJoinRandom.character == 4)
        {
            if (PlayerInfo.skilllvl[0] <= 0)
            {
                skill_1.image.sprite = s_frankenstein[3];
            }

            if (PlayerInfo.skilllvl[1] <= 0)
            {
                skill_2.image.sprite = s_frankenstein[4];
            }

            if (PlayerInfo.skilllvl[2] <= 0)
            {
                skill_3.image.sprite = s_frankenstein[5];
            }
        }
    }

    public void OnCooldown()
    {
        if (PlayerInfo.attack)
        {
            cd_atk.SetActive(false);
        }

        else
        {
            cd_atk.SetActive(true);
        }

        if (PlayerInfo.skillcd[0] > 0)
        {
            cd_1.SetActive(true);
            cdNum_1.text = PlayerInfo.skillcd[0].ToString();
        }

        else
        {
            cd_1.SetActive(false);
        }

        if (PlayerInfo.skillcd[1] > 0)
        {
            cd_2.SetActive(true);
            cdNum_2.text = PlayerInfo.skillcd[1].ToString();
        }

        else
        {
            cd_2.SetActive(false);
        }

        if (PlayerInfo.skillcd[2] > 0)
        {
            cd_3.SetActive(true);
            cdNum_3.text = PlayerInfo.skillcd[2].ToString();
        }

        else
        {
            cd_3.SetActive(false);
        }
    }

    [PunRPC]
    public void UpdatePortrait(int player, int turnnum, int hp)
    {
        if (hp > 0)
        {
            if (turnnum == 0)
            {
                icon_1.sprite = s_icon[player - 1];
            }

            else if (turnnum == 1)
            {
                icon_2.sprite = s_icon[player - 1];
            }

            else if (turnnum == 2)
            {
                icon_3.sprite = s_icon[player - 1];
            }

            else if (turnnum == 3)
            {
                icon_4.sprite = s_icon[player - 1];
            }
        }

        else
        {
            if (turnnum == 0)
            {
                icon_1.sprite = s_icon_dead[player - 1];
            }

            else if (turnnum == 1)
            {
                icon_2.sprite = s_icon_dead[player - 1];
            }

            else if (turnnum == 2)
            {
                icon_3.sprite = s_icon_dead[player - 1];
            }

            else if (turnnum == 3)
            {
                icon_4.sprite = s_icon_dead[player - 1];
            }
        }
    }

    [PunRPC]
    public void UpdateAllHP(int playnum, int basehp, int hp)
    {
        float new_basehp = basehp;
        float new_hp = hp;
        float cal_hp = new_hp/ new_basehp;

        /*Debug.Log(cal_hp);
        Debug.Log(basehp);
        Debug.Log(hp);*/

        if (playnum == 0)
        {
            hpbar[0].fillAmount = Mathf.Lerp(hpbar[0].fillAmount, cal_hp, Time.deltaTime * 5);
        }

        else if (playnum == 1)
        {
            hpbar[1].fillAmount = Mathf.Lerp(hpbar[1].fillAmount, cal_hp, Time.deltaTime * 5);
        }

        else if (playnum == 2)
        {
            hpbar[2].fillAmount = Mathf.Lerp(hpbar[2].fillAmount, cal_hp, Time.deltaTime * 5);
        }

        else if (playnum == 3)
        {
            hpbar[3].fillAmount = Mathf.Lerp(hpbar[3].fillAmount, cal_hp, Time.deltaTime * 5);
        }
    }

    IEnumerator Delaysync()
    {
        yield return new WaitForSeconds(1);
        _UI.RPC("UpdatePortrait", PhotonTargets.All, ConnectAndJoinRandom.character, PlayerInfo.Turnnum, PlayerInfo.hp);
        _UI.RPC("UpdateAllHP", PhotonTargets.All, PlayerInfo.Turnnum, PlayerInfo.basehp, PlayerInfo.hp);
    }
}
