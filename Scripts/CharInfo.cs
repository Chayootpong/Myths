using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StatAll.stat[0, 0, 1] = 1;
        StatAll.stat[0, 0, 2] = 2;
        StatAll.stat[0, 0, 3] = 1;
        StatAll.stat[0, 0, 4] = 2;
        StatAll.stat[0, 0, 5] = 1;
        StatAll.stat[0, 0, 6] = 2;

        for (int i = 1; i <= 6; i++)
        {

            if (StatAll.stat[0, 0, i] == 1) //Goblin == 1
            {
                StatAll.stat[0, 1, i] = Goblin.stat[0];
                StatAll.stat[2, 0, i] = Goblin.stat[1];
                StatAll.stat[2, 2, i] = Goblin.stat[1];
                StatAll.stat[3, 0, i] = Goblin.stat[2];
                StatAll.stat[3, 1, i] = Goblin.stat[2];
                StatAll.stat[3, 2, i] = Goblin.stat[2];
                StatAll.stat[0, 2, i] = Goblin.stat[3];
                StatAll.stat[4, 0, i] = 0;
            }

            if (StatAll.stat[0, 0, i] == 2) //Mermaid == 2
            {
                StatAll.stat[0, 1, i] = Mermaid.stat[0];
                StatAll.stat[2, 0, i] = Mermaid.stat[1];
                StatAll.stat[2, 2, i] = Mermaid.stat[1];
                StatAll.stat[3, 0, i] = Mermaid.stat[2];
                StatAll.stat[3, 1, i] = Mermaid.stat[2];
                StatAll.stat[3, 2, i] = Mermaid.stat[2];
                StatAll.stat[0, 2, i] = Mermaid.stat[3];
                StatAll.stat[4, 0, i] = 0;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {

        
		
	}
}
