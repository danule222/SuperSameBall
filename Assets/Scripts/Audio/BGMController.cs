using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private AudioSource music;

    private void Awake()
    {
        music = GetComponent<AudioSource>();

        if (GameObject.FindGameObjectsWithTag("Music").Length == 1)
        {
            DontDestroyOnLoad(gameObject);

            int song = Random.Range(0, 9);

            switch (song)
            {
                case 0:
                    music.time = 0;
                    break;
                case 1:
                    music.time = 413;
                    break;
                case 2:
                    music.time = 812;
                    break;
                case 3:
                    music.time = 1218;
                    break;
                case 4:
                    music.time = 1630;
                    break;
                case 5:
                    music.time = 2035;
                    break;
                case 6:
                    music.time = 2472;
                    break;
                case 7:
                    music.time = 2906;
                    break;
                case 8:
                    music.time = 3326;
                    break;
                case 9:
                    music.time = 3794;
                    break;
            }

            music.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
