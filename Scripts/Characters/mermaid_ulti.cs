using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermaid_ulti : MonoBehaviour {

    int new_before = 0;
    bool inside;

    int C123_1 = 0;
    int C123_2 = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (StatAll.stat[8, 2, Turns.order] == 3)
        {
            C123_1 = 1;
            C123_2 = 80;
        }

        if (Mermaid.s3[1] != 0)
        {
            if (Turns.round == Mermaid.s3[0] + 3 + C123_1)
            {
                if (Turns.order >= Mermaid.s3[1])
                {
                    Destroy(gameObject);
                }
            }
            else if (Turns.round >= Mermaid.s3[0] + 3 + C123_1)
            {
                {
                    Destroy(gameObject);
                }
            }
        }

        if (new_before != Turns.before_p)
        {
            if (inside == true)
            {
                if (StatAll.stat[7, 0, Mermaid.s3[1]] == 1)
                {
                    StatAll.stat[3, 1, Mermaid.s3[1]] = StatAll.stat[3, 1, Mermaid.s3[1]] + 30 + C123_2;
                }

                else if (StatAll.stat[7, 0, Mermaid.s3[1]] == 2)
                {
                    StatAll.stat[3, 1, Mermaid.s3[1]] = StatAll.stat[3, 1, Mermaid.s3[1]] + 55 + C123_2;
                }

                else if (StatAll.stat[7, 0, Mermaid.s3[1]] == 3)
                {
                    StatAll.stat[3, 1, Mermaid.s3[1]] = StatAll.stat[3, 1, Mermaid.s3[1]] + 80 + C123_2;
                }

                if (StatAll.stat[3, 1, Mermaid.s3[1]] > StatAll.stat[3, 0, Mermaid.s3[1]])
                {
                    StatAll.stat[3, 1, Mermaid.s3[1]] = StatAll.stat[3, 0, Mermaid.s3[1]];
                }
            }

            new_before = Turns.before_p;
        }

        Debug.Log(inside);

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Player_" + Mermaid.s3[1])
        {
            Debug.Log("SUSEnter");
            inside = true;
        }

    }

    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.name == "Player_" + Mermaid.s3[1])
        {
            Debug.Log("SUSStay");
            inside = true;
        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.name == "Player_" + Mermaid.s3[1])
        {
            Debug.Log("SUSExit");
            inside = false;
        }

    }
}
