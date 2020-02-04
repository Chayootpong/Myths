using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Choose.Selecting(ConnectAndJoinRandom.character, 0, PlayerInfo.range);
    }
}
