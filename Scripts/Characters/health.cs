using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class health : MonoBehaviour
{
	public Image bar;
	public float maxHealth = 100f;
	public float nowHealth = 0f;
	public float LerpSpeed = 5;

	void Start()
	{
		nowHealth = maxHealth;
	}
	void Update()
	{
		float calc_health = nowHealth / maxHealth ; //70 /100 0.7
		setHealth(calc_health);
	}

	void  setHealth(float myhealth)
	{
		bar.fillAmount = Mathf.Lerp (bar.fillAmount,myhealth,Time.deltaTime*LerpSpeed);

	}
}
