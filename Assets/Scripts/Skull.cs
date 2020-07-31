using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public Animator animator;
    public bool playerHere = false;
    public bool playerSpotted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        playerHere = true;
        if(other.gameObject.tag == "Player"){
            Debug.Log("found player");
            animator.SetFloat("PlayerVisionTime", 1f);
        }
        StartCoroutine("PlayerCountdown");
    }

    private void OnTriggerExit2D(Collider2D other){
        StopCoroutine("PlayerCountdown");
        if(other.gameObject.tag == "Player"){
            Debug.Log("player left");
            if(!playerSpotted){
                animator.SetFloat("PlayerVisionTime", 0f);
            }
            playerHere = false;
        }
    }
    public IEnumerator PlayerCountdown(){
        yield return new WaitForSeconds(1.25f);
        PlayerCheck();
    }

    private void PlayerCheck(){
        if(playerHere){
            Debug.Log("player spotted");
            playerSpotted = true;
            animator.SetFloat("PlayerVisionTime", 2f);
            StartCoroutine("StopAnimation");
        }
    }

    public IEnumerator StopAnimation(){
        yield return new WaitForSeconds(3f);
        animator.SetFloat("PlayerVisionTime", 0f);
        playerSpotted = false;
    }
    // private void OnCollisionEnter2D(Collision2D other){
    //     Debug.Log("found player");
    //     if(other.gameObject.tag == "Player"){
    //         Debug.Log("found player");
    //         animator.SetFloat("PlayerVisionTime", 1f);
    //     }
    // }
}
