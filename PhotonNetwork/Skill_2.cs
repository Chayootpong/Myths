using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {

        if (ConnectAndJoinRandom.character == 2)
        {
            Mermaids.Skill_2();
        }

        else if (ConnectAndJoinRandom.character == 3)
        {
            Griffon.Skill_2();
        }
    }
}
