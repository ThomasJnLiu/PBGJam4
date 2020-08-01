using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource bgm;
    public void PlayGame()
    {
        bgm.Stop();
        audio.Play();
        StartCoroutine("LoadLevel");

    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public IEnumerator LoadLevel(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene");
    }
}
