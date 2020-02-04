using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour {

    public Transform[] player;
    public static float[,] distancePlayer = new float [10,10] ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        distancePlayer[1, 2] = Vector3.Distance(player[1].position, player[2].position);
        distancePlayer[2, 1] = distancePlayer[1, 2];

        distancePlayer[1, 3] = Vector3.Distance(player[1].position, player[3].position);
        distancePlayer[3, 1] = distancePlayer[1, 3];

        distancePlayer[1, 4] = Vector3.Distance(player[1].position, player[4].position);
        distancePlayer[4, 1] = distancePlayer[1, 4];

        distancePlayer[1, 5] = Vector3.Distance(player[1].position, player[5].position);
        distancePlayer[5, 1] = distancePlayer[1, 5];

        distancePlayer[1, 6] = Vector3.Distance(player[1].position, player[6].position);
        distancePlayer[6, 1] = distancePlayer[1, 6];

        distancePlayer[2, 3] = Vector3.Distance(player[2].position, player[3].position);
        distancePlayer[3, 2] = distancePlayer[2, 3];

        distancePlayer[2, 4] = Vector3.Distance(player[2].position, player[4].position);
        distancePlayer[4, 2] = distancePlayer[2, 4];

        distancePlayer[2, 5] = Vector3.Distance(player[2].position, player[5].position);
        distancePlayer[5, 2] = distancePlayer[2, 5];

        distancePlayer[2, 6] = Vector3.Distance(player[2].position, player[6].position);
        distancePlayer[6, 2] = distancePlayer[2, 6];

        distancePlayer[3, 4] = Vector3.Distance(player[3].position, player[4].position);
        distancePlayer[4, 3] = distancePlayer[3, 4];

        distancePlayer[3, 5] = Vector3.Distance(player[3].position, player[5].position);
        distancePlayer[5, 3] = distancePlayer[3, 5];

        distancePlayer[3, 6] = Vector3.Distance(player[3].position, player[6].position);
        distancePlayer[6, 3] = distancePlayer[3, 6];

        distancePlayer[4, 5] = Vector3.Distance(player[4].position, player[5].position);
        distancePlayer[5, 4] = distancePlayer[4, 5];

        distancePlayer[4, 6] = Vector3.Distance(player[4].position, player[6].position);
        distancePlayer[6, 4] = distancePlayer[4, 6];

        distancePlayer[5, 6] = Vector3.Distance(player[5].position, player[6].position);
        distancePlayer[6, 5] = distancePlayer[5, 6];

        distancePlayer[1, 1] = 1000;
        distancePlayer[2, 2] = 1000;
        distancePlayer[3, 3] = 1000;
        distancePlayer[4, 4] = 1000;
        distancePlayer[5, 5] = 1000;
        distancePlayer[6, 6] = 1000;

        /*for (int i = 1; i <= 5; i++)
        {
            for (int j =  i + 1; j <= 6; j++)
            {
                Debug.Log("Distance[" + i + "," + j + "] = " + distancePlayer[i,j]);
            }
        }*/

    }
}
