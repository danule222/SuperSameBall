using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public List<int> musicList = new List<int>();
    public bool destroysOtherBGM;

    private AudioSource music;

    private void Awake()
    {
        music = GetComponent<AudioSource>();

        if (destroysOtherBGM)
        {
            foreach (GameObject otherBGM in GameObject.FindGameObjectsWithTag("Music"))
            {
                if (otherBGM != gameObject)
                {
                    Destroy(otherBGM);
                }
            }

            DontDestroyOnLoad(gameObject);

            int song = Random.Range(0, musicList.Count - 1);

            music.time = musicList[song];

            music.Play();
        }
        else
        {
            if (GameObject.FindGameObjectsWithTag("Music").Length == 1)
            {
                DontDestroyOnLoad(gameObject);

                int song = Random.Range(0, musicList.Count - 1);

                music.time = musicList[song];
                music.Play();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
