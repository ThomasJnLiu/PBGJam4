using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
