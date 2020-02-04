using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPBar : MonoBehaviour
{
	public Image bar;
	public float maxHealth;
	public float nowHealth;
	public float LerpSpeed = 5;

	void Start()
	{
        
    }
	void Update()
	{
        maxHealth = PlayerInfo.basehp;
        nowHealth = PlayerInfo.hp;

        float calc_health = nowHealth / maxHealth ; //70 /100 0.7
		setHealth(calc_health);
	}

	void  setHealth(float myhealth)
	{
        bar.fillAmount = Mathf.Lerp(bar.fillAmount, myhealth, Time.deltaTime * LerpSpeed);
    }
}
