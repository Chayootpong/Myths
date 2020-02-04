using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverUI : MonoBehaviour
{

    public int skilltype;
    public GameObject skillinfo;
    public Text skillname;
    public Text info;
    public Text status;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter()
    {
        if (skilltype == 1)
        {
            if (ConnectAndJoinRandom.character == 1)
            {
                skillname.text = "JAVELIN SHOT";
                info.text = "     Throw javelin to enermy player that deal 10 / 30 / 50 damage + 0.75 / 1 / 1.25 times of Goblin attack." +
                    "\n\nRange : 20\n\nCooldown : 3";
            }

            else if (ConnectAndJoinRandom.character == 2)
            {
                skillname.text = "WATER SPLASH";
                info.text = "     Splash tide toward enermy player that deal 10 / 50 /90 damage and SLOW it." +
                    "\n\nRange : 20\n\nCooldown : 4 / 3 / 2";
            }

            else if (ConnectAndJoinRandom.character == 3)
            {
                skillname.text = "WIND RUSH";
                info.text = "     Rush to the front pad for 4 that deal 30 / 50 / 70 damage around Griffon when landing." +
                    "\n\nRange : 10 AOE\n\nCooldown : 3";
            }

            else if (ConnectAndJoinRandom.character == 4)
            {
                skillname.text = "ELECTRIC SHOCK";
                info.text = "     Frankenstein taser an enermy player that chance 25 / 30 / 35 % to trigger random effects. (SLOW, STUN, SILENCE)"
                     + " and deal 25 / 45 / 65 damage for each trigger.\n\nRange : 20 \n\nCooldown : 2";
            }

            skillinfo.SetActive(true);
        }

        if (skilltype == 2)
        {
            if (ConnectAndJoinRandom.character == 1)
            {
                skillname.text = "SHABBY ARMOR";
                info.text = "     (Passive) When ever Goblin take damage more than 40 / 30 / 20 % of your MAX HP, Gain 50 / 100 / 150 shield.";
            }

            else if (ConnectAndJoinRandom.character == 2)
            {
                skillname.text = "BUBBLE CAGE";
                info.text = "     Shoot the power ball that STUN an enermy player.\n\nRange : 20 / 25 / 25\n\nCooldown : 4 / 4 / 3";
            }

            else if (ConnectAndJoinRandom.character == 3)
            {
                skillname.text = "AIR SHIELD";
                info.text = "     Griffon release smoke that gain AIMPROOF until your next turn." +
                    "\n\nCooldown : 5 / 4 / 3";
            }

            else if (ConnectAndJoinRandom.character == 4)
            {
                skillname.text = "POWER MEMBRANE";
                info.text = "     (Passive) Reduce incoming damage to your health point for 20 / 30 / 40 damage.";
            }

            skillinfo.SetActive(true);
        }

        if (skilltype == 3)
        {
            if (ConnectAndJoinRandom.character == 1)
            {
                skillname.text = "REVENGE BLOOD";
                info.text = "       Goblin become enrage mode. Increase 50 / 100 / 150 attack. Can be dispel by dead or effect. (Can stack)" +
                    "\n\nCooldown: 4";
            }

            else if (ConnectAndJoinRandom.character == 2)
            {
                skillname.text = "FALL OF HEAVEN";
                info.text = "     Mermaid cast the huge holy area. At the end of each turn if you are in this area, regenerate" +
                    "30 / 55 / 80 health. This effect take 12 turns before dissappear.\n\nRange : 20 AOE\n\nCooldown : 6 / 5 / 4";
            }

            else if (ConnectAndJoinRandom.character == 3)
            {
                skillname.text = "CALL OF STORM";
                info.text = "     Griffon create the great storm that blow the others player for   1 / 2 / 3 pad(s) at the end of each turn" +
                    " until your next turn. (IMMUNE while cast)\n\nRange : Global\n\nCooldown : 6 / 5 / 4";
            }

            else if (ConnectAndJoinRandom.character == 4)
            {
                skillname.text = "ETERNAL FLESH";
                info.text = "     Unleash the true power, Frankenstein gain 100 / 200 / 300 % of your attack and MAX HP. At the end of" +
                    " each turn -10% of them until its origin. Can be dispel by dead.\n\nCooldown : 5";
            }

            skillinfo.SetActive(true);
        }

        if (skilltype == -1)
        {
            status.text = "SLOW [Your next roll get half of point]";
        }

        if (skilltype == -2)
        {
            status.text = "STUN [Skip your turn but still upgrade]";
        }

        if (skilltype == -3)
        {
            status.text = "SILENCE [Can't use skill]";
        }

        if (skilltype == -4)
        {
            status.text = "AIMPROOF [Prevent from be targeted]";
        }

        if (skilltype == -5)
        {
            status.text = "IMMUNE [Can't be damaged or be effected]";
        }

    }

    public void OnPointerExit()
    {
        if (skilltype > 0)
        {
            skillinfo.SetActive(false);
        }

        else if (skilltype < 0)
        {
            status.text = "";
        }
    }
}
