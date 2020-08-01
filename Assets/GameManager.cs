using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playerSpotted = false;
    public static GameManager instance;

    public GameObject reaper;

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)   
        {
            instance = this;
        }
        else if (instance != this)
        {
            // A unique case where the Singleton exists but not in this scene
            if (instance.gameObject.scene.name == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
    void Start()
    {
        JSAM.AudioManager.PlayMusic(JSAM.Music.music1);
        reaper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSpotted){

        }
    }

    public void AlertMusic(){
        JSAM.AudioManager.StopMusic(JSAM.Music.music1);
        StartCoroutine("StartAlertMusic");
        reaper.SetActive(true);
    }

    public IEnumerator StartAlertMusic(){
        yield return new WaitForSeconds(2f);
        JSAM.AudioManager.PlayMusic(JSAM.Music.music2);
    }

    public void NormalMusic(){
        JSAM.AudioManager.StopMusic(JSAM.Music.music2);
        StartCoroutine("StartNormalMusic");
    }
    public IEnumerator StartNormalMusic(){
        yield return new WaitForSeconds(2f);
        JSAM.AudioManager.PlayMusic(JSAM.Music.music1);
    }
}

