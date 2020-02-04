using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundbox : MonoBehaviour {

    public AudioClip[] goblin_s;
    public AudioClip[] mermaid_s;
    public AudioClip[] griffon_s;
    public AudioClip[] franken_s;

    AudioSource audios;
    public static bool isPlay = false;
    public static int player, skill;

    // Use this for initialization
    void Start () {

        audios = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        if (player != 0 && skill != 0)
        {
            if (player == 1 && skill == 1)
            {
                audios.clip = goblin_s[0];
            }

            else if (player == 1 && skill == 3)
            {
                audios.clip = goblin_s[2];
            }

            else if (player == 2 && skill == 1)
            {
                audios.clip = mermaid_s[0];
            }

            else if (player == 2 && skill == 2)
            {
                audios.clip = mermaid_s[1];
            }

            else if (player == 3 && skill == 1)
            {
                audios.clip = griffon_s[0];
            }

            else if (player == 3 && skill == 2)
            {
                audios.clip = griffon_s[1];
            }

            else if (player == 4 && skill == 1)
            {
                audios.clip = franken_s[0];
            }

            else if (player == 4 && skill == 3)
            {
                audios.clip = franken_s[2];
            }
        }

        if (!audios.isPlaying && isPlay)
        {
            audios.Play();
            isPlay = false;
        }

    }
}
